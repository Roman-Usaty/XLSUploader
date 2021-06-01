using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ExcelHelper;
#if DEBUG
using XLSUploader.debugHelper;
#endif

namespace XLSUploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected List<core.WorkListS> workListS;
        protected List<core.RegistrySoftSoniir> registrySoftSoniirs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = core.Uploader.ShowFileOpen("*.xlsx", "файл Excel (*.xlsx)|*.xlsx", "Выберите файл базы данных", true, 2);
            workListS = new();
            registrySoftSoniirs = new();
            for(int numberFile = 0; numberFile < openFile.FileNames.Length; numberFile++)
            {
#pragma warning disable CS0436 // Тип конфликтует с импортированным типом
                Excel excel = new();
#pragma warning restore CS0436 // Тип конфликтует с импортированным типом
                excel.FileOpen(openFile.FileNames[numberFile]);
                if (numberFile == 0)
                {
                    int j = 0;
                    for (int i = 3; i < excel.Table.Count; i++)
                    {
                        workListS.Add(new core.WorkListS(excel.Table[i][j], excel.Table[i][j + 1], excel.Table[i][j + 2],
                            excel.Table[i][j + 3], excel.Table[i][j + 4], 
                            excel.Table[i][j + 5], excel.Table[i][j + 6], excel.Table[i][j + 7]));
                    }
                    fstFile.ItemsSource = workListS;
                    core.GlobalFileData.FileData.Add(workListS);
                }
                else
                {
                    int p = 0;
                    for (int i = 3; i < excel.Table.Count; i++)
                    {
                        registrySoftSoniirs.Add(new core.RegistrySoftSoniir(i.ToString(),excel.Table[i][p], excel.Table[i][p + 1], 
                            excel.Table[i][p + 2], excel.Table[i][p + 3], 
                            excel.Table[i][p + 4], excel.Table[i][p + 5]));
                    }
                    sndFile.ItemsSource = registrySoftSoniirs;
                    core.GlobalFileData.FileData.Add(registrySoftSoniirs);
                }
            }
            

            fstFile.IsReadOnly = true;
            sndFile.IsReadOnly = true;
            fstFile.SelectionMode = DataGridSelectionMode.Extended;
            sndFile.SelectionMode = DataGridSelectionMode.Extended;
            GC.Collect();
            ShowSelectCol.Visibility = Visibility.Visible;
        }

        private void btnSelectColumn(object sender, RoutedEventArgs e)
        {
            string[] fstFileHeader = new string[fstFile.Columns.Count];
            string[] sndFileHeader = new string[sndFile.Columns.Count];
            for (int i = 0; i < fstFile.Columns.Count; i++)
            {
                fstFileHeader[i] = (string)fstFile.Columns[i].Header;
            }
            for(int i = 0; i < sndFile.Columns.Count; i++)
            {
                sndFileHeader[i] = (string)sndFile.Columns[i].Header;
            }
            window.SelectColumnWindow selectColumn = new(fstFileHeader, sndFileHeader);
            selectColumn.Show();
            Close();
        }
    }
}
