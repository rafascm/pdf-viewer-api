using Microsoft.EntityFrameworkCore;

namespace PDFViewerApi.Models
{
    public class PdfContext : DbContext
    {
        public PdfContext(DbContextOptions<PdfContext> options) : base(options) { }
        public DbSet<PdfFile> PdfFiles { get; set; }

        public void Populate()
        {
            PdfFiles.Add(new PdfFile
            {
                Name = "sample",
                Path = @"D:\GitHub\unico-times\unico-sign\PDFViewerApi\docs\sample.pdf"
            });

            PdfFiles.Add(new PdfFile
            {
                Name = "genki",
                Path = @"D:\GitHub\unico-times\unico-sign\PDFViewerApi\docs\genki.pdf"
            });

            PdfFiles.Add(new PdfFile
            {
                Name = "owasp",
                Path = @"D:\GitHub\unico-times\unico-sign\PDFViewerApi\docs\owasp.pdf"
            });

            SaveChanges();
        }
    }
}