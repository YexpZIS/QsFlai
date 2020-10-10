using QsFlai.Preferences;
using System;
using System.Collections.Generic;
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

namespace QsFlai.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EditableLabel.xaml
    /// </summary>
    public partial class EditableLabel : UserControl
    {
        private Gap settings;
        private Window window;
        private int id;

        public EditableLabel()
        {
            InitializeComponent();
        }
        
        public void Constructor(Gap settings,Window window, int id)
        {
            this.settings = settings;
            this.window = window;
            this.id = id;
        }

        private void Textbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            label.Content = "";
            textbox.Opacity = 1;
        }

        public void setText(string text)
        {
            label.Content = text;
            textbox.Text = text;

            settings.border.Name = text;
            MainWindow.Save();
        }
        public string getText()
        {
            return textbox.Text;
        }
        public void setTextColor(Color color)
        {
            label.Foreground = new SolidColorBrush(color);
        }
        public void setTextFontFamily(FontFamily font)
        {
            label.FontFamily = font;
        }
        public void setFontSize(double size, int textHeigth)
        {
            label.FontSize = size;
            label.Height = textHeigth;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить данное окно?\n\nНет - закрыть окно.\nДа - удалить окно.\nОтмена - не закрывать окно.",
                "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Удаяем окно
                MainWindow.removeWindow(id);
                window.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                // Скрываем окно
                window.Close();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.addNewWindow();
        }

        private void textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            textbox.Opacity = 0;
            setText(textbox.Text);
        }
    }
}
