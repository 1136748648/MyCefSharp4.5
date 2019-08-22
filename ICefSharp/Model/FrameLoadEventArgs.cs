namespace ICefSharp.Model
{
    public class FrameLoadEventArgs
    {
        public string Url { get; }

        public int HttpStatusCode { get; set; }
    }
}
