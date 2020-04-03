using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Xml;

namespace TDUWorldLauncher
{
    public class DxDiag
    {
        private DxDiag.eStatus State;
        private string b;
        private string c;
        private XmlDocument d;

        public DxDiag()
        {
            this.State = DxDiag.eStatus.None;
            this.b = (string)null;
            this.c = (string)null;
            this.d = (XmlDocument)null;
        }

        public DxDiag.eStatus Status
        {
            get
            {
                return this.State;
            }
        }

        public string XmlPath
        {
            get
            {
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }

        public bool CollectInfo()
        {
            if (string.IsNullOrEmpty(this.c))
                return false;
            
            try
            {
                this.b = Environment.GetFolderPath(Environment.SpecialFolder.System);
                if (!string.IsNullOrEmpty(this.b))
                {
                    if (!File.Exists(this.c))
                    {
                        this.b += "\\dxdiag.exe";
                        if (!File.Exists(this.b))
                        {
                            this.State = DxDiag.eStatus.Failed;
                            return false;
                        }
                        Process process = new Process();
                        process.StartInfo.FileName = this.b;
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(this.c);
                        process.StartInfo.Arguments = "/whql:off /x " + this.c;
                        process.Start();
                        do
                        {
                            Thread.Sleep(100);
                            process.Refresh();
                        }
                        while (!process.HasExited);
                    }
                    if (!File.Exists(this.c))
                        return false;
                    this.d = new XmlDocument();
                    using (FileStream fileStream = new FileStream(this.c, FileMode.Open))
                    {
                        this.d.Load((Stream)fileStream);
                        fileStream.Close();
                    }
                    if (this.d.ChildNodes.Count <= 0)
                    {
                        this.State = DxDiag.eStatus.Failed;
                        return false;
                    }
                    this.State = DxDiag.eStatus.Ok;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            this.State = DxDiag.eStatus.Failed;
            return false;
        }

        public string GetValue(string a_strSection, string a_strName)
        {
            if (!string.IsNullOrEmpty(a_strSection) && !string.IsNullOrEmpty(a_strName) && this.d != null)
            {
                if (this.State == DxDiag.eStatus.Ok)
                {
                    try
                    {
                        XmlNode xmlNode = this.d.SelectSingleNode("//" + a_strSection + "/" + a_strName);
                        if (xmlNode != null)
                            return xmlNode.InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                    }
                    return (string)null;
                }
            }
            return (string)null;
        }

        public ulong GetValueUInt(string a_strSection, string a_strName)
        {
            try
            {
                string s = this.GetValue(a_strSection, a_strName);
                if (string.IsNullOrEmpty(s))
                    return 0;
                for (int length = 0; length < s.Length; ++length)
                {
                    if (s[length] < '0' || s[length] > '9')
                    {
                        s = s.Substring(0, length);
                        break;
                    }
                }
                return ulong.Parse(s);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return 0;
        }

        public enum eStatus
        {
            None,
            Failed,
            Ok,
        }
    }
}
