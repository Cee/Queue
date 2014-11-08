using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading; 

namespace Client
{
    public partial class Form1 : Form
    {
        private static byte[] result = new byte[1024];
        Socket clientSocket;
        private String clientID;

        private delegate void EventHandle(string str);

        public Form1()
        {
            InitializeComponent();
            this.getNumberButton.Enabled = false;
        }

        public void LinkServer(String serverIP)
        {
            IPAddress ip = IPAddress.Parse(serverIP);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 23333)); //配置服务器IP与端口  
                int receiveLength = clientSocket.Receive(result);
                this.clientID = Encoding.ASCII.GetString(result, 0, receiveLength);
                this.linkStatus.Text = "连接服务器成功,编号为" + this.clientID;
                this.getNumberButton.Enabled = true;
                this.linkButton.Enabled = false;
            }
            catch
            {
                this.linkStatus.Text = "连接服务器失败";
                this.getNumberButton.Enabled = false;
                this.linkButton.Enabled = true;
                return;
            }
        }

        public void SendMessage()
        {
            try  
            {  
                string sendMessage = this.clientID.ToString();  
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));  
                int receiveLength = clientSocket.Receive(result);
                Invoke(new EventHandle(UpdateNumber), Encoding.ASCII.GetString(result, 0, receiveLength));
            }  
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    Invoke(new EventHandle(ErrorNumber), "");
                    this.getNumberButton.Enabled = false;
                    this.linkButton.Enabled = true;
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }    
        }

        private void UpdateNumber(String number)
        {
            this.myNumber.Text = "号码:" + number;
        }

        private void ErrorNumber(String number)
        {
            this.myNumber.Text = "叫号失败";
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            LinkServer(this.serverIPtextBox.Text);
        }

        private void getNumberButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }  
    }
}
