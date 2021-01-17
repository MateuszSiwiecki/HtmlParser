using System;
using System.Collections.Generic;
using System.Linq;
using Model.HtmlScratchDataModel;

namespace Model
{
    public static class Parser
    {
        public static string[] ParseToHtml(string[] input)
            => input.Select(x => x.ReplaceMarkups()).ToArray();
    }
}
