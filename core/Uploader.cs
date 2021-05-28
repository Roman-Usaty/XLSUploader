using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XLSUploader.core
{
    public static class Uploader
    {
        public static OpenFileDialog ShowFileOpen(string defExt, string filter, string title, bool multiSelect, int countFile)
        {
            OpenFileDialog openFile = new();
            openFile.DefaultExt = defExt;
            openFile.Multiselect = multiSelect;
            openFile.Filter = filter;
            openFile.Title = title;
            if (!(bool)openFile.ShowDialog())
            {
                return null;
            }

            if (openFile.FileNames.Length <= (countFile - 1) || openFile.FileNames.Length > countFile)
            {
                MessageBox.Show($"Выберите {countFile} файл(а)", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            return openFile;
        }
    }
}
