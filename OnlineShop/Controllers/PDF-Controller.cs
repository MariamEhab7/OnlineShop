using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDF_Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GeneratePDf(Guid itemId)
        {
            var document = new PdfDocument();
            string HtmlContent = "<h1>Hello</h1>";
            PdfGenerator.AddPdfPages(document, HtmlContent, PageSize.A4);
            byte[]? response = null;
            using(MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }

            string FileName = "Item_" + itemId + ".pdf";
            return File(response, "application/pdf", FileName);

        }
    }
}
