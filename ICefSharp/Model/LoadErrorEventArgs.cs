namespace ICefSharp.Model
{
    public class LoadErrorEventArgs
    {
        public LoadErrorEventArgs(int ErrorCode, string FailedUrl, string ErrorText)
        {
            this.ErrorCode = ErrorCode;
            this.FailedUrl = FailedUrl;
            this.ErrorText = ErrorText;
        }
        public int ErrorCode { get; }
        public string FailedUrl { get; }

        public string ErrorText { get; }
    }
}
