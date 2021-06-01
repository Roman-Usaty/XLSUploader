using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                            List<core.WorkListS> workListS, List<core.RegistrySoftSoniir> registrySoftSoniirs)
        {
            InitializeComponent();
            ColumnNames = columnName;
            NameFile = namefile;
            resultList = new List<List<string>>();
            Loaded += ResultWindow_Loaded;
            int i = 1;
            resultList = from WorkList in workListS
                         from Registry in registrySoftSoniirs
                         let fstWork = WorkList.IsTryRegex(WorkList.GetProperties(columnName[0]), Registry.GetKeyComparer(Registry.GetProperties(columnName[1])))
                         where fstWork == true
                         select new { Id = i++, WorkList.Name, WorkList.Version, WorkList.LicenseType,
                         WorkList.Count, WorkList.ValiditiPeriod, WorkList.InstallPlace, WorkList.IsMicrosoft,
                         RegistryName = Registry.Name, Registry.Owner, Registry.Function, 
                         Registry.StartDate, Registry.Code, Registry.IsRussia};
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
