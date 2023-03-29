// using System.Reflection;
// using ClosedXML.Excel;
// using ClosedXML.Graphics;
// using Humanizer;
// using Login.Data.DTO;
// using Login.Data.Models;

// namespace MBNOfficeSystem.Utils.Excel;

// public class CreateExcel
// {
//     public MemoryStream CreateClientExcel(IEnumerable<ClientDTO> clients)
//     {
//         using (var workbook = new XLWorkbook())
//         {
//             var worksheet = workbook.Worksheets.Add("Clients");

//             worksheet.Cell("A1").Value = "Sn.";
//             worksheet.Cell("B1").Value = "Client Name";
//             worksheet.Cell("C1").Value = "Status";
//             worksheet.Cell("D1").Value = "Total Branches";
//             worksheet.Cell("E1").Value = "Client Type";
//             worksheet.Cell("F1").Value = "PAN";
//             worksheet.Cell("G1").Value = "MBWIN Code";
//             worksheet.Cell("H1").Value = "Navigator ID";
//             worksheet.Cell("I1").Value = "Bank Code";
//             worksheet.Cell("J1").Value = "SMS Gateway Code";
//             worksheet.Cell("K1").Value = "Registration Date";

//             var index = 2;

//             foreach (var client in clients)
//             {
//                 worksheet.Cell($"A{index}").Value = index - 1;
//                 worksheet.Cell($"B{index}").Value = client.Name;
//                 worksheet.Cell($"C{index}").Value = client.Status.Humanize();
//                 worksheet.Cell($"D{index}").Value = client.NoOfBranches;
//                 worksheet.Cell($"E{index}").Value = client.ClientType.Humanize();
//                 worksheet.Cell($"F{index}").Value = client.Pan;
//                 worksheet.Cell($"G{index}").Value = client.MbwinCode;
//                 worksheet.Cell($"H{index}").Value = client.NavigatorId;
//                 worksheet.Cell($"I{index}").Value = client.BankCode;
//                 worksheet.Cell($"J{index}").Value = client.SMSGatewayCode;
//                 worksheet.Cell($"K{index}").Value = client.RegistrationDate;

//                 var statusCellColor = client.Status switch
//                 {
//                     ClientStatus.Active => XLColor.FromArgb(0x00AA00),
//                     ClientStatus.Discontinued => XLColor.FromArgb(0xAA0000),
//                     _ => XLColor.FromArgb(0x888888)
//                 };

//                 worksheet.Cell($"C{index}").Style.Fill.BackgroundColor = statusCellColor;

//                 index++;
//             }

//             worksheet.Columns().AdjustToContents();
//             var firstRowCells = worksheet.Rows().First().Cells();
//             foreach (var cell in firstRowCells)
//             {
//                 cell.Style.Font.Bold = true;
//             }

//             using (var stream = new MemoryStream())
//             {
//                 workbook.SaveAs(stream);

//                 return stream;
//             }
//         }
//     }
// }
