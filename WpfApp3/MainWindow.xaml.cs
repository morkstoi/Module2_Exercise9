using Microsoft.Win32;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textbox != null)
            {
                textbox.FontFamily = new FontFamily(fontName);
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (textbox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));
                textbox.FontSize = fontSize;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textbox.FontWeight == FontWeights.Normal)
            {
                textbox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textbox.FontWeight = FontWeights.Normal;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textbox.FontStyle == FontStyles.Normal)
            {
                textbox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textbox.FontStyle = FontStyles.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(textbox.TextDecorations.Count ==0)
            {
                textbox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textbox.TextDecorations.RemoveAt(0);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textbox != null)
            {
                textbox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textbox != null)
            {
                textbox.Foreground = Brushes.Red;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textbox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textbox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Uri uri = new Uri(themes.SelectedIndex == 0 ? "LightTheme.xaml" : "DarkTheme.xaml",UriKind.Relative);
            ResourceDictionary themeDictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
        }
    }
}
