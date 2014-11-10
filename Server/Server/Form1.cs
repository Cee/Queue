using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace Server
{
    public partial class Form1 : Form
    {
        private static byte[] result = new byte[1024];
        private static int port = 23333;
        static Socket serverSocket;
        static Thread myThread;
        bool isRunning = false;
        private static int count = 0;
        private static int client = 0;
        private List<Socket> socketList = new List<Socket>();
        private List<Thread> threadList = new List<Thread>();

        private delegate void EventHandle(string str, string str2);

        public Form1()
        {
            InitializeComponent();
            this.stopButton.Enabled = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndServer();
            Thread.CurrentThread.Abort();
            System.Environment.Exit(0);
            Process.GetCurrentProcess().Kill();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            this.stopButton.Enabled = true;
            this.startButton.Enabled = false;
            StartServer();
        }

        private void stopButton_Click(object sender, System.EventArgs e)
        {
            this.startButton.Enabled = true;
            this.stopButton.Enabled = false;
            EndServer();
        }

        private void StartServer()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            try
            {
                serverSocket.Close();
                myThread.Abort();
            }
            catch
            {
                //do nothing
            }
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ip, port));
                serverSocket.Listen(1);
                myThread = new Thread(ListenClientConnect);
                Thread.CurrentThread.IsBackground = true;
                myThread.Start();
                this.consoleTextBox.Text += "服务器开始工作 监听端口为23333\n";
                isRunning = true;
            }
            catch (Exception e)
            {
                this.consoleTextBox.Text += "服务器开启失败\n";
            }
        }

        private void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                socketList.Add(clientSocket);
                client++;
                clientSocket.Send(Encoding.ASCII.GetBytes(client.ToString()));
                Invoke(new EventHandle(UpdateLinkStatus), clientSocket.RemoteEndPoint.ToString(), client.ToString());
                Thread receiveThread = new Thread(SendNumber);
                threadList.Add(receiveThread);
                receiveThread.Start(clientSocket);
            }
        }

        private void SendNumber(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            socketList.Add(myClientSocket);
            while (getRunningStatus())
            {
                try
                {
                    int receiveNumber = myClientSocket.Receive(result);
                    count++;
                    myClientSocket.Send(Encoding.ASCII.GetBytes(count.ToString()));
                    Invoke(new EventHandle(AddNumber), "", Encoding.ASCII.GetString(result, 0, receiveNumber));
                }
                catch (Exception ex)
                {
                    try
                    {
                        myClientSocket.Shutdown(SocketShutdown.Both);
                        myClientSocket.Close();
                    }
                    catch
                    {
                        // do nothing
                    }
                }
            }
        }
        private void UpdateLinkStatus(String port, String id)
        {
            this.consoleTextBox.Text += "端口为:" + port + "的客户端已连接，分配的编号为:" + id + "\n";
        }
        private void AddNumber(String port, String id)
        {
            this.consoleTextBox.Text += "编号" + id + "的客户端请求叫号, 编号为" + count.ToString() + "\n";
        }
        private void EndServer()
        {
            isRunning = false;
            for (int i = 0; i < socketList.Count; i++)
            {
                Socket s = socketList[i];
                if (s != null)
                {
                    try
                    {
                        s.Shutdown(SocketShutdown.Both);
                        s.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            for (int i = 0; i < threadList.Count; i++)
            {
                Thread t = threadList[i];
                if (t != null)
                {
                    t.Abort();
                }
            }
            socketList.Clear();
            threadList.Clear();
            serverSocket.Close();
            myThread.Abort();
            client = 0;
            this.consoleTextBox.Text += "服务器结束工作\n";
        }

        public bool getRunningStatus()
        {
            return this.isRunning;
        }
    }
}


