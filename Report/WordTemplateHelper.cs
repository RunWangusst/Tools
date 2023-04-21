using Report.Helpers;
using Report.Models;
using SharpDocx;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Report
{
    public static class WordTemplateHelper
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr _lopen(string pathName, int readWrite);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        private const int OF_READWRITE = 2;
        private const int OF_SHARE_DENY_NONE = 0x480;
        private static readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        public static async Task<bool> GenerateDocument(string viewPath, string documentPath, string sourceDataPath)
        {
            try
            {
                if (FileIsOpen(documentPath))
                {
                    MessageBox.Show(documentPath + "已打开,请先关闭");
                    return false;
                }
                //// 写入测试数据
                //CreateTestData();
                //sourceDataPath = @"C:\Users\\Administrator\Desktop\aaa.csv";
                // 读取 csv 文件
                var s = CSVFileHelper.Instance().ConvertClass<ColumnModel>(sourceDataPath);
                var group = s.GroupBy(t => t.TablePhysicalName);
                DbReportModel dbReportModel = new DbReportModel();
                dbReportModel.ReportSubjectAreas = new List<ReportSubjectArea>();
                ReportSubjectArea subjectArea = new ReportSubjectArea();
                dbReportModel.ReportSubjectAreas.Add(subjectArea);
                subjectArea.ReportTables = new List<ReportTable>();
                foreach (var g in group)
                {
                    ReportTable reportTable = new ReportTable
                    {
                        ReportAttributes = new List<ReportAttribute>()
                    };
                    foreach (var item in g)
                    {
                        reportTable.LogicalName = item.TableLogicalName;
                        reportTable.PhysicalName = item.TablePhysicalName;

                        ReportAttribute reportAttribute = new ReportAttribute
                        {
                            PhysicalName = item.PhysicalName,
                            AlternativeName = item.LogicalName,
                            PK = item.PK,
                            NotNull = item.NotNull,
                            PhysicalDataType = item.PhysicalDataType,
                            Description = item.Description
                        };

                        reportTable.ReportAttributes.Add(reportAttribute);
                    }

                    subjectArea.ReportTables.Add(reportTable);
                }

                await Task.Run(() =>
                {
                    var document = DocumentFactory.Create(viewPath, dbReportModel);
                    //var stream = document.Generate();
                    document.Generate(documentPath);
                });
                var result = MessageBox.Show("导出成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    // open doc file

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }


        private static void CreateTestData()
        {
            List<ColumnModel> test = new List<ColumnModel>();
            for (int i = 0; i < 10; i++)
            {
                test.Add(new ColumnModel()
                {
                    TableLogicalName = $"L_{i}",
                    TablePhysicalName = $"P_{i}",
                    LogicalName = $"LName_{i}",
                    PhysicalName = $"PNmae_{i}",
                    PK = i / 4 == 0 ? "Y" : "N",
                    NotNull = i / 2 == 0 ? "Y" : "N",
                    PhysicalDataType = "char"
                });
            }

            CSVFileHelper.Instance().Save<ColumnModel>(test, @"C:\Users\\Administrator\Desktop\aaa.csv");
        }

        public static bool FileIsOpen(string pathName)
        {
            if (!File.Exists(pathName))
            {
                return false;
            }
            IntPtr handle = _lopen(pathName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (handle == HFILE_ERROR)
            {
                return true;
            }

            CloseHandle(handle);
            return false;
        }


        private static void CreateReportAttribute(ReportTable table, ReportSubjectArea reportSubjectArea, ReportTable reportTable)
        {
            int physicalOrder = 1;
        }
        //设置字体样式
        //private static XWPFParagraph SetCellText(XWPFDocument doc, XWPFTable table, XWPFParagraph pRowCellCell, string setText, bool isBold)
        //{
        //    //table中的文字格式设置  
        //    CT_P para = new CT_P();
        //    XWPFParagraph pCell = new XWPFParagraph(para, table.Body);
        //    XWPFRun run = pRowCellCell.Runs[0];
        //    pCell.Alignment = ParagraphAlignment.CENTER;
        //    pCell.VerticalAlignment = TextAlignment.CENTER;
        //    XWPFRun r1c1 = pCell.CreateRun();
        //    r1c1.SetText(setText);
        //    r1c1.FontSize = run.FontSize;
        //    r1c1.FontFamily = run.FontFamily;
        //    r1c1.IsBold = isBold;
        //    r1c1.TextPosition = run.TextPosition;
        //    return pCell;
        //}

    }
}
