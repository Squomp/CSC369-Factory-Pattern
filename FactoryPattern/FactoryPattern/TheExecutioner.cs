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

            StreamReader sr = new StreamReader(path);
            StackPanel root = XamlReader.Load(sr.BaseStream) as StackPanel;

            //UIElement item = (UIElement)(XamlReader.Parse(componentCode));

            ChildWindow child = new ChildWindow();
            //child.Preview.Children.Add(item);
            child.Preview = root;
            child.ShowDialog();
        }

        internal static string StartHTML()
        {
            return "<!DOCTYPE html><html><head></head><body>";
        }

        internal static string EndHTML()
        {
            return "</body></html>";
        }

        internal static string StartWPF()
        {
            return "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">";
        }

        internal static string EndWPF()
        {
            return "</StackPanel>";
        }
    }
}
