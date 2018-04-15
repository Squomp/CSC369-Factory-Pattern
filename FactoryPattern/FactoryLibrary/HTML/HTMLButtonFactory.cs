using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary.HTML
{
    public class HTMLButtonFactory : ComponentFactory
    {
        public HTMLButtonFactory(int height, int width, int leftMargin, int topMargin, string content)
        {
            Height = height;
            Width = width;
            LeftMargin = leftMargin;
            TopMargin = topMargin;
            Content = content;
        }

        public override string GenerateCode()
        {
            string code = $"<button " +
                $"type=\"button\"" +
                $"style=\"Height:{Height}px;Width:{Width}px\" " +
                $"Margin=\"{TopMargin}px 0px 0px {LeftMargin}px\">" +
                $"{Content}</button>";
            return code;
        }

        public override string ToString()
        {
            return "HTML Button";
        }
    }
}
