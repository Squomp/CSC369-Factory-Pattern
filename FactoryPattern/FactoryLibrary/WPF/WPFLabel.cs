using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary.WPF
{
    public class WPFLabel : WPFComponentFactory
    {
        public WPFLabel(int height, int width, int leftMargin, int topMargin, string content)
        {
            Height = height;
            Width = width;
            LeftMargin = leftMargin;
            TopMargin = topMargin;
            Content = content;
        }

        public override string GenerateCode()
        {
            string code = $"<Label " +
                $"Height=\"{Height}\" " +
                $"Width=\"{Width}\" " +
                $"Margin=\"{LeftMargin} {TopMargin} 0 0\">" +
                $"{Content}</Label>";
            return code;
        }

        public override string ToString()
        {
            return "WPF Label";
        }
    }
}
