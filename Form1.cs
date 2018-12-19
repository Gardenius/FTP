using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Server_text.Text = "testftp123.cba.pl";
            Username_text.Text = "ftptest1234";
            Password_text.Text = "Ftptest1234";
            Port_text.Text = "21";
        }
        private Socket FTPSocket = null, DataSock = null;
        bool Logged = false, Changed = false;
        private int Bytes, StatusCode, Port;
        private Byte[] Buffer = new Byte[512];
        private string StatusMessage = "", Result = "", Server = "", UserName = "", Password = "", Path = "/";
        private string[] Msg;
        private void Status_text_TextChanged(object sender, EventArgs e)
        {
            Status_text.ScrollToCaret();
        }

        private void Connect_btn_Click(object sender, EventArgs e)
        {
            treeView.Nodes[0].Nodes.Clear();
            Server = Server_text.Text;
            UserName = Username_text.Text;
            Password = Password_text.Text;
            Port = int.Parse(Port_text.Text);
            Login();

            if (Logged)
            {
                ParseDirNames(treeView.Nodes[0]);
            }
        }

        private void Login()
        {
            if (Logged)
                CloseConnection();
            IPAddress remoteAddress = null;
            IPEndPoint addressEndPoint = null;
            Status_text.AppendText("Opening Connection to: " + Server + "\n");

            try
            {
                FTPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Status_text.AppendText("Resolving IP Address\n");
                remoteAddress = Dns.GetHostEntry(Server).AddressList[0];
                Status_text.AppendText("IP Address Found -> " + remoteAddress.ToString() + "\n");
                addressEndPoint = new IPEndPoint(remoteAddress, Port);
                Status_text.AppendText("EndPoint Found -> " + addressEndPoint.ToString() + "\n");
                FTPSocket.Connect(addressEndPoint);
                SendCommand("USER " + UserName);
                SendCommand("PASS " + Password);
                Logged = true;
                Status_text.AppendText("Connected to " + Server + "\n");
            }
            catch (Exception ex)
            {
                if (FTPSocket != null && FTPSocket.Connected)
                {
                    FTPSocket.Close();
                }
                Status_text.AppendText("Couldn't connect to remote server. " + ex.Message + "\n");
                return;
            }
            ReadResponse();
            ChangeDir(Path);

        }
        private void CloseConnection()
        {
            if (FTPSocket != null)
            {
                SendCommand("QUIT");
            }
            LogOut();
        }

        private void LogOut()
        {
            if (FTPSocket != null)
            {
                FTPSocket.Close();
                FTPSocket = null;
            }
            Logged = false;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode.Index != -1 && !string.Equals(treeView.SelectedNode.Text, "/"))
            {
                treeView.SelectedNode.Nodes.Clear();
                SendCommand("CWD " + (treeView.SelectedNode.Tag.ToString()));
                SendCommand("PWD");
                Changed = true;
                if (!Changed)
                    return;
                ParseDirNames(treeView.SelectedNode);
            }
        }

        private void SendCommand(string msg)
        {
            Byte[] CommandBytes = Encoding.ASCII.GetBytes((msg + "\r\n").ToCharArray());
            FTPSocket.Send(CommandBytes, CommandBytes.Length, 0);
            ReadResponse();
        }
        private void ReadResponse()
        {
            StatusMessage = "";
            Result = SplitResponse();
            StatusCode = int.Parse(Result.Substring(0, 3));
        }
        private string SplitResponse()
        {
            try
            {
                while (true)
                {
                    Bytes = FTPSocket.Receive(Buffer, Buffer.Length, 0);
                    StatusMessage += Encoding.ASCII.GetString(Buffer, 0, Bytes);
                    if (Bytes < Buffer.Length)
                        break;
                }
                string[] msg = StatusMessage.Split('\n');
                if (StatusMessage.Length > 2)
                    StatusMessage = msg[msg.Length - 2];
                else
                    StatusMessage = msg[0];
                if (!StatusMessage.Substring(3, 1).Equals(" "))
                    return SplitResponse();
                for (int i = 0; i < msg.Length - 1; i++)
                    Status_text.AppendText(msg[i] + "\n");
                return StatusMessage;

            }
            catch (Exception ex)
            {
                Status_text.AppendText("Status : ERROR. " + ex.Message + "\n");
                FTPSocket.Close();
                return "";
            }
        }
        private void ChangeDir(string Path)
        {
            if (!Logged)
            {
                Status_text.AppendText("Login First\n");
                Changed = false;
                return;
            }
            SendCommand("CWD " + Path);
            SendCommand("PWD");
            Path = StatusMessage.Split('"')[1];
            Status_text.AppendText("Current Working Directory is " + Path + "\n");
            Changed = true;
        }
        private void ParseDirNames(TreeNode ParentNode)
        {
            GetListFiles();
            Files_lst.Items.Clear();
            int Temp, Temp2, Temp3;
            string Temp_Type = "", Temp_Name = "";
            if (Msg.Length != 0)
            {
                for (int i = 0; i < Msg.Length - 1; i++)
                {
                    Temp_Type = "";
                    Temp = Msg[i].ToString().IndexOf("type");
                    Temp2 = Msg[i].ToString().IndexOf('=', Temp);
                    Temp3 = Msg[i].ToString().IndexOf(';', Temp2);
                    Temp_Type = Msg[i].Substring(Temp2 + 1, Temp3 - Temp2 - 1);
                    if (Temp_Type == "dir")
                    {
                        Temp = Msg[i].ToString().LastIndexOf(';');
                        Temp_Name = Msg[i].Substring(Temp + 1, Msg[i].Length - Temp - 1);
                        AddTreeNode(ParentNode, "dir", Temp_Name);
                    }
                    else if (Temp_Type == "file")
                    {
                        Temp = Msg[i].ToString().LastIndexOf(';');
                        Temp_Name = Msg[i].Substring(Temp + 1, Msg[i].Length - Temp - 1);
                        AddListServerFilesItem(treeView.SelectedNode.Tag + "/" + Temp_Name.Trim(' '), Temp_Name.Trim(' '));
                    }
                }
                treeView.Nodes[0].Expand();
            }
            else return;
        }
        private void AddTreeNode(TreeNode ParentNode, string NodeType, string Text)
        {
            TreeNode temp = new TreeNode();
            temp.Name = Text + "_";
            temp.Text = Text.Trim(' ');
            if (ParentNode.Text != @"/")
                temp.Tag = ParentNode.Tag.ToString().Trim(' ') + @"/" + Text.Trim(' ');
            else
                temp.Tag = @"/" + Text.Trim(' ');
            if (NodeType == "dir")
                temp.ImageIndex = 1;
            ParentNode.Nodes.Add(temp);
        }
        private void AddListServerFilesItem(string Path, string Name)
        {
            Files_lst.Items.Add(Name);
            Files_lst.Items[Files_lst.Items.Count - 1].SubItems.Add(FileSize(Path).ToString() + " Bytes");
        }
        private long FileSize(string FileName)
        {
            if (!Logged)
            {
                Status_text.AppendText("Login First\n");
                return 0;
            }
            SendCommand("SIZE " + FileName);
            long Filesize = long.Parse(Result.Substring(4));
            return Filesize;
        }
        public string[] GetListFiles()
        {
            DataSock = OpenSocketForTransfer();
            if (DataSock == null)
            {
                Status_text.AppendText("Socket Error\n");
                return Msg;
            }
            SendCommand("MLSD");
            StatusMessage = "";
            DateTime timeout = DateTime.Now.AddSeconds(30);
            while (timeout > DateTime.Now)
            {
                int Bytes = DataSock.Receive(Buffer, Buffer.Length, 0);
                StatusMessage += Encoding.ASCII.GetString(Buffer, 0, Bytes);
                if (Bytes < Buffer.Length) break;
            }
            Msg = StatusMessage.Replace("\r", "").Split('\n');
            DataSock.Close();
            if (StatusMessage.Contains("No files found"))
                Msg = new string[] { };
            ReadResponse();
            if (StatusCode != 226)
                Msg = new string[] { };
            return Msg;
        }


        private Socket OpenSocketForTransfer()
        {
            SendCommand("PASV");
            Socket tranferSocket = null;
            IPEndPoint ipEndPoint = null;
            int indx1 = Result.IndexOf('(');
            int indx2 = Result.IndexOf(')');
            string IpPort = Result.Substring((indx1 + 1), (indx2 - indx1) - 1);
            int[] Parts = new int[6];
            int PartCount = 0;
            string Buffer = "";
            for (int i = 0; i < IpPort.Length && PartCount <= 6; i++)
            {
                char chr = char.Parse(IpPort.Substring(i, 1));
                if (char.IsDigit(chr))
                    Buffer += chr;
                else if (chr != ',')
                {
                    Status_text.AppendText("Wrong PASV result -> " + Result);
                    return null;
                }
                else
                {
                    if (chr == ',' || i + 1 == IpPort.Length)
                    {
                        try
                        {
                            Parts[PartCount++] = int.Parse(Buffer);
                            Buffer = "";
                        }
                        catch (Exception)
                        {
                            Status_text.AppendText("Wrong PASV result: " + Result + "\n");
                            return null;
                        }
                    }
                }
            }
            Parts[PartCount] = int.Parse(Buffer);
            string ipAddress = Parts[0] + "." + Parts[1] + "." + Parts[2] + "." + Parts[3];
            int port = (Parts[4] << 8) + Parts[5];
            try
            {
                tranferSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                tranferSocket.Connect(ipEndPoint);
            }
            catch (Exception ex)
            {
                if (tranferSocket != null && tranferSocket.Connected) tranferSocket.Close();
                Status_text.AppendText("Status : Can't connect to remote server ->" + ex.Message + " \n");
                return null;
            }
            return tranferSocket;
        }
    }
}
