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
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        protected string[] ColumnNames { get; set; }
        protected string[] NameFile { get; set; }

        protected dynamic resultList;
        public ResultWindow(string[] columnName, string[] namefile,
                            List<core.ViewTestClasGrid> clasGrids, List<core.ViewTest2Grid> viewTests)
        {
            InitializeComponent();
            ColumnNames = columnName;
            NameFile = namefile;
            resultList = new List<List<string>>();
            Loaded += ResultWindow_Loaded;
            int i = 1;
            resultList = from grid in clasGrids
                         join view in viewTests on grid.GetProperties(columnName[0]) equals view.GetProperties(columnName[1])
                         select new { Id = i++, grid.NameComp, grid.Program, view.Owner };
        }

        private void ResultWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Result.ItemsSource = resultList;
            if (Result.Columns.Count == 0)
            {
                MessageBox.Show("Не удалось выполнить слияние", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                SelectColumnWindow selectColumn = new();
                selectColumn.Show();
                Close();
                return;
            }
        }

        private void btnSaveExml(object sender, RoutedEventArgs e)
        {

        }
    }
}
