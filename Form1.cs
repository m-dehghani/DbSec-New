using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Security;
using System.Configuration;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using Exception = System.Exception;

namespace DBSec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            label30.Text = "";
            btn_backupCertificate.Enabled = false;
            label2.Text = "please wait...";
            label30.Text += await BackupCertificate(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass,
                txt_certificateBackupPath.Text);



            label30.Text += await BackupDataBase(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass,
                txt_certificateBackupPath.Text);
            //if (checkBox1.Checked == true )
            //{
            //    label30.Text += await Utility.PutFileInFTP(localFilePath: textBox1.Text + "\\" +
            //        Utility.DbName + ".pvk", pharmacySerial:
            //        Utility.DbName) + "\n";

            //    label30.Text += await Utility.PutFileInFTP(localFilePath: textBox1.Text + "\\" +
            //        Utility.DbName + ".cer", pharmacySerial:
            //        Utility.DbName) + "\n";

            //    label30.Text += await Utility.PutFileInFTP(localFilePath: textBox1.Text + "\\" +
            //        Utility.DbName + ".key",  pharmacySerial:
            //        Utility.DbName) + "\n";
            //    if (checkBox4.Checked)
            //    {
            //        label30.Text += await Utility.PutFileInFTP(localFilePath: textBox1.Text + "\\" +
            //                                                                  Utility.DbName + ".bak",  pharmacySerial:
            //                            Utility.DbName) + "\n";
            //    }
            //}

            label2.Text = "";
            btn_backupCertificate.Enabled = true;
        }
        private async Task<string> BackupDataBase(string IP, string DB, SecureString pass, string pathToBackup)
        {
            var constr = Utility.MakeConnectionStr(IP, DB, pass);
            var res = await Utility.TestDbConnection(constr);
            if (res != "Ok")
            {
                return ("خطا در اتصال به دیتابیس " + res);

            }
            using (SqlConnection conn = new SqlConnection(constr))
            {

                try
                {
                    await conn.OpenAsync();
                    var comm = string.Format(@" use master; OPEN MASTER KEY DECRYPTION BY PASSWORD = '{0}';BACKUP DATABASE {2} TO DISK=N'{1}\{3}.bak';", pass, pathToBackup, DB,  DateTime.Now.ToShortDateString().Replace('/', '-'));
                    SqlCommand command = new SqlCommand(comm, conn);
                    command.ExecuteNonQuery();
                    return "Backup با موفقیت کپی شد";
                    
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
                finally
                { conn.Close(); }
            }
        }
        private async Task<string> BackupCertificate(string IP, string DB, SecureString pass, string pathToBackup)
        {
            var constr = Utility.MakeConnectionStr(IP, DB, pass);
            var res = await Utility.TestDbConnection(constr);
            if (res != "Ok")
            {
                return "خطا در اتصال به دیتابیس ";

            }
            using (SqlConnection conn = new SqlConnection(constr))

            {

                try
                {
                    string returnMessage = "";
                    await conn.OpenAsync();
                    var comm = string.Format($@"use master;
                                                    OPEN MASTER KEY DECRYPTION BY PASSWORD = N'{Utility.ToInsecureString(pass)}';                                                    
                                                    BACKUP CERTIFICATE {DB} TO FILE = N'{pathToBackup}\{DB}.cer'
                                                    WITH PRIVATE KEY
                                                    (FILE = N'{pathToBackup}\{DB}.pvk',ENCRYPTION BY PASSWORD = N'{Utility.passPhrase}')"
                                                     );
                    SqlCommand command = new SqlCommand(comm, conn);
                    await command.ExecuteNonQueryAsync();
                    returnMessage += "certificate با موفقیت کپی شد\n";
                    comm = string.Format($@"BACKUP MASTER KEY TO FILE = N'{0}\{Utility.DbName}.key'  ENCRYPTION BY PASSWORD = '{1}';",
                        pathToBackup, Utility.ToInsecureString(pass));
                    command = new SqlCommand(comm, conn);
                    await command.ExecuteNonQueryAsync();
                    conn.Close();


                    returnMessage += "Master Key با موفقیت کپی شد\n";

                    return returnMessage;
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
        }

        private async Task<string> EncryptDB(string IP, string DB, SecureString pass)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(IP, DB, pass));

                SqlCommand command;
                try
                {
                    command = new SqlCommand($@"USE master;
                                                      CREATE MASTER KEY ENCRYPTION BY PASSWORD = '{Utility.ToInsecureString(pass)}'", conn);
                    await conn.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                }
                catch { }
                finally { conn.Close(); }


                command = new SqlCommand(string.Format($@"
                                                      USE master;
                                                      
                                                      CREATE CERTIFICATE {Utility.DbName} WITH SUBJECT = 'My DEK Certificate';
                                                      USE {DB};
                                                      CREATE DATABASE ENCRYPTION KEY
                                                      WITH ALGORITHM = AES_128
                                                      ENCRYPTION BY SERVER CERTIFICATE {Utility.DbName};  
                                                      ALTER DATABASE {DB}
                                                      SET ENCRYPTION ON;"), conn);

                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
                conn.Close();
                return "Done!";


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    

        private async Task<string> RestoreCertificateAndDb(string dbNameToRecover, string IP, string DB, SecureString pass, string masterKeyPath, string certificatePath, string privateKeyPath, string DbPath, string ldfPath, string fileType)
        {
            SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(IP, DB, pass));

            try
            {

               
                string textCommad;
                if (fileType == "mdf")
                {

                    textCommad = string.Format($@"use master;

                              RESTORE MASTER KEY   
                              FROM FILE = N'{masterKeyPath}'   
                              DECRYPTION BY PASSWORD = '{Utility.ToInsecureString(pass)}'   
                              ENCRYPTION BY PASSWORD = '{Utility.ToInsecureString(pass)}';  
                              OPEN MASTER KEY DECRYPTION BY PASSWORD = '{Utility.ToInsecureString(pass)}'  
                              use master;
                              create certificate {Utility.DbName}
                              from file = N'{certificatePath}'
                              with private key
                                    ( file = N'{privateKeyPath}'
                                        , decryption by password ={Utility.passPhrase}
                                    )
                              CREATE DATABASE {dbNameToRecover}   
                              ON (FILENAME = '{DbPath}'),   
                                 (FILENAME = '{ldfPath}')   
                              FOR ATTACH;");
                }
                else
                {
                    textCommad = string.Format($@"use master;
                              RESTORE MASTER KEY   
                              FROM FILE = N'{masterKeyPath}'   
                              DECRYPTION BY PASSWORD = '{dbNameToRecover}'
                              ENCRYPTION BY PASSWORD = '{dbNameToRecover}';  
                              OPEN MASTER KEY DECRYPTION BY PASSWORD = '{dbNameToRecover}'  
                              use master;
                              create certificate {Utility.DbName}
                              from file = N'{certificatePath}'
                              with private key
                                    ( file = N'{privateKeyPath}'
                                        , decryption by password = {Utility.passPhrase}
                                    )

                              RESTORE DATABASE {5} 

                              FROM DISK = '{3}' WITH REPLACE");
                }
                SqlCommand command = new SqlCommand(textCommad, conn);
                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return "با موفقیت انجام شد";
                

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }


        }

        public struct dataOfTiny
        {
            public string DataPartition, SerialNumber;
            public dataOfTiny(string dataPartition, string serialNumber)
            {
                DataPartition = dataPartition;
                SerialNumber = serialNumber;
            }
        };
        //public async Task<dataOfTiny> ReadFromTiny()
        //{
        //    dataOfTiny data = new dataOfTiny();
        //    Tn.ServerIP = "127.0.0.1";
        //    Tn.NetWorkINIT = true;
        //    if (Tn.TinyErrCode == 0)
        //    {
        //        Tn.UserPassWord = TinyCode.Text;
        //        Tn.ShowTinyInfo = true;
        //        var dataInTiny = Tn.DataPartition.Split('@');
        //        var serial = Tn.SerialNumber.Split('-');
        //        var serialwithoutdash = string.Join("", serial);
        //        return new dataOfTiny(Tn.DataPartition, serialwithoutdash);
        //    }
        //    else
        //    {
        //        Tn.Initialize = true;
        //        if (Tn.TinyErrCode == 0)
        //        {
        //            Tn.UserPassWord = TinyCode.Text;
        //            Tn.ShowTinyInfo = true;
        //            Tn.UserPassWord = TinyCode.Text;
        //            Tn.ShowTinyInfo = true;
        //            if (Tn.DataPartition == "") return new dataOfTiny("error", "error");
        //            var serial = Tn.SerialNumber.Split('-');
        //            var serialwithoutdash = string.Join("", serial);
        //            return new dataOfTiny(Tn.DataPartition, serialwithoutdash);
        //        }
        //        else
        //        {
        //            return new dataOfTiny("error", "error");
        //        }
        //    }
        //}
        private async void Form1_Load(object sender, EventArgs e)
        {
            // Bitmap image = new Bitmap(@"C:\Users\Administrator\Downloads\d_helix-css-gif-_50fps-selective_-1a.gif");
            //image.MakeTransparent();
            //pictureBox1.Image = image;
            //  System.Configuration.ConfigurationManager.appSetting;
            radioButton2.Checked = true;
           // SecTab.Enabled = false;
            panel3.Enabled = btn_testDb.Enabled ;
            label32.Text= label23.Text = label25.Text= label24.Text = label19.Text = label31.Text = label30.Text = label26.Text = label27.Text = label28.Text = label22.Text = label2.Text = label7.Text = label3.Text = label10.Text = label11.Text = label12.Text = label9.Text = label20.Text = label21.Text = "";
            var internetDateTime=  await Utility.GetDateTimeFromInternetAsync();
            //MessageBox.Show(dateTime.ToLongDateString());

            
            var systemDateTime = DateTime.Now;
            //MessageBox.Show(now.ToLongDateString());
            var difference = internetDateTime - systemDateTime;
            var comp = difference.CompareTo(new TimeSpan(0, 30, 0));
            if (comp==1)
            {
                MessageBox.Show("ساعت سیستم تنظیم نمی باشد" );
            }

           
            // pictureBox1.Location = new Point(0, 0);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_certificateBackupPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            try
            {
                if ((string.IsNullOrEmpty(txt_DB.Text.Trim())) || (string.IsNullOrEmpty(txt_ServerIP.Text.Trim())))
                {
                    MessageBox.Show("لطفا تمام فیلدها را پر نمایید");
                }
                else
                {

                    var rawConstr = "provider=sqloledb.1;" + Utility.MakeConnectionStr(txt_ServerIP.Text, txt_DB.Text,
                       Utility.DBPass);

                    //var res = await Utility.TestDbConnection(rawConstr);
                    //if (res != "Ok")
                    //{
                    //    MessageBox.Show("خطا در اتصال به دیتابیس " + res);
                    //    return;
                    //}



                    string conStr = Utility.Encrypt(rawConstr);


                    ConfigXmlDocument configXmlDocument = new ConfigXmlDocument();
                    configXmlDocument.Load(txt_ConfigFilePath.Text);
                    var c = configXmlDocument.DocumentElement.GetElementsByTagName("appSettings").Item(0).ChildNodes;

                    bool found = false;
                    foreach (XmlNode node in configXmlDocument.DocumentElement.GetElementsByTagName("appSettings").Item(0).ChildNodes)
                    {
                        if (node.Attributes["key"].Value == "conn")
                        {
                            found = true;
                            node.Attributes["value"].Value = conStr;
                        }

                    }
                    if (found != true)
                    {
                        configXmlDocument.DocumentElement.GetElementsByTagName("appSettings").Item(0).InnerXml = string.Format("<add key=\"conn\" value=\"{0}\" />", conStr) + configXmlDocument.DocumentElement.GetElementsByTagName("appSettings").Item(0).InnerXml;
                    }


                    //foreach (XmlNode node in configXmlDocument.DocumentElement.GetElementsByTagName("userSettings").Item(0).ChildNodes)
                    //   "TinyServerID"

                    configXmlDocument.Save(txt_ConfigFilePath.Text);
                    label20.Text = "کانفیگ سرور ساخته شد";

                    var newnode = configXmlDocument.DocumentElement.GetElementsByTagName("Sinad.Properties.Settings").Item(0).ChildNodes[6];
                    newnode.InnerXml = "<value>" + txt_tinyAddress.Text + "</value>";

                    configXmlDocument.Save(txt_ConfigFilePath.Text + ".client");
                    label21.Text = "کانفیگ کلاینت ساخته شد";

                    label19.Text = "\u2714";


                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }


        private void Button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                label25.Text = "";
                dataOfTiny dataOfTiny;
                dataOfTiny.DataPartition = "error";
                dataOfTiny.SerialNumber = "";
             

             
                    panel1.Enabled = true;
                    //var tmpPass =Utility.ToSecureString(dataOfTiny.DataPartition.Split('@')[1]);
                    //label25.Text =Utility.ToInsecureString(tmpPass).Split('-').First()+"_......_"+Utility.ToInsecureString(tmpPass).Split('-').Last();
                    //Utility.DBPass = tmpPass;
                    textBox10.Text = dataOfTiny.DataPartition.Split('@')[1].ToString();
                    //Utility.passPhrase = Utility.ToSecureString(dataOfTiny.DataPartition.Split('@')[1]);
                    
                    SecTab.Enabled = true;
                    panel3.Enabled = false;
                    button6.BackColor = Color.Green;
                    if (radioButton3.Checked)
                    {
                        TinyCode.BackColor = Color.Lime;
                    }
                    else
                    {
                        textBox14.BackColor = Color.Lime;
                    }

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Txt_ServerIP_TextChanged(object sender, EventArgs e)
        {
            txt_DB.Items.Clear();
            txt_DB.Text = "";
            //SecTab.Enabled = false;
        }

        private async void Button8_Click(object sender, EventArgs e)
        {


            if ((string.IsNullOrEmpty(txt_DB.Text.Trim())) || (string.IsNullOrEmpty(txt_ServerIP.Text.Trim())))
            {
                MessageBox.Show("لطفا تمام فیلدها را پر نمایید");
            }
            else
            {
                var rawConstr = Utility.MakeConnectionStr(txt_ServerIP.Text, txt_DB.Text,Utility.DBPass);
                var res = await Utility.TestDbConnection(rawConstr);

                if (res != "Ok")
                {
                    label10.ForeColor = Color.Red;
                    SecTab.Enabled = false;
                    label10.Text = "خطا در اتصال به دیتابیس " + res;
                    btn_testDb.BackColor = Color.Red;
                    panel3.Enabled = true;
                    label7.Text = "ابتدا پسورد را تغییر دهید";
                    return;
                }
                else
                {
                    await CheckForDbEncrypted(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass);

                    //abel10.BackColor = Color.
                    //button8.BackColor = Color.Lime;
                    panel3.Enabled = false;
                    //label10.ForeColor = Color.Lime;
                    //SecTab.Enabled = true;
                    label10.Text = "\u2714";
                }
            }
        }




        private async Task CheckForDbEncrypted(string IP, string DB, SecureString pass)
        {

            var constr = Utility.MakeConnectionStr(IP, DB, pass);
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand command;
            command = new SqlCommand(string.Format(@"SELECT
                                                    db.name,
                                                    db.is_encrypted,
                                                    dm.encryption_state,
                                                    dm.percent_complete,
                                                    dm.key_algorithm,
                                                    dm.key_length
                                                    FROM
                                                    sys.databases db
                                                    LEFT OUTER JOIN sys.dm_database_encryption_keys dm
                                                        ON db.database_id = dm.database_id WHERE name = '{0}'; ", DB), conn);
            await conn.OpenAsync();
            var dbreader = await command.ExecuteReaderAsync();
            await dbreader.ReadAsync();
            var test = (bool)dbreader[1];
            conn.Close();
            if (test == true)
            {
                var res = MessageBox.Show("این دیتابیس قبلا رمز نگاری شده است");
                await AddLoginTrigger(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass);
                conn.Close();
                return;
            }





            command = new SqlCommand("use master;select COUNT(*) from sys.certificates where name='myservercert'", conn);
            await conn.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            await dbreader.ReadAsync();
            if ((int)reader[0] > 0)
            {
                conn.Close();
                var res = MessageBox.Show("certificate در این سیستم وجود دارد.آیا مایلید پاک شود؟", "", MessageBoxButtons.YesNo);
                if (res != DialogResult.Yes)
                    return;
                else
                {
                    command = new SqlCommand("use master;drop certificate myservercert;drop master key;", conn);
                    await conn.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("با موفقیت حذف شد");
                    conn.Close();
                }
            }


        }

       
        private async void btn_encrypt_Click(object sender, EventArgs e)
        {
            btn_encrypt.Enabled = false;
            label26.Text = await EncryptDB(txt_ServerIP.Text, txt_DB.Text,
                                 Utility.DBPass);
            label27.Text = await BackupCertificate(txt_ServerIP.Text, txt_DB.Text,
                                 Utility.DBPass, txt_certificatePath.Text);
            label28.Text = "لطفا منتظر بمانید";
            label28.Text = await BackupDataBase(txt_ServerIP.Text, txt_DB.Text,
                               Utility.DBPass, txt_certificatePath.Text);
            btn_testDb.PerformClick();
            //if (checkBox2.Checked == true && textBox14.Text != "")
            //{
            //    label32.Text += await Utility.PutFileInFTP(localFilePath: textBox5.Text + "\\" +
            //        Utility.DbName + ".pvk") + "\n";

            //    label32.Text += await Utility.PutFileInFTP(localFilePath: textBox5.Text + "\\" +
            //        Utility.DbName + ".cer") + "\n";

            //    label32.Text += await Utility.PutFileInFTP(localFilePath: textBox5.Text + "\\" +
            //        Utility.DbName + ".key") + "\n";
            //    if (checkBox3.Checked)
            //    {
            //        label32.Text += await Utility.PutFileInFTP(localFilePath: textBox5.Text + "\\" +
            //                                                                  Utility.DbName +
            //                                                                  ".bak") +
            //                                                                "\n";
            //    }

            //}

            label12.Text = "\u2714";
            btn_encrypt.Enabled = true;

        }



        private void Button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "key files(*.key)|*.key";
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_masterKeyRestorePath.Text = openFileDialog1.FileName;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_certificatePath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "certificate files(*.cer)|*.cer";
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_certificateRestorePath.Text = openFileDialog1.FileName;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bak files(*.bak)|*.bak";
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_dbRestorePath.Text = openFileDialog1.FileName;
        }

        private async void Button9_Click(object sender, EventArgs e)
        {
            btn_restore.Enabled = false;
            var ldfpath = txt_dbRestorePath.Text.Remove(txt_dbRestorePath.Text.Length - 3, 3) + "ldf";
            var filetype = "mdf";
            if (radioButton1.Checked == true) filetype = "mdf"; else filetype = "bak";
            label31.Text = "لطفا منتظر باشید";
            label31.Text = await RestoreCertificateAndDb(txt_dbRestoreName.Text, txt_ServerIP.Text, "master", Utility.DBPass, txt_masterKeyRestorePath.Text
                , txt_certificateRestorePath.Text, txt_privateKeyRestorePath.Text, txt_dbRestorePath.Text, ldfpath, filetype);
            btn_restore.Enabled = true;
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "private key files(*.pvk)|*.pvk";
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_privateKeyRestorePath.Text = openFileDialog1.FileName;
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            try
            {
                await ChangePassAndRenameSa(txt_ServerIP.Text, txt_DB.Text, Utility.ToSecureString(textBox4.Text),"sa");
                await DisableAllUserButSa(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass);
                await AddLoginTrigger(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass);
            }
            catch (Exception ex)
            {
                label7.Text = ex.Message;
            }
        }

        private async Task AddLoginTrigger(string address, string db, SecureString pass)
        {
            try
            {
                //SqlCommand command;
                await CrateLoginAuditTable(address, db, pass);


                //--Step2: Create VIEW To read XML Audit Data in user-friendly format
                await CreateLoginAuditView(address, db, pass);

                //--Step3: Create login Trigger to block all application except tiny data
                await CreateLoginTrigger(address, db, pass, "'" + pass + "'");
            }
            catch (Exception ex)
            {
                if (ex.Message== "There is already an object named 'loginAuditView' in the database.")
                {
                    
                }
                else
                {
                   MessageBox.Show(ex.Message);
                }
            }

        }

        private async Task CrateLoginAuditTable(string address, string db, SecureString pass)
        {
            SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass, "bastaniteb"));
            await conn.OpenAsync();
            //--Step1: Create Audit Table
            SqlCommand command = new SqlCommand(@"USE master;
            IF Not EXISTS(SELECT * FROM   INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'loginAuditTable') 
            CREATE TABLE dbo.loginAuditTable (
                id INT IDENTITY PRIMARY KEY,
                data XML,
                program_name nvarchar(128)
            );", conn);
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }


        private async Task CreateLoginAuditView(string address, string db, SecureString pass)
        {
            try
            {

                SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass, "bastaniteb"));
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand(@"
                CREATE VIEW dbo.loginAuditView
                AS
                SELECT id
                      ,data.value('(/EVENT_INSTANCE/EventType)[1]', 'sysname') AS EventType
                      ,data.value('(/EVENT_INSTANCE/PostTime)[1]', 'datetime') AS PostTime
                      ,data.value('(/EVENT_INSTANCE/SPID)[1]', 'int') AS SPID
                      ,data.value('(/EVENT_INSTANCE/ServerName)[1]', 'nvarchar(257)') AS ServerName
                      ,data.value('(/EVENT_INSTANCE/LoginName)[1]', 'sysname') AS LoginName
                      ,data.value('(/EVENT_INSTANCE/LoginType)[1]', 'sysname') AS LoginType
                      ,data.value('(/EVENT_INSTANCE/ClientHost)[1]', 'sysname') AS ClientHostName
                      ,data.value('(/EVENT_INSTANCE/IsPooled)[1]', 'bit') AS IsPooled
                      ,program_name
                      ,data.value('(/EVENT_INSTANCE/SID)[1]', 'nvarchar(85)') AS SID
                FROM master.dbo.loginAuditTable;
                ", conn);
                await command.ExecuteNonQueryAsync();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private async Task CreateLoginTrigger(string address, string db, SecureString pass, string applications)
        {

            SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass, "bastaniteb"));
            await conn.OpenAsync();
            SqlCommand command = new SqlCommand(@"IF EXISTS(
    SELECT * FROM master.sys.server_triggers
    WHERE parent_class_desc = 'SERVER' AND name = N'Allow_only_Application_Login_Trigger')
DROP TRIGGER [Allow_only_Application_Login_Trigger] ON ALL SERVER;", conn);
            await command.ExecuteNonQueryAsync();

            command = new SqlCommand(string.Format(@"
CREATE TRIGGER Allow_only_Application_Login_Trigger
ON ALL SERVER WITH EXECUTE AS 'bastaniteb'
FOR LOGON
AS
BEGIN

DECLARE @data XML
SET @data = EVENTDATA()
 
DECLARE @AppName sysname
       ,@LoginName sysname
       ,@LoginType sysname
       ,@HostName sysname

SELECT @AppName = [program_name]
FROM sys.dm_exec_sessions
WHERE session_id = @data.value('(/EVENT_INSTANCE/SPID)[1]', 'int')

SELECT @LoginName = @data.value('(/EVENT_INSTANCE/LoginName)[1]', 'sysname')
      ,@LoginType = @data.value('(/EVENT_INSTANCE/LoginType)[1]', 'sysname')
      ,@HostName = @data.value('(/EVENT_INSTANCE/ClientHost)[1]', 'sysname')

IF @AppName not in  ({0}) 
    BEGIN
        ROLLBACK; --Disconnect the session
        
        --Log the exception to our Auditing table
        INSERT INTO master.dbo.loginAuditTable(data, program_name)
        VALUES(@data, @AppName)
    END 
END;", applications), conn);

            await command.ExecuteNonQueryAsync();
            conn.Close();

        }

        private async Task ChangePassAndRenameSa(string address, string db, SecureString pass, string newSaUserName)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass, "sa"));
                await conn.OpenAsync();
                SqlCommand comm = new SqlCommand(

                  string.Format($@"USE MASTER
                                  ALTER LOGIN sa WITH NAME = {newSaUserName},
                                  PASSWORD = '{0}'; ", Utility.ToInsecureString(Utility.DBPass)), conn);


                await comm.ExecuteNonQueryAsync();
                textBox4.BackColor = Color.Lime;
                label11.Text = "\u2714";

                conn.Close();
            }
            catch (Exception ex)
            {

                SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass, newSaUserName));
                await conn.OpenAsync();
                SqlCommand comm = new SqlCommand(

                  string.Format($@"USE MASTER
                                  ALTER LOGIN BastaniTeb  WITH NAME = {newSaUserName},
                                  PASSWORD = '{0}'; ", Utility.ToInsecureString(Utility.DBPass)), conn);


                await comm.ExecuteNonQueryAsync();
                textBox4.BackColor = Color.Lime;
                label11.Text = "\u2714";

                conn.Close();

            }

        }

        public async Task DisableAllUserButSa(string address, string db, SecureString pass)
        {
            SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass));

            try
            {
                string strCommand = string.Format(@"SELECT 'use master;Deny connect to ' + QUOTENAME(sp.name) 
                                  FROM sys.server_principals sp
                                  WHERE sp.principal_id > 100   
                                  AND sp.is_disabled = 0
                                  AND sp.type IN ('G','s','u') and name<> '##MS_PolicyTsqlExecutionLogin##' ;", db);

            
                SqlCommand command = new SqlCommand(strCommand, conn);
                await conn.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                List<string> commands = new List<string>();
                while (await reader.ReadAsync())
                {
                    commands.Add(reader[0].ToString());

                }
                strCommand = string.Format(@"SELECT 'use master;ALTER LOGIN ' + QUOTENAME(sp.name) + ' DISABLE;'
                                                FROM sys.server_principals sp
                                                WHERE sp.principal_id > 100
                                                    AND sp.is_disabled = 0
                                                    AND sp.type IN (
                                                        'U'
         
                                                        , 'S' 
                                                        );");
                command = new SqlCommand(strCommand, conn);
                reader.Close();
                reader = await command.ExecuteReaderAsync();


                while (await reader.ReadAsync())
                {
                    commands.Add(reader[0].ToString());

                }
                conn.Close();
                await conn.OpenAsync();
                SqlCommand alterLoginCommand;
                commands.ForEach(async c =>
                {
                    alterLoginCommand = new SqlCommand(c, conn);
                    await alterLoginCommand.ExecuteNonQueryAsync();
                });




                MessageBox.Show("تمامی کاربران غیرفعال شدند");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { conn.Close(); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "config files(*.config)|*.config|All files(*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            var res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                txt_ConfigFilePath.Text = openFileDialog1.FileName;
                txt_tinyAddress.Text = Utility.GetLocalIPAddress();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "DB files(*.mdf)|*.mdf";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Backup files(*.bak)|*.bak";
        }

       

        private async void comboBox1_Enter(object sender, EventArgs e)
        {
            string constr = Utility.MakeConnectionStr(txt_ServerIP.Text, "Master", Utility.DBPass);
            SqlConnection conn = new SqlConnection(constr);

            try
            {
                txt_DB.Text = "";
                txt_DB.Items.Clear();
                  SqlCommand command = new SqlCommand("SELECT name FROM master.sys.databases", conn);
                Utility.DBPass = Utility.ToSecureString(txt_DbPass.Text);

                await conn.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    txt_DB.Items.Add(reader[0]);
                }
               
                btn_testDb.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطایی رخ داده.لطفا آدرس را چک نمایید");
                panel3.Enabled = true;
                btn_testDb.Enabled = false;
            }
            finally { conn.Close(); }
        }

      
        private bool sqlOpen = false;
        private async void button16_Click(object sender, EventArgs e)
        {
            if (sqlOpen == false)
            {
                try
                {

                    await CreateLoginTrigger(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass,
                        "'" + Utility.ToInsecureString(Utility.DBPass) + "'" +
                        ",'Microsoft SQL Server Management Studio'");
                    /////unlocksql
                    btn_unlockSql.BackColor = Color.OrangeRed;
                    label24.Text = "SQL is unlocked Now...";
                    btn_unlockSql.Text = "Lock SQL";
                    sqlOpen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);


                }


            }
            else
            {
                await CreateLoginTrigger(txt_ServerIP.Text, txt_DB.Text, Utility.DBPass, "'" + Utility.ToInsecureString(Utility.DBPass) + "'");

                btn_unlockSql.BackColor = Color.Red;
                label24.Text = "";
                btn_unlockSql.Text = "Unlock SQL";
                ////locksql
                sqlOpen = false;
            }
        }

        private async Task PutMaintenancePlan(string address, string db, SecureString pass, string pathToBackUp, string mirrorBackUp)
        {
            var textCommand = string.Format(@"USE msdb ;  
                                                    EXEC dbo.sp_add_job  
                                                        @job_name = N'Weekly Sinad Data Backup' ;  
                                                    EXEC sp_add_jobstep  
                                                        @job_name = N'Weekly Sinad Data Backup',  
                                                        @step_name = N'Set database to read only',  
                                                        @subsystem = N'TSQL',  
                                                        @command = N'BACKUP DATABASE Sinad TO DISK=''d:\\ertest.bak''',   
                                                        @retry_attempts = 5,  
                                                        @retry_interval = 5 ;  
                                                    EXEC dbo.sp_add_schedule  
                                                        @schedule_name = N'RunWeekly',  
                                                        @freq_type = 8, 
                                                        @freq_interval=1, 
                                                        @active_start_time = 171500 ;  
                                                    USE msdb ;  
                                                    EXEC sp_attach_schedule  
                                                        @job_name = N'Weekly Sinad Data Backup',  
                                                        @schedule_name = N'RunWeekly';  
                                                    EXEC dbo.sp_add_jobserver  
                                                        @job_name = N'Weekly Sinad Data Backup';  
  
                                                    EXEC dbo.sp_add_job  
                                                        @job_name = N'Daily Sinad Data Backup' ;  
  
                                                    EXEC sp_add_jobstep  
                                                        @job_name = N'Daily Sinad Data Backup',  
                                                        @step_name = N'Set database to read only',  
                                                        @subsystem = N'TSQL',  
                                                        @command = N'BACKUP DATABASE Sinad  TO DISK=''d:\\ertest.bak'' WITH DIFFERENTIAL',   
                                                        @retry_attempts = 5,  
                                                        @retry_interval = 5 ;  
  
                                                    EXEC dbo.sp_add_schedule  
                                                        @schedule_name = N'RunDaily',  
                                                        @freq_type = 4,  
                                                        @freq_interval=1,

                                                    @active_start_time = 171500 ;  
                                                    USE msdb ;  
  
                                                    EXEC sp_attach_schedule  
                                                        @job_name = N'Daily Sinad Data Backup',  
                                                        @schedule_name = N'RunDaily';  
  
                                                    EXEC dbo.sp_add_jobserver  
                                                        @job_name = N'Daily Sinad Data Backup';");
            SqlConnection conn = new SqlConnection(Utility.MakeConnectionStr(address, db, pass));
            SqlCommand command = new SqlCommand(textCommand, conn);
            try
            {
              
                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
                
                MessageBox.Show("با موفقیت انجام شد");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                conn.Close();
            }
        }

      
      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Enabled = checkBox1.Checked ? true : false;
           
        }

        

        private async void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (sqlOpen)
            {
               await  CreateLoginTrigger(txt_ServerIP.Text, txt_DB.Text, 
                    Utility.DBPass,
                    "'" + 
                    Utility.ToInsecureString(Utility.DBPass) +
                    "'");
            }

            Application.ExitThread();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                TinyCode.Enabled = true;
                textBox14.Enabled = false;

            }
            else
            {
                TinyCode.Enabled = false;
                textBox14.Enabled = true;
                textBox16.Enabled = true;

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                TinyCode.Enabled = true;
                textBox14.Enabled = false;

            }
            else
            {
                TinyCode.Enabled = false;
                textBox14.Enabled = true;
                textBox16.Enabled = true;

            }

        }

        private async void Button10_Click_4(object sender, EventArgs e)
        {
            try
            {
               var internetDateTime=  await Utility.GetDateTimeFromInternetAsync();
               //MessageBox.Show(dateTime.ToLongDateString());

                PersianCalendar s = new PersianCalendar();
                var systemDateTime = DateTime.Now;
                //MessageBox.Show(now.ToLongDateString());
                var differene = internetDateTime - systemDateTime;
                var comp = differene.CompareTo(new TimeSpan(0, 30, 0));
                if (comp==1 )
                {
                    MessageBox.Show("ساعت سیستم تنظیم نمی باشد" );
                }

                var cName=Environment.MachineName;
                var fileName=string.Format("{0}_{1}.txt",cName,internetDateTime.ToShortDateString().Replace('/',',')+"_"+internetDateTime.ToShortTimeString().Replace(':','_'));

                File.WriteAllText(fileName,cName);
                 
                //string res= await Utility.PutFileInFTP(fileName,"test");
                

               // MessageBox.Show(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطایی رخ داده\n"+ex.Message);
            }
        }

       

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            chk_copyDbToHost.Enabled = chk_copyToHost.Checked ? true : false;
        }

       
    }
}