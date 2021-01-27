using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDFViewerApi.Models;

namespace PDFViewerApi.Controllers
{
    [Route("api/pdf-viewer")]
    [ApiController]
    public class PdfFilesController : ControllerBase
    {
        private readonly PdfContext _context;
        public PdfFilesController(PdfContext context)
        {
            _context = context;
        }

        // GET: api/PdfFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdfFile>>> GetPdfFiles()
        {
            return await _context.PdfFiles.ToListAsync();
        }

        // GET: api/PdfFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdfFile>> GetPdfFile(long id)
        {
            var pdfFile = await _context.PdfFiles.FindAsync(id);

            if (pdfFile == null) return NotFound();

            return pdfFile;
        }

        // POST: api/PdfFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PdfFile>> PostPdfFile(PdfFile pdfFile)
        {
            _context.PdfFiles.Add(pdfFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPdfFile", new { id = pdfFile.Id }, pdfFile);
        }
    }
}
