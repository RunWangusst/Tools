using CommonUI;
using Microsoft.Win32;
using Report;
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

namespace DBDictionaryExport
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ExportBtn(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog()
            {
                Title = "导出数据库设计文档",
                Filter = "word文件(*.docx)|*.docx", //设置文件类型
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (saveFileDialog.ShowDialog() != true)
                return;
            try
            {
                CircularAnimation.Instance().Begin();

                string viewPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                     "Data", "Template", "DatabaseTemplate.doc");
                var res = await WordTemplateHelper.GenerateDocument(viewPath, saveFileDialog.FileName, path.Text);
                if (res)
                {
                    richText.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}  文件导出成功，路径为：{saveFileDialog.FileName}\r\n");
                    //richText.CaretPosition = richText.Document.ContentEnd;
                    richText.ScrollToEnd();
                    // Get the current caret position.
                    TextPointer caretPos = richText.CaretPosition;

                    // Set the TextPointer to the end of the current document.
                    caretPos = caretPos.DocumentEnd;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }
            finally
            {
                CircularAnimation.Instance().Stop();
            }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files(.csv)|*.csv"
            };
            if (openFileDialog.ShowDialog() != true) return;

            path.Text = openFileDialog.FileName;
        }

        private void path_TextChanged(object sender, TextChangedEventArgs e)
        {
            // path 路径为空，不允许导出
            exportBtn.IsEnabled = !string.IsNullOrWhiteSpace(path.Text);
        }
    }
}
