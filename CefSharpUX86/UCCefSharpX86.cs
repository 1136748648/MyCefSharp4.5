using CefSharp;
using CefSharp.WinForms;
using ICefSharp;
using System;
using System.Windows.Forms;

namespace CefSharpUX86
{
    public partial class UCCefSharpX86 : UserControl, ICefSharpHelp
    {
        private ChromiumWebBrowser chromeBrowser;
        public event EventHandler<string> AddressChanged;
        public event EventHandler<string> StatusMessage;
        public event EventHandler<ICefSharp.Model.ConsoleMessageEventArgs> ConsoleMessage;
        public event EventHandler<ICefSharp.Model.LoadingStateChangedEventArgs> LoadingStateChanged;
        public event EventHandler<ICefSharp.Model.LoadErrorEventArgs> LoadError;
        public event EventHandler<bool> IsBrowserInitializedChanged;
        public event EventHandler<string> TitleChanged;
        public UCCefSharpX86(string url)
        {
            InitializeComponent();

            var setting = new CefSettings();
            // 设置语言
            setting.Locale = "zh-CN";
            //cef设置userAgent
            setting.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            //配置浏览器路径
            setting.BrowserSubprocessPath = $"{CefSharpHelp.PathX86}\\CefSharp.BrowserSubprocess.exe";
            Cef.Initialize(setting, true, true);
            chromeBrowser = new ChromiumWebBrowser(url);
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.AddressChanged += (sender, e) => { AddressChanged?.Invoke(sender, e.Address); };
            chromeBrowser.StatusMessage += (sender, e) => { StatusMessage?.Invoke(sender, e.Value); };
            chromeBrowser.ConsoleMessage += (sender, e) => { ConsoleMessage?.Invoke(sender, new ICefSharp.Model.ConsoleMessageEventArgs(e.Message, e.Source, e.Line)); };
            chromeBrowser.LoadingStateChanged += (sender, e) => { LoadingStateChanged?.Invoke(sender, new ICefSharp.Model.LoadingStateChangedEventArgs(e.CanGoForward, e.CanGoBack, e.CanReload, e.IsLoading)); };
            chromeBrowser.LoadError += (sender, e) => { LoadError?.Invoke(sender, new ICefSharp.Model.LoadErrorEventArgs((int)e.ErrorCode, e.FailedUrl, e.ErrorText)); };
            chromeBrowser.IsBrowserInitializedChanged += (sender, e) => { IsBrowserInitializedChanged?.Invoke(sender, e.IsBrowserInitialized); };
            chromeBrowser.TitleChanged += (sender, e) => { TitleChanged?.Invoke(sender, e.Title); };
        }


        public void LoadUrl(string url)
        {
            chromeBrowser.Load(url);
        }
    }
}
