using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary
{
    public static class FileIO
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

            using (StreamReader r = new StreamReader(path))
            {
                XamlReader.Load(r);
            }
        }
    }
}