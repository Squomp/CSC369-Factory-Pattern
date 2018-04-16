using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary.HTML
{
    public class HTMLTextArea : HTMLComponentFactory
    {
        public HTMLTextArea(int height, int width, int leftMargin, int topMargin, string content)
        {
            Height = height;
            Width = width;
            LeftMargin = leftMargin;
            TopMargin = topMargin;
            Content = content;
        }

        public override string GenerateCode()
        {
            string code = $"<textarea " +
                $"rows=\"{Height}px\" " +
                $"cols=\"{Width}px\" " +
                $"style=\"Margin:{TopMargin}px 0px 0px {LeftMargin}px\"> " +
                $"{Content}" +
                $"</textarea>";
            return code;
        }

        public override string ToString()
        {
            return "HTML TextArea";
        }
    }
}
