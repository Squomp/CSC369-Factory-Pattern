using FactoryLibrary.HTML;
using FactoryPattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary
{
    public class HTMLComponentFactory : ComponentFactory
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftMargin { get; set; }
        public int TopMargin { get; set; }
        public string Content { get; set; }

        public override ComponentFactory CreateComponent(Components comp, int height, int width, int leftMargin, int topMargin, string content)
        {
            HTMLComponentFactory c = new HTMLComponentFactory();
            switch (comp)
            {
                case Components.TextArea:
                    c = new HTMLTextArea(height, width, leftMargin, topMargin, content);
                    break;
                case Components.TextBox:
                    c = new HTMLTextBox(height, width, leftMargin, topMargin, content);
                    break;
                case Components.Label:
                    c = new HTMLLabel(height, width, leftMargin, topMargin, content);
                    break;
                case Components.Button:
                    c = new HTMLButton(height, width, leftMargin, topMargin, content);
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
            codeToSave += StartHTML();
            components.ToList().ForEach(x => codeToSave += x.GenerateCode());
            codeToSave += EndHTML();
            WriteAndRunHTML(codeToSave);
        }

        private void WriteAndRunHTML(string componentCode)
        {
            string path = "code.html";
            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(componentCode);
            }
            System.Diagnostics.Process.Start(path);
        }

        private static string StartHTML()
        {
            return "<!DOCTYPE html><html><head></head><body>";
        }

        private static string EndHTML()
        {
            return "</body></html>";
        }
    }
}
