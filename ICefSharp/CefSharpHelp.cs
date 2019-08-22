using System;
using System.IO;
using System.Xml;

namespace ICefSharp
{
    public class CefSharpHelp
    {
        public static readonly string PathX64 = "x64_49";
        public static readonly string PathX86 = "x86_49";
        public static int PlateFormRunMode
        {
            get
            {
                if (IntPtr.Size == 8)
                {
                    return 64;
                }
                return 32;

            }
        }
        /// <summary>
        /// 修改程序配置文件 返回程序是否需要重启
        /// </summary>
        /// <returns>true:需要</returns>
        public static bool SetRuntimeBinding()
        {
            string path = $"{System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName}.config";// System.Environment.CurrentDirectory + "\\";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);
            manager.AddNamespace("bindings", "urn:schemas-microsoft-com:asm.v1");
            XmlNode root = doc.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode("//bindings:probing", manager);
            if (node != null)
            {
                var privatePath = node.GetAttribute("privatePath").Trim().TrimEnd(';');
                privatePath = string.IsNullOrEmpty(privatePath) ? "" : privatePath + ";";
                if (PlateFormRunMode == 64)
                {
                    if (privatePath.Contains(PathX64) && !privatePath.Contains(PathX86))
                    {
                        return false;
                    }
                    privatePath = privatePath.Replace(PathX64 + ";", "").Replace(PathX86 + ";", "");
                    node.SetAttribute("privatePath", $"{privatePath}{PathX64}");
                }
                else
                {
                    if (privatePath.Contains(PathX86) && !privatePath.Contains(PathX64))
                    {
                        return false;
                    }
                    privatePath = privatePath.Replace(PathX64 + ";", "").Replace(PathX86 + ";", "");
                    node.SetAttribute("privatePath", $"{privatePath}{PathX86}");
                }
            }
            doc.Save(path);
            return true;
        }
    }
}
