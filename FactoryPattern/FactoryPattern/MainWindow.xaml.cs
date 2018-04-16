using FactoryLibrary;
using System;
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
        private ObservableCollection<ComponentFactory> comps = new ObservableCollection<ComponentFactory>();

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
            ComponentList.ItemsSource = comps;
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comps = new ObservableCollection<ComponentFactory>();
            switch (Language.SelectedItem)
            {
                case Languages.HTML:
                    Component.ItemsSource = Enum.GetValues(typeof(Components)).Cast<Components>();
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
                HTMLComponentFactory f = new HTMLComponentFactory();
                comps.Add(f.CreateComponent((Components)Component.SelectedItem, height, width, left, top, content));
            }
            else if (Language.SelectedItem.Equals(Languages.WPF))
            {
                WPFComponentFactory f = new WPFComponentFactory();
                comps.Add(f.CreateComponent((Components)Component.SelectedItem, height, width, left, top, content));
            }
            ComponentList.ItemsSource = comps;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (comps.Count > 0)
            {
                comps.RemoveAt(comps.Count - 1);
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Language.SelectedItem)
            {
                case Languages.HTML:
                    HTMLComponentFactory f = new HTMLComponentFactory();
                    f.Run(comps);
                    break;
                case Languages.WPF:
                    WPFComponentFactory w = new WPFComponentFactory();
                    w.Run(comps);
                    break;
                default:
                    break;
            }
        }
    }
}
