using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary.HTML
{
    public class HTMLTextAreaFactory : ComponentFactory
    {
        public HTMLTextAreaFactory(int height, int width, int leftMargin, int topMargin, string content)
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
                $"Margin=\"{TopMargin}px 0px 0px {LeftMargin}px\">" +
                $"{Content}" +
                $"<textarea>";
            return code;
        }
    }
}
