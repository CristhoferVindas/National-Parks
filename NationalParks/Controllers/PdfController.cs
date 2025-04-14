using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using NationalParks.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using NationalParks.Data;
using Microsoft.EntityFrameworkCore;

namespace NationalParks.Controllers
{
    public class PdfController : Controller
    {
        private readonly IConverter _converter;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly AppDBContext _AppDBContext;

        public PdfController(IConverter converter, ICompositeViewEngine viewEngine, AppDBContext appDBContext)
        {
            _converter = converter;
            _viewEngine = viewEngine;
            _AppDBContext = appDBContext;
        }
        // public IActionResult DescargarPdf()
        // {
        //     // Simulamos datos, podés traerlos desde tu DB
        //     var model = new List<PayReport>
        // {
        //     new PayReport { CardType = "Visa", TotalCommission = 123.45M },
        //     new PayReport { CardType = "MasterCard", TotalCommission = 67.89M }
        // };

        //     // Renderizamos la vista Razor a HTML
        //     string html = RenderViewToString("PayReportView", model);

        //     var pdfDoc = new HtmlToPdfDocument()
        //     {
        //         GlobalSettings = {
        //         PaperSize = PaperKind.A4,
        //         Orientation = Orientation.Portrait,
        //         DocumentTitle = "Reporte de Comisiones"
        //     },
        //         Objects = {
        //         new ObjectSettings()
        //         {
        //             HtmlContent = html
        //         }
        //     }
        //     };

        //     var pdf = _converter.Convert(pdfDoc);
        //     return File(pdf, "application/pdf", "pay-report.pdf");
        // }
        private string RenderViewToString(string viewName, object model)
        {
            var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

            if (!viewResult.Success)
                throw new FileNotFoundException($"Vista '{viewName}' no encontrada.");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions()
                );

                viewResult.View.RenderAsync(viewContext).Wait();
                return sw.ToString();
            }
        }
        [HttpPost]
        public async Task<IActionResult> GeneratePayReportPdf(DateOnly initialDate, DateOnly finalDate)
        {
            var resultado = await _AppDBContext.Tickets
                .Where(t => t.SaleDate >= initialDate && t.SaleDate <= finalDate)
                .GroupBy(t => new { t.CardNavigation.CardType, t.CardNavigation.Commission })
                .Select(g => new
                {
                    CardType = g.Key.CardType,
                    TotalComision = g.Sum(t => t.Price * g.Key.Commission)
                })
                .ToListAsync();

            List<PayReport> payReports = resultado.Select(r => new PayReport
            {
                CardType = r.CardType,
                TotalCommission = r.TotalComision
            }).ToList();

            string html = RenderViewToString("PayReportView", payReports);

            var pdfDoc = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    DocumentTitle = $"Commission Report ({initialDate} - {finalDate})"
                },
                Objects = {
            new ObjectSettings()
            {
                HtmlContent = html
            }
        }
            };

            var pdf = _converter.Convert(pdfDoc);
            return File(pdf, "application/pdf", $"pay-report-{initialDate}-{finalDate}.pdf");
        }

        [HttpPost]
        public async Task<IActionResult> GenerateRatingReportPdf(string order)
        {
            var resultadoQuery = _AppDBContext.PlaceRatings
                .GroupBy(t => t.Place.Name)
                .Select(g => new
                {
                    PlaceName = g.Key,
                    Rating = g.Average(t => t.Stars)
                });

            if (order?.ToLower() == "asc")
            {
                resultadoQuery = resultadoQuery.OrderBy(x => x.Rating).Take(3); // Los 3 peores
            }
            else
            {
                resultadoQuery = resultadoQuery.OrderByDescending(x => x.Rating); // Mejores
            }

            var resultado = await resultadoQuery.ToListAsync();

            List<RatingReport> ratingReports = resultado.Select(r => new RatingReport
            {
                PlaceName = r.PlaceName,
                AverageRating = (decimal)r.Rating
            }).ToList();

            string html = RenderViewToString("RatingReportView", ratingReports);

            var pdfDoc = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    DocumentTitle = $"Rating Report - {(order?.ToUpper() == "ASC" ? "Peores Valorados" : "Mejor Valorados")}"
                },
                Objects = {
            new ObjectSettings()
            {
                HtmlContent = html
            }
        }
            };

            var pdf = _converter.Convert(pdfDoc);
            return File(pdf, "application/pdf", $"rating-report.pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
