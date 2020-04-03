using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Xml;

namespace TDUWorldLauncher
{
    public class DxDiag
    {
        private EStatus _state;
        private string _b;
        private string _c;
        private XmlDocument _d;

        public DxDiag()
        {
            _state = EStatus.None;
            _b = null;
            _c = null;
            _d = null;
        }

        public EStatus Status
        {
            get
            {
                return _state;
            }
        }

        public string XmlPath
        {
            get
            {
                return _c;
            }
            set
            {
                _c = value;
            }
        }

        public bool CollectInfo()
        {
            if (string.IsNullOrEmpty(_c))
                return false;
            
            try
            {
                _b = Environment.GetFolderPath(Environment.SpecialFolder.System);
                if (!string.IsNullOrEmpty(_b))
                {
                    if (!File.Exists(_c))
                    {
                        _b += "\\dxdiag.exe";
                        if (!File.Exists(_b))
                        {
                            _state = EStatus.Failed;
                            return false;
                        }
                        Process process = new Process();
                        process.StartInfo.FileName = _b;
                        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(_c);
                        process.StartInfo.Arguments = "/whql:off /x " + _c;
                        process.Start();
                        do
                        {
                            Thread.Sleep(100);
                            process.Refresh();
                        }
                        while (!process.HasExited);
                    }
                    if (!File.Exists(_c))
                        return false;
                    _d = new XmlDocument();
                    using (FileStream fileStream = new FileStream(_c, FileMode.Open))
                    {
                        _d.Load(fileStream);
                        fileStream.Close();
                    }
                    if (_d.ChildNodes.Count <= 0)
                    {
                        _state = EStatus.Failed;
                        return false;
                    }
                    _state = EStatus.Ok;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            _state = EStatus.Failed;
            return false;
        }

        public string GetValue(string aStrSection, string aStrName)
        {
            if (!string.IsNullOrEmpty(aStrSection) && !string.IsNullOrEmpty(aStrName) && _d != null)
            {
                if (_state == EStatus.Ok)
                {
                    try
                    {
                        XmlNode xmlNode = _d.SelectSingleNode("//" + aStrSection + "/" + aStrName);
                        if (xmlNode != null)
                            return xmlNode.InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                    }
                    return null;
                }
            }
            return null;
        }

        public ulong GetValueUInt(string aStrSection, string aStrName)
        {
            try
            {
                string s = GetValue(aStrSection, aStrName);
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

        public enum EStatus
        {
            None,
            Failed,
            Ok,
        }
    }
}
