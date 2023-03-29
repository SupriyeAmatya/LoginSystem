// using Humanizer;
// using Login.Data.DTO;
// using Login.Data.DTO.Response;
// using QuestPDF.Fluent;
// using QuestPDF.Helpers;
// using QuestPDF.Infrastructure;
// using SkiaSharp;

// namespace MBNOfficeSystem.Utils.Pdf;

// public static class CreatePdf
// {
//     private static IContainer CellStyle(IContainer container) =>
//         container
//             .BorderBottom(1)
//             .BorderColor(Colors.Grey.Lighten2)
//             .PaddingVertical(4)
//             .PaddingHorizontal(4);

//     private static IContainer Cell(this IContainer container)
//     {
//         return container.Border(0.5f).Background("#88fea037").AlignCenter().Padding(5);
//     }

//     public static void LabelCell(this IContainer container, string text) =>
//         container.Cell().Text(text).FontSize(14).Bold();

//     private static void RoundedCellContainer(
//         this IContainer container,
//         string text,
//         string color
//     ) =>
//         container
//             .MinimalBox()
//             .Layers(layers =>
//             {
//                 layers.PrimaryLayer().Padding(10).Text(text);

//                 layers
//                     .Layer()
//                     .Canvas(
//                         (canvas, size) =>
//                         {
//                             using var paint = new SKPaint
//                             {
//                                 Color = SKColor.Parse(color),
//                                 IsStroke = true,
//                                 StrokeWidth = 1,
//                                 IsAntialias = true
//                             };

//                             canvas.DrawRoundRect(0, 0, 80, size.Height, 10, 10, paint);
//                         }
//                     );
//             });

//     public static Document CreateStaffWhereaboutsPdf(
//         IEnumerable<StaffWhereaboutPdfDto> staffData,
//         StaffWhereaboutCounts count
//     )
//     {
//         var imageBytes = File.ReadAllBytes("./Assets/mb_logo.png");

//         return Document.Create(
//             container =>
//                 container.Page(page =>
//                 {
//                     page.Size(PageSizes.A4);
//                     page.Margin(1, Unit.Centimetre);
//                     page.PageColor(Colors.White);
//                     page.DefaultTextStyle(x => x.FontSize(10));

//                     page.Header()
//                         .Column(column =>
//                         {
//                             column
//                                 .Item()
//                                 .ShowOnce()
//                                 .Width(250, Unit.Point)
//                                 .Height(60, Unit.Point)
//                                 .Image(imageBytes);
//                             column
//                                 .Item()
//                                 .ShowOnce()
//                                 .PaddingVertical(10)
//                                 .Table(table =>
//                                 {
//                                     table.ColumnsDefinition(column =>
//                                     {
//                                         column.ConstantColumn(100f);
//                                         column.ConstantColumn(100f);
//                                         column.ConstantColumn(100f);
//                                         column.ConstantColumn(100f);
//                                         column.ConstantColumn(100f);
//                                     });

//                                     table
//                                         .Cell()
//                                         .RoundedCellContainer($"Leave: {count.Leave}", "#a6a6a6");
//                                     table
//                                         .Cell()
//                                         .RoundedCellContainer($"Field: {count.Field}", "#fea037");
//                                     table
//                                         .Cell()
//                                         .RoundedCellContainer($"Late: {count.Late}", "#d42323");
//                                     table
//                                         .Cell()
//                                         .RoundedCellContainer($"Others: {count.Others}", "#353559");
//                                     table
//                                         .Cell()
//                                         .RoundedCellContainer(
//                                             $"W.F.H: {count.WorkFromHome}",
//                                             "#31719c"
//                                         );
//                                 });
//                             column
//                                 .Item()
//                                 .PaddingVertical(0.25f)
//                                 .Text("Staff Whereabouts.")
//                                 .SemiBold()
//                                 .FontSize(24)
//                                 .FontColor(Colors.Black);
//                         });

//                     page.Content()
//                         .PaddingVertical(0.75f, Unit.Centimetre)
//                         .Table(table =>
//                         {
//                             table.ColumnsDefinition(column =>
//                             {
//                                 column.ConstantColumn(30);
//                                 column.RelativeColumn(1.5f);
//                                 column.RelativeColumn();
//                                 column.RelativeColumn();
//                                 column.RelativeColumn();
//                                 column.RelativeColumn(1.5f);
//                             });

//                             table.Header(header =>
//                             {
//                                 header.Cell().Text("#").Bold();
//                                 header.Cell().Text("Staff Name").Bold();
//                                 header.Cell().Text("Department").Bold();
//                                 header.Cell().Text("Whereabout").Bold();
//                                 header.Cell().Text("Date").Bold();
//                                 header.Cell().Text("Remarks").Bold();

//                                 header
//                                     .Cell()
//                                     .ColumnSpan(6)
//                                     .PaddingVertical(4)
//                                     .BorderBottom(1)
//                                     .BorderColor(Colors.Black);
//                             });

//                             var index = 1;

//                             var groupedStaffData = staffData
//                                 .GroupBy(s => s.Date)
//                                 .Select(s => new { Date = s.Key, Data = s.ToList() });

//                             foreach (var staffItem in groupedStaffData)
//                             {
//                                 table
//                                     .Cell()
//                                     .ColumnSpan(6)
//                                     .LabelCell(staffItem.Date.ToString("dddd, dd MMMM yyyy"));
//                                 foreach (var info in staffItem.Data)
//                                 {
//                                     table.Cell().Element(CellStyle).Text($"{index}");
//                                     table.Cell().Element(CellStyle).Text(info.StaffName);
//                                     table.Cell().Element(CellStyle).Text(info.Department);
//                                     table
//                                         .Cell()
//                                         .Element(CellStyle)
//                                         .Text(info.Whereabout.Humanize());
//                                     table.Cell().Element(CellStyle).Text(info.Date.ToString("d"));
//                                     table.Cell().Element(CellStyle).Text(info.Remarks);

//                                     index++;
//                                 }
//                             }
//                         });

//                     page.Footer()
//                         .AlignCenter()
//                         .Text(x =>
//                         {
//                             x.Span("Page ");
//                             x.CurrentPageNumber();
//                         });
//                 })
//         );
//     }
// }
