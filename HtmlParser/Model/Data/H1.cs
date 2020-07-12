namespace Model.Data
{
    public class H1 : AdvanceMarkups
    {
        public override string GetHtmlMarkUp() => $@"<h1 id=""nX"">{text}</h1>";

        public H1(string text) : base(text)
        { }
    }
}