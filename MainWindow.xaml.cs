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
        protected List<core.ViewTestClasGrid> clasGrids;
        protected List<core.ViewTest2Grid> viewTests;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = core.Uploader.ShowFileOpen("*.xlsx", "файл Excel (*.xlsx)|*.xlsx", "Выберите файл базы данных", true, 2);
            clasGrids = new();
            viewTests = new();
            for(int numberFile = 0; numberFile < openFile.FileNames.Length; numberFile++)
            {
                Excel excel = new();
                excel.FileOpen(openFile.FileNames[numberFile]);
                if (numberFile == 0)
                {
                    int j = 0;
                    for (int i = 1; i < excel.Table.Count; i++)
                    {
                        clasGrids.Add(new core.ViewTestClasGrid(Convert.ToInt32(excel.Table[i][j]), excel.Table[i][j + 1], excel.Table[i][j + 2]));
                    }
                    fstFile.ItemsSource = clasGrids;
                }
                else
                {
                    int p = 0;
                    for (int i = 1; i < excel.Table.Count; i++)
                    {
                        viewTests.Add(new core.ViewTest2Grid(Convert.ToInt32(excel.Table[i][p]), excel.Table[i][p + 1], excel.Table[i][p + 2]));
                    }
                    sndFile.ItemsSource = viewTests;
                }
            }
            fstFile.IsReadOnly = true;
            sndFile.IsReadOnly = true;
            fstFile.SelectionMode = DataGridSelectionMode.Extended;
            sndFile.SelectionMode = DataGridSelectionMode.Extended;
            GC.Collect();

#if DEBUG
            ConsoleHelper.AllocConsole();
            Console.WriteLine(fstFile.Columns[0].Header);
            Console.ReadKey();
            ConsoleHelper.FreeConsole();
#endif
        }

        private void btnSelectColumn(object sender, RoutedEventArgs e)
        {

        }
    }
}
