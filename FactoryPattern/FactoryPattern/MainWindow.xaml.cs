using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FactoryPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
