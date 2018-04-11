using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary
{
    abstract public class ComponentFactory
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftMargin { get; set; }
        public int TopMargin { get; set; }
        public string Content { get; set; }

        abstract public string GenerateCode();
    }
}
