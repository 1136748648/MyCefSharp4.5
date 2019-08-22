using CefSharp;
using CefSharp.WinForms;
using ICefSharp;
using System;
using System.Windows.Forms;

namespace CefSharpX64
{
    public partial class FCefSharpX64 : Form, ICefSharpHelp
    {
        private ChromiumWebBrowser chromeBrowser;
        public event EventHandler<string> AddressChanged;
        public event EventHandler<string> StatusMessage;
        public event EventHandler<ICefSharp.Model.ConsoleMessageEventArgs> ConsoleMessage;
        public event EventHandler<ICefSharp.Model.LoadingStateChangedEventArgs> LoadingStateChanged;
        public event EventHandler<ICefSharp.Model.LoadErrorEventArgs> LoadError;
        public event EventHandler<bool> IsBrowserInitializedChanged;
        public event EventHandler<string> TitleChanged;
        public FCefSharpX64()
        {
            InitializeComponent();
            var setting = new CefSettings();
            // 设置语言
            setting.Locale = "zh-CN";
            //cef设置userAgent
            setting.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            //配置浏览器路径
            setting.BrowserSubprocessPath = $"{CefSharpHelp.PathX64}\\CefSharp.BrowserSubprocess.exe";
            Cef.Initialize(setting);
            chromeBrowser = new ChromiumWebBrowser("https://www.baidu.com");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        public void LoadUrl(string url)
        {
            chromeBrowser.Load(url);
        }
    }
}
