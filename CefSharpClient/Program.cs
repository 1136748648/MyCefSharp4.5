using ICefSharp;
using System;
using System.Windows.Forms;

namespace CefSharpClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            var flag = CefSharpHelp.SetRuntimeBinding();
            //获得当前登录的Windows用户标示 
            //System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员,判断修改后是否需要重启
            //if ((!flag) || (Args.Length > 0 && Args[0].Equals("1") && principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator)))
            if (!flag)
            {
                //如果是管理员，则直接运行
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                //创建启动对象 
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //设置运行文件 
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行 
                startInfo.Verb = "runas";
                //设置启动参数 
                startInfo.Arguments = string.Join(" ", Args);
                //如果不是管理员，则启动UAC 
                System.Diagnostics.Process.Start(startInfo);
                //退出 
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
