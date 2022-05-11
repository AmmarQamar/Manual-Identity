using Manual_Identity.Data;
using Manual_Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.WebForms;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Manual_Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(AppDbContext _context,IWebHostEnvironment _webHostEnvironment)
        {
            this._context = _context;
            this._webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult PrintReport(int id)
        {
            int stu_id = id;
            List<StudentViewModel> students = _context.Students.ToList();
            string imageParam = "";
            string renderFormat = "PDF";
            string extension = "pdf";
            string mimetype = "application/pdf";
            using var report = new LocalReport();
            var products = _context.Students.ToList();
            var res = from s in students
                      where s.StudentId == id
                      select s;
            report.DataSources.Add(new ReportDataSource("Student", res));
            report.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\Reports\\StudentReport.rdlc";
            var pdf = report.Render(renderFormat);
            return File(pdf, "application/pdf");
            // below statment for downloading
            //return File( pdf,mimetype, "report." + extension);
     

        }

    }
}