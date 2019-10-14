using ActiveUp.Net.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSec
{
    public partial class Form2 : Form
    {
        static int retry = 0;
        public Form2()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var mailRepository = new MailRepository(
            //               "imap.gmail.com",
            //               993,
            //               true,
            //               "bastanteb@gmail.com",
            //               ""
            //           );

            //    var emailList = mailRepository.GetAllMails("inbox");

            //    foreach (ActiveUp.Net.Mail.Message email in emailList)
            //    {
            //        Console.WriteLine("<p>{0}: {1}</p><p>{2}</p>", email.From, email.Subject, email.BodyHtml.Text);
            //        if (email.Attachments.Count > 0)
            //        {
            //            foreach (MimePart attachment in email.Attachments)
            //            {
            //                Console.WriteLine("<p>Attachment: {0} {1}</p>", attachment.ContentName, attachment.ContentType.MimeType);
            //            }
            //        }
            //    }

                //Pop3.Pop3Client client = new Pop3.Pop3Client();
                // client.Connect("pop.gmail.com", "dehghany.m", "", 995,false,true);
                // "pop.gmail.com", 995, true, "Username@gmail.com", "password");
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //SmtpServer.Port = 587;
                //SmtpServer.EnableSsl = true;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("dehghany.m@gmail.com", "");
                //SmtpServer.Send("Me@m.com", "you@m.com", "Greeting", "Salute");
                //   SmtpClient c=new SmtpClient() 
           // }
                //catch(Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                label2.Text = "";
             if (retry++ > 3) { Application.ExitThread(); }
            if (textBox1.Text.Length<8) {
                label2.Text="!!خطا";
                textBox1.Text = "";
                return;

            }

            try
            {

                if (await Utility.VerifyHash(textBox1.Text, await Utility.GetPassFromFTP(textBox2.Text)) == true) // ConfigurationSettings.AppSettings.Get("cred")) == true)
                {
                    this.Hide();
              
                    Form1 frm = new Form1();
                    Utility.HostPass = Utility.ToSecureString(textBox2.Text);
                  
                    frm.Show();
                }
                else
                {
                    label2.Text = "!!خطا";
                    textBox1.Text = "";
                }
            }
            catch (WebException exception)
            {
                label2.Text = "خطا در اتصال";
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
                textBox1.Text = "";
            }

        }

        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
