using FactoryPattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary
{
    abstract public class ComponentFactory
    {
        abstract public ComponentFactory CreateComponent(Components comp, int height, int width, int leftMargin, int topMargin, string content);

        abstract public void Run(ObservableCollection<ComponentFactory> components);

        abstract public string GenerateCode();
    }
}
