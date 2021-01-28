using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDFViewerApi.Models;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Cors;

namespace PDFViewerApi.Controllers
{
    //[EnableCors("MyPolicy")]
    [Route("api/pdf-viewer")]
    [ApiController]
    public class PdfFilesController : ControllerBase
    {
        private readonly PdfContext _context;
        public PdfFilesController(PdfContext context)
        {
            _context = context;
            _context.Populate();
        }

        // GET: api/pdf-viewer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdfFile>>> GetPdfInfos()
        {
            return await _context.PdfFiles.ToListAsync();
        }

        // GET: api/pdf-viewer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPdfFile(long id)
        {
            PdfFile pdfFile = await _context.PdfFiles.FindAsync(id); 

            if (pdfFile == null) return NotFound();
             
            var dataBytes = System.IO.File.ReadAllBytes(pdfFile.Path);

            var dataStream = new MemoryStream(dataBytes);

            return new FileStreamResult(dataStream, "application/pdf");
        }
    }
}
