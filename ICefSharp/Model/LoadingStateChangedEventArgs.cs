namespace ICefSharp.Model
{
    public class LoadingStateChangedEventArgs
    {
        public LoadingStateChangedEventArgs(bool CanGoForward, bool CanGoBack, bool CanReload, bool IsLoading)
        {
            this.CanGoForward = CanGoForward;
            this.CanGoBack = CanGoForward;
            this.CanReload = CanGoForward;
            this.IsLoading = CanGoForward;
        }
        public bool CanGoForward { get; }
        public bool CanGoBack { get; }
        public bool CanReload { get; }
        public bool IsLoading { get; }
    }
}
