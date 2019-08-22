using ICefSharp;
using ICefSharp.Model;
using System.Windows.Forms;

namespace CefSharpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = CefSharpHelp.PlateFormRunMode.ToString();
            ICefSharpHelp uC = null;
            string url = "www.baidu.com";
            if (CefSharpHelp.PlateFormRunMode == 64)
            {
                uC = new CefSharpUX64.UCCefSharpX64(url);
            }
            else
            {
                uC = new CefSharpUX86.UCCefSharpX86(url);
            }
            uC.AddressChanged += AddressChanged;
            uC.LoadError += LoadError;
            uC.ConsoleMessage += ConsoleMessage;
            var us = uC as UserControl;
            this.Controls.Add(us);
            us.Dock = DockStyle.Fill;
            //if (CefSharpHelp.PlateFormRunMode == 64)
            //{
            //    uC = new CefSharpX64.FCefSharpX64();
            //}
            //else
            //{
            //    uC = new CefSharpX86.FCefSharpX86();
            //}
            //var us = uC as Form;
            //us.Show();
            //us.Activate();
        }
        public void ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
        }
        public void LoadError(object sender, LoadErrorEventArgs e)
        {
        }
        public void AddressChanged(object sender, string e)
        {

        }

    }
}
