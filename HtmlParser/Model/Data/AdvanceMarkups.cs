namespace Model.Data
{
    public abstract class AdvanceMarkups
    {
        protected AdvanceMarkups(string text)
        {
            this.text = text;
        }

        protected readonly string text;

        public abstract string GetHtmlMarkUp();
    }
}
