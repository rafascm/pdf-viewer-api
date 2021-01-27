using Microsoft.EntityFrameworkCore;

namespace PDFViewerApi.Models
{
    public class PdfContext : DbContext
    {
        public PdfContext(DbContextOptions<PdfContext> options) : base(options)
        {
            PdfFiles.Add(new PdfFile
            {
                Name = "sample",
                Path = "/docs/sample.pdf"
            });
            SaveChanges();
        }
        public DbSet<PdfFile> PdfFiles { get; set; }
    }
}