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

namespace XLSUploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<core.viewTestClasGrid> clasGrids = new()
            {
                new core.viewTestClasGrid() { NameComp = "test", Program = "farm" },
                new core.viewTestClasGrid() { NameComp = "test1", Program = "farm1" },
                new core.viewTestClasGrid() { NameComp = "test2", Program = "farm2" }
            };
            fstFile.ItemsSource = clasGrids;
        }
    }
}
