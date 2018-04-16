using FactoryLibrary.WPF;
using FactoryPattern;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FactoryLibrary
{
    public class WPFComponentFactory : ComponentFactory
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftMargin { get; set; }
        public int TopMargin { get; set; }
        public string Content { get; set; }

        public override ComponentFactory CreateComponent(Components comp, int height, int width, int leftMargin, int topMargin, string content)
        {
            WPFComponentFactory c = new WPFComponentFactory();
            switch (comp)
            {
                case Components.Label:
                    c = new WPFLabel(height, width, leftMargin, topMargin, content);
                    break;
                case Components.TextBox:
                    c = new WPFTextBox(height, width, leftMargin, topMargin, content);
                    break;
                default:
                    break;
            }
            return c;
        }

        public override string GenerateCode()
        {
            return "";
        }

        public override void Run(ObservableCollection<ComponentFactory> components)
        {
            string codeToSave = "";
            codeToSave += StartWPF();
            components.ToList().ForEach(x => codeToSave += x.GenerateCode());
            codeToSave += EndWPF();
            WriteAndRunXAML(codeToSave);
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
            //child.Preview = root;
            child.Content = root;
            child.ShowDialog();
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
