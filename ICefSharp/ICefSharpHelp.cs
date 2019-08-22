using ICefSharp.Model;
using System;

namespace ICefSharp
{
    public interface ICefSharpHelp
    {
        /// <summary>
        /// 加载网址
        /// </summary>
        /// <param name="url"></param>
        void LoadUrl(string url);
        #region 事件
        event EventHandler<string> AddressChanged;
        event EventHandler<string> StatusMessage;
        event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
        event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;
        //event EventHandler<FrameLoadEventArgs> FrameLoadEnd;
        //event EventHandler<FrameLoadEventArgs> FrameLoadStart;
        event EventHandler<LoadErrorEventArgs> LoadError;
        event EventHandler<bool> IsBrowserInitializedChanged;
        event EventHandler<string> TitleChanged;
        #endregion 事件
    }
}
