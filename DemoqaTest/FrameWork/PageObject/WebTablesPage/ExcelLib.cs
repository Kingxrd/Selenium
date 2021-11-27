using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;

namespace DemoqaTest.FrameWork.PageObject.WebTablesPage
{
    public class ExcelLib
    {
        private static DataTable ExcelToDataTable(string fileName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); 
            var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });                                                                           
            DataSet results = excelReader.AsDataSet();
            DataTableCollection table = result.Tables;
            DataTable resultTable = table["Sheet1"];
            
            return resultTable;
        }
        
        static List<Datacollection> dataCol = new List<Datacollection>();

        public static void PopulateInCollection(string fileName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            DataTable table = ExcelToDataTable(fileName);

           
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col <= 5; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString().Trim()
                        
                    };
                    
                    dataCol.Add(dtTable);
                }
            }
        }
        public  string ReadData(int rowNumber, string columnName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            try
            {
               
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }
    }
}
