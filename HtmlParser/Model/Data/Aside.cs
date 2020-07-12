namespace Model.Data
{
    public class Aside : AdvanceMarkups
    {
        private readonly string _type;
        private readonly string _title;

        public override string GetHtmlMarkUp()
            => $@"<aside cat=""{_type}"">
                    <header>{_title}</header?
                    <main>{text}</main>
                 </aside>";

        public Aside(string text, string type, string title) : base(text)
        {
            this._type = type;
            this._title = title;
        }
    }
}
