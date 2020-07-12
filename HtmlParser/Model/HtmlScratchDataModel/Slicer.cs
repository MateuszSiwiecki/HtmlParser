using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;
using Model.Data;

namespace Model.HtmlScratchDataModel
{
    public static class Slicer
    {

        private static string[] SliceStrings(string source)
        {
            return Regex.Split(source, "\\n|\r\n");
        }
    }
}
