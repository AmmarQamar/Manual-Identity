//using AspNetCore.Reporting;
using Manual_Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
/*
using Microsoft.Reporting.NetCore;*/

namespace Manual_Identity.Controllers
{
    
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        public ReportController(AppDbContext _context,IWebHostEnvironment _webHostEnvironment)
        {
            this._context = _context;
            this._webHostEnvironment = _webHostEnvironment;
        }
      

        public JsonResult Print()
        {
            try
            {

                //string mimtype = "";
                //int extension = 1;
                //var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\StudentReport.rdlc";
                ////string ss = @"C: \Users\Huzaifa\source\repos\Manual Identity\Manual_Identity(26 12pm CURD done)\Manual_Identity\Manual_Identity\wwwroot\Reports\StudentReport.rdlc";
                //Dictionary<string, string> parameters = new Dictionary<string, string>();

                //parameters.Add("rp1", "Welcome");
                //var localReport = new LocalReport(path);
                ////var products = _context.Students.ToList();
                ////AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(ss);
                ////localReport.AddDataSource("DataSet1", products);
                //var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
                //return File(result.MainStream, "application/pdf");
                var html = "this is my html";
                var pdfBytes = PdfSharpConvert(html);
                return Json(new { filename = "myFile.pdf", message = Convert.ToBase64String(pdfBytes) });
            }
            catch(Exception ex)
            {
                return null;
            }

        }
        private Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
        //public IActionResult Print()
        //{
        //    SqlConnection con=new SqlConnection("DefaultConnection");
        //    string renderFormat = "PDF";
        //    string extension = "pdf";
        //    string mimetype = "application/pdf";
        //    using var report = new LocalReport();
        //    DataTable dt = new DataTable();

        //        dt.Columns.Add("StudentName");
        //        dt.Columns.Add("FatherName");
        //        dt.Columns.Add("Email");
        //        dt.Columns.Add("CourseId");
        //        dt.Columns.Add("AdmissionDate");
        //        dt.Columns.Add("AdmissionYear");
        //        dt.Columns.Add("Address");
        //        dt.Columns.Add("ContactNo");
        //        //dt.Columns.Add("PhotoPath");

        //        DataRow row;
        //        for (int i = 101; i <= 120; i++)
        //        {
        //            row = dt.NewRow();
        //            row["StudentName"] = "Ammar Qamar " + i;
        //            row["FatherName"] = "Qamar Zaman";
        //            row["Eamil"] = "amaar@gmail.com";
        //            row["CourseId"] = "24";
        //            row["AdmissionDate"] = "12-06-2022";
        //            row["AdmissionYear"] = "1-06-2022";
        //            row["Address"] = "Sadiqabad";
        //            row["ContactNo"] = "1-06-2022";

        //            dt.Rows.Add(row);
        //        }
        //    report.DataSources.Add(new ReportDataSource("dsStudent", dt));

        //    return dt;

        //    }

        //DataTable student = new DataTable();
        //string select_query = "Select *from Students";
        //SqlDataAdapter dataAdapter = new SqlDataAdapter(select_query,D);
        //DataSet ds=new DataSet();
        //var da = _context.Students.ToList();
        //ds.Tables.Add();
        //var dt = new DataTable();
        //dt = GetStudentList();
        //report.DataSources.Add(new ReportDataSource("dsStudent", dt));
        //return View();
    }

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

    }

