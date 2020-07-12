namespace Model.Data
{
    public class Href
    {
        public Href(string refTo, string text)
        {
            
        }
        public string refTo;
        public string text;

        public string GetHtmlMarkUp() => $@"<a href=""{refTo}"">{text}</a>";
    }
}
