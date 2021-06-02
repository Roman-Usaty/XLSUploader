using System;
using System.Collections;
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
using XLSUploader.core;

namespace XLSUploader.window
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        protected string[] ColumnNames { get; set; }
        protected string[] NameFile { get; set; }

        private List<ResultObject> viewList;
        private List<List<string>> resultList;
        public ResultWindow(string[] columnName, string[] namefile,
                            List<WorkListS> workListS, List<RegistrySoftSoniir> registrySoftSoniirs)
        {
            InitializeComponent();
            ColumnNames = columnName;
            NameFile = namefile;
            Loaded += ResultWindow_Loaded;

            viewList = new();
            resultList = new();

            for (int i = 0; i < workListS.Count; i++)
            {
                for(int p = 0; p < registrySoftSoniirs.Count; p++)
                {
                    if (workListS[i].IsTryRegex(workListS[i].GetProperties(columnName[0]), registrySoftSoniirs[p].GetKeyComparer(registrySoftSoniirs[p].GetProperties(columnName[1]))))
                    {
                        viewList.Add(new ResultObject
                        {
                            Id = (i + 1).ToString(),
                            Name = workListS[i].Name,
                            Version = workListS[i].Version,
                            LicenseType = workListS[i].LicenseType,
                            Count = workListS [i].Count,
                            ValiditiPeriod = workListS[i].ValiditiPeriod,
                            InstallPlace = workListS[i].InstallPlace,
                            IsMicrosoft = workListS[i].IsMicrosoft,
                            RegistryName = registrySoftSoniirs[p].Name,
                            Owner = registrySoftSoniirs[p].Owner,
                            Function = registrySoftSoniirs[p].Function,
                            StartDate = registrySoftSoniirs[p].StartDate,
                            Code = registrySoftSoniirs[p].Code,
                            IsRussia = registrySoftSoniirs[p].IsRussia
                        });
                    }
                }
            }
        }

        private void ResultWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Result.ItemsSource = viewList;
            if (Result.Columns.Count == 0)
            {
                _ = MessageBox.Show("Не удалось выполнить слияние", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                SelectColumnWindow selectColumn = new();
                selectColumn.Show();
                Close();
                return;
            }
        }

        private void btnSaveExml(object sender, RoutedEventArgs e)
        {
            Random random = new();
            ExcelHelper.Excel excel = new();
            excel.saveSucces += Excel_saveSucces;
            foreach (ResultObject @object in viewList)
            {
                resultList.Add(@object.GetList());
            }
            int rnd = random.Next(0, viewList.Count);
            excel.FileSave($"saveTable/{rnd.ToString().GetHashCode()}.xlsx", resultList);
        }

        private void Excel_saveSucces(string mess)
        {
            _ = MessageBox.Show(mess, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
