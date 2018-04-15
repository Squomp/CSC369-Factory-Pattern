using FactoryLibrary;
using FactoryLibrary.HTML;
using FactoryLibrary.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ComponentFactory> Components = new ObservableCollection<ComponentFactory>();
        private string codeToSave = "";

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
            Components = new ObservableCollection<ComponentFactory>();
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
            codeToSave = "";
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
            if (Components.Count > 0)
            {
                Components.RemoveAt(Components.Count - 1);
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Language.SelectedItem)
            {
                case Languages.HTML:
                    codeToSave += TheExecutioner.StartHTML();
                    Components.ToList().ForEach(x => codeToSave += x.GenerateCode());
                    codeToSave += TheExecutioner.EndHTML();
                    TheExecutioner.WriteAndRunHTML(codeToSave);
                    break;
                case Languages.WPF:
                    codeToSave += TheExecutioner.StartWPF();
                    Components.ToList().ForEach(x => codeToSave += x.GenerateCode());
                    codeToSave += TheExecutioner.EndWPF();
                    TheExecutioner.WriteAndRunXAML(codeToSave);
                    break;
                default:
                    break;
            }
            codeToSave = "";
        }
    }
}
