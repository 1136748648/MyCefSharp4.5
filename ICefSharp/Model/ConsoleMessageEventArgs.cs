namespace ICefSharp.Model
{
    public class ConsoleMessageEventArgs
    {
        public ConsoleMessageEventArgs(string Message, string Source, int Line)
        {
            this.Message = Message;
            this.Source = Source;
            this.Line = Line;
        }
        public string Message { get; }
        public string Source { get; }
        public int Line { get; }
    }
}
