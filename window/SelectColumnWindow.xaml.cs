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
using System.Windows.Shapes;

namespace XLSUploader.window
{
    /// <summary>
    /// Логика взаимодействия для SelectColumn.xaml
    /// </summary>
    public partial class SelectColumnWindow : Window
    {
        protected static string[] fstListBoxItem;
        protected static string[] sndListBoxItem;
        protected bool chkElement;
        protected string[] selectedColumns;
        protected string[] namesSelectedColumns;

        public SelectColumnWindow(string[] fstFileHeader, string[] sndFileHeader)
        {
            InitializeComponent();
            fstListBoxItem = fstFileHeader;
            sndListBoxItem = sndFileHeader;
            chkElement = false;
            selectedColumns = new string[2];
            namesSelectedColumns = new string[2];

            Loaded += SelectColumn_Loaded;
            fstFile.SelectionChanged += File_SelectionChanged;
            sndFile.SelectionChanged += File_SelectionChanged;
            sndFile.IsEnabled = false;
        }
        public SelectColumnWindow()
        {
            InitializeComponent();
            chkElement = false;
            selectedColumns = new string[2];
            namesSelectedColumns = new string[2];

            Loaded += SelectColumn_Loaded;
            fstFile.SelectionChanged += File_SelectionChanged;
            sndFile.SelectionChanged += File_SelectionChanged;
        }

        private void File_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            MessageBoxResult dialog = MessageBox.Show($"Вы уверены что хотите выбрать {listBox.SelectedItem}" +
                $" в качестве колонки слияния", "information", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (dialog != MessageBoxResult.Yes)
            {
                return;
            }

            if (chkElement)
            {
                selectedColumns[^1] = (string)listBox.SelectedItem;
                namesSelectedColumns[^1] = listBox.Name;
                ResultWindow resultWindow = new(selectedColumns, namesSelectedColumns,
                                                core.GlobalFileData.FileData[0] as List<core.ViewTestClasGrid>,
                                                core.GlobalFileData.FileData[1] as List<core.ViewTest2Grid>);
                resultWindow.Show();
                Close();
                return;
            }
            selectedColumns[0] = (string)listBox.SelectedItem;
            namesSelectedColumns[0] = listBox.Name;
            listBox.IsEnabled = false;
            sndFile.IsEnabled = true;
            _ = MessageBox.Show("Выберите вторую колонку", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            chkElement = true;
        }

        private void SelectColumn_Loaded(object sender, RoutedEventArgs e)
        {
            fstFile.ItemsSource = fstListBoxItem;
            sndFile.ItemsSource = sndListBoxItem;
        }
    }
}
