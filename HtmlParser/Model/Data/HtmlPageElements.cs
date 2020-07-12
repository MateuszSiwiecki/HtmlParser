using System.Collections.Generic;
using Model.HtmlScratchDataModel;

namespace Model.Data
{
    public class HtmlPageElements
    {
        private string[] headers;
        private Aside[] asides;
        private Href[] hrefs;
        private Stack<EnumHtmlElements> elements;
    }

}
