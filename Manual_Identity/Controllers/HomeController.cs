using Manual_Identity.Data;
using Manual_Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.WebForms;
using System.Data;
using System.Diagnostics;
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

        public IActionResult PrintReport()
        {
            string renderFormat = "PDF";
            string extension = "pdf";
            string mimetype = "application/pdf";
            using var report = new LocalReport();
            var products = _context.Students.ToList();
            //var dt = new DataTable();
            //dt = GetStudentList();
            report.DataSources.Add(new ReportDataSource("Student", products));
            report.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\Reports\\StudentReport.rdlc";
            var pdf = report.Render(renderFormat);
            return File(pdf, mimetype, "report." + extension);
        }
            //}
            //public DataTable GetStudentList()
            //{
            //    var dt = new DataTable();
            //    dt.Columns.Add("StudentName");
            //    dt.Columns.Add("FatherName");
            //    dt.Columns.Add("Email");
            //    dt.Columns.Add("CourseId");
            //    dt.Columns.Add("AdmissionDate");
            //    dt.Columns.Add("AdmissionYear");
            //    dt.Columns.Add("Address");
            //    dt.Columns.Add("ContactNo");
            //    //dt.Columns.Add("PhotoPath");

            //    DataRow row;
            //    for (int i = 101; i <= 120; i++)
            //    {
            //        row = dt.NewRow();
            //        row["StudentName"] = "Ammar Qamar " + i;
            //        row["FatherName"] = "Qamar Zaman";
            //        row["Eamil"] = "amaar@gmail.com";
            //        row["CourseId"] = "24";
            //        row["AdmissionDate"] = "12-06-2022";
            //        row["AdmissionYear"] = "1-06-2022";
            //        row["Address"] = "Sadiqabad";
            //        row["ContactNo"] = "1-06-2022";

            //        dt.Rows.Add(row);
            //    }
            //    return dt;

            //}

            public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}