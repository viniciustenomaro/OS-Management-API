using API.Model;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;

namespace API.Services
{
    public class FileService
    {
        public byte[] Excel(List<Pessoa> pessoas)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Users");
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = "Id";
            worksheet.Cell(currentRow, 2).Value = "Nome";
            worksheet.Cell(currentRow, 3).Value = "Salario";
            worksheet.Cell(currentRow, 4).Value = "Custo";


            List<Pessoa> mainList = new List<Pessoa>();
            foreach (var item in pessoas)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = item.Id;
                worksheet.Cell(currentRow, 2).Value = item.Nome;
                worksheet.Cell(currentRow, 3).Value = item.Salario;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return content;
        }
    }
}
