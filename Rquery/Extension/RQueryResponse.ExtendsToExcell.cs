using System.Linq;
using System.IO;
using System.Data;
using System.Text;
using System.Reflection;
using ClosedXML.Excel;

namespace RebelQuery.Core
{
    using Interfaces;
    

    public partial class RQueryResponse<T> : IExtension
    {
        public IXLWorkbook ToExcell()
        {
            var workbook = new XLWorkbook();

            if (this.IsSuccessful & this.Content.Count >= 0)
            {
                var sheetName = this.Content.Count > 0 ? this.Content.FirstOrDefault().GetType().Name:"nullResult";
                
                
                workbook.AddWorksheet(sheetName);
                var ws = workbook.Worksheet(sheetName);
                int row =2;
                PropertyInfo[] props = new PropertyInfo[] { };

                foreach ( var item in this.Content )
                {
                    props = item.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

                    for (int col =1, prop =0; prop < props.Count(); col++, prop++)
                    {
                        ws.Cell(1, col).Value = props[prop].Name;
                        ws.Cell(row, col).Value = props[prop].GetValue(item);
                    }

                    ws.Row(row).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    if(row%2 != 0)
                        ws.Row(row).Style.Fill.BackgroundColor = XLColor.LightGray;

                    row++;
                }

                ws.Row(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(1,1,1, props.Count()).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();


            }

            return workbook;
        }

    }
}