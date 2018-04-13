using FactoryLibrary;
using FactoryLibrary.HTML;
using FactoryLibrary.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FactoryPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ComponentFactory> Components = new List<ComponentFactory>();

        public MainWindow()
        {
            InitializeComponent();
            SetComboBoxBinding();
        }

        private void SetComboBoxBinding()
        {
            Language.ItemsSource = Enum.GetValues(typeof(Languages)).Cast<Languages>();
        }

        private void SetListBoxBinding()
        {
            ComponentList.ItemsSource = Components;
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Components = new List<ComponentFactory>();
            switch (Language.SelectedItem)
            {
                case Languages.HTML:
                    Component.ItemsSource = Enum.GetValues(typeof(HTMLComponents)).Cast<HTMLComponents>();
                    break;
                case Languages.WPF:
                    Component.ItemsSource = Enum.GetValues(typeof(WPFComponents)).Cast<WPFComponents>();
                    break;
                default:
                    break;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int height = Int32.Parse(Height.Text);
            int width = Int32.Parse(Width.Text);
            int left = Int32.Parse(Left.Text);
            int top = Int32.Parse(Top.Text);
            string content = Content.Text;
            if (Language.SelectedItem.Equals(Languages.HTML))
            {
                switch (Component.SelectedItem)
                {
                    case HTMLComponents.TextArea:
                        Components.Add(new HTMLTextAreaFactory(height, width, left, top, content));
                        break;
                    case HTMLComponents.TextBox:
                        Components.Add(new HTMLTextBoxFactory(height, width, left, top, content));
                        break;
                    case HTMLComponents.Label:
                        Components.Add(new HTMLLabelFactory(height, width, left, top, content));
                        break;
                    case HTMLComponents.Button:
                        Components.Add(new HTMLButtonFactory(height, width, left, top, content));
                        break;
                    default:
                        break;
                }
            }
            else if (Language.SelectedItem.Equals(Languages.WPF))
            {
                switch (Component.SelectedItem)
                {
                    case WPFComponents.Label:
                        Components.Add(new WPFLabelFactory(height, width, left, top, content));
                        break;
                    case WPFComponents.TextBox:
                        Components.Add(new WPFTextBoxFactory(height, width, left, top, content));
                        break;
                    default:
                        break;
                }
            }
            ComponentList.ItemsSource = Components;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Components.RemoveAt(Components.Count - 1);
            ComponentList.ItemsSource = Components;
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
