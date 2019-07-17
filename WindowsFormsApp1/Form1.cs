using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ServiceReference1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MyServiceClient client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Print(string text)
        {
            richTextBox1.Text += text + "\n\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void Print(Exception ex)
        {
            Print(ex.Message);
            Print(ex.Source);
            Print(ex.StackTrace);
        }

        private void Create_New_Client()
        {
            if (client == null)
                try
                {
                    Try_To_Create_New_Client();
                }
                catch(Exception ex)
                {
                    Print(ex);
                    Print(ex.InnerException);
                    client = null;
                }
            else
            {
                Print("Can't create a new client. The current Client is active.");
            }
        }

        private void Try_To_Create_New_Client()
        {
            try
            {

                NetTcpBinding binding = new NetTcpBinding(SecurityMode.Transport);

                binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

                string uri = "net.tcp://192.168.1.2:9002/MyService";

                EndpointAddress endpoint = new EndpointAddress(new Uri(uri));

                client = new MyServiceClient(binding, endpoint);

                client.ClientCredentials.Windows.ClientCredential.Domain = "";
                client.ClientCredentials.Windows.ClientCredential.UserName = "Vasya";
                client.ClientCredentials.Windows.ClientCredential.Password = "12345";

                Print("Creating new client ....");
                Print(endpoint.Uri.ToString());
                Print(uri);

                string test = client.Method1("test");

                if (test.Length < 1)
                {
                    throw new Exception("Проверка соединения не удалась");
                }
                else
                {
                    Print("test is OK  ! " + test);
                }

            }
            catch (Exception ex)
            {
                Print(ex);
                Print(ex.InnerException);
                client = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create_New_Client();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print("Sending message ...");
            string s = textBox1.Text;
            string x = "";
            if (client != null)
            {
                x = client.Method1(s);
                Print(x);
                x = client.Method2(s);
                Print(x);
            }
            else
            {
                Print("Error! Client does not exist!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                Print("Closing a client ...");
                client.Close();
                client = null;
            }
            else
            {
                Print("Error! Client does not exist!");
            }
            this.Close();
        }
    }
}
