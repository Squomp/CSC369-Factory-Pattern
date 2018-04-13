using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FactoryPattern
{
    public static class TheExecutioner
    {
        public static void WriteAndRunHTML(string componentCode)
        {
            string path = "code.html";
            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(componentCode);
            }
            System.Diagnostics.Process.Start(path);
        }

        public static void WriteAndRunXAML(string componentCode)
        {
            string path = "code.xaml";
            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(componentCode);
            }

            UIElement root;
            using (FileStream s = new FileStream(path, FileMode.Open))
            {
                root = (UIElement)XamlReader.Load(s);
            }

            ChildWindow child = new ChildWindow();
            child.Preview = (Grid)root;
            child.ShowDialog();
        }
    }
}
