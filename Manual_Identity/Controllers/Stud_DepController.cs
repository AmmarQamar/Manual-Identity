using Manual_Identity.Data;
using Manual_Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SelectPdf;
using System.Linq;


namespace Manual_Identity.Controllers
{
    public class Stud_DepController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public Stud_DepController(AppDbContext _context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = _context;
            this.webHostEnvironment = webHostEnvironment;
        }
        // Student
        [HttpGet]
        public async Task<IActionResult> Student()
        {
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdStudent(StudentViewModel model, IFormFile img)
        {
            string uniquefilename = string.Empty;
            if (img != null)
            {
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
                uniquefilename = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filepath = Path.Combine(uploadfolder, uniquefilename);
                img.CopyTo(new FileStream(filepath, FileMode.Create));
                model.PhotoPath = uniquefilename;
            }
            if (ModelState.IsValid)
            {
                model.Year = model.AdmissionDate.Year;
                model.Month = model.AdmissionDate.Month;
             
                if (model.StudentId == 0)
                {
                    var res = _context.Students.Where(x => x.StudentName == model.StudentName &&
                     x.FatherName == model.FatherName && x.CourseId == model.CourseId &&
                     x.Address == model.Address).FirstOrDefault();
                    if (res != null)
                    {
                        ViewBag.Message = "Exist";
                        return RedirectToAction("Student", "Stud_Dep");

                    }

                    _context.Students.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Student_List", "Stud_Dep");
                }
              
            }
            return View("Student");
        }


        [HttpGet]
        public async Task<IActionResult> Student_Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            ViewBag.Courses = _context.Courses.ToList();

            if (student == null)
            {
                return View("NotFound");
            }
            var model = new StudentViewModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Email = student.Email,
                FatherName = student.FatherName,
                CourseId = student.CourseId,
                //CourseName = student.CourseName,
                Address = student.Address,
                ContactNo = student.ContactNo,
                Year = student.AdmissionDate.Year,
                Month = student.AdmissionDate.Month,
                PhotoPath = student.PhotoPath,
                AdmissionDate = student.AdmissionDate,
            };
            return View(model);
        }

        //Add or Edit Student
        [HttpPost]
        public async Task<IActionResult> Student_Edit(StudentViewModel model, IFormFile img)
        {

            var user = _context.Students.Where(x => x.StudentId == model.StudentId).AsNoTracking().FirstOrDefault();
            model.PhotoPath = user.PhotoPath;
            string uniquefilename = string.Empty;
            if (img != null)
            {
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
                uniquefilename = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filepath = Path.Combine(uploadfolder, uniquefilename);
                img.CopyTo(new FileStream(filepath, FileMode.Create));
                model.PhotoPath = uniquefilename;
            }
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Student_List", "Stud_Dep");
        }


        //Student List
        [HttpGet]
        public async Task<IActionResult> Student_List()
        {
            return View(await _context.Students.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Student_Delete(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud == null) { return NotFound(); }
            else
            {
                _context.Students.Remove(stud);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Student_List");
        }

        //Student Detail
        [HttpGet]
        public async Task<IActionResult> Student_Detail(int id)
        {
            if (id == null) { return NotFound(); }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            { return View("NoFound"); }
            List<StudentViewModel> students = _context.Students.ToList();
            List<CourseViewModel> courses = _context.Courses.ToList();
            var StudentViewModel = (from s in students
                                    join c in courses
                                    on s.StudentId equals id
                                    where s.CourseId == c.CourseId
                                    select new StudentViewModel
                                    {
                                        StudentId = student.StudentId,
                                        StudentName = student.StudentName,
                                        Email = student.Email,
                                        FatherName = student.FatherName,
                                        CourseId = student.CourseId,
                                        CourseName = c.Name,
                                        Address = student.Address,
                                        ContactNo = student.ContactNo,
                                        Year = student.AdmissionDate.Year,
                                        Month = student.AdmissionDate.Month,
                                        PhotoPath = student.PhotoPath,
                                    }).FirstOrDefault(); ;
            return View(StudentViewModel);
        }

        //Course
        [HttpGet]
        public async Task<IActionResult> Course(CourseViewModel model)
        { return View(model); }

        //Add or Edit Course
        [HttpPost]
        public async Task<IActionResult> AdCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = _context.Courses.Where(x => x.Name == model.Name && x.Details == model.Details).FirstOrDefault();
                if (res != null)
                {
                    ViewBag.Message = "Exist";
                    return View("Course");
                }
                if (ModelState.IsValid)
                {

                    if (model.CourseId == 0)
                    {
                        _context.Courses.Add(model);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("CourseList", "Stud_Dep");
                    }
                    else
                    {
                        _context.Entry(model).State = EntityState.Modified;
                        _context.SaveChanges();
                        return RedirectToAction("CourseList", "Stud_Dep");
                    }
                }
                ModelState.Clear();
                return View("Student");
            }
            return View("Student");
        }

        //Course List
        public async Task<IActionResult> CourseList()
        {
            return View(await _context.Courses.ToListAsync());
        }

        //Course Delete
        [HttpGet]
        public async Task<IActionResult> Course_Delete(int id)
        {

            var course = await _context.Courses.FindAsync(id);
            if (course == null) { return NotFound(); }
            else
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("CourseList");
        }

        //Course Detail
        [HttpGet]
        public async Task<IActionResult> Course_Detail(int id)
        {
            if (id == null) { return NotFound(); }
            var course = await _context.Courses.FindAsync(id);
            if (course == null) { return View("NoFound"); }
            return View(new CourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Details = course.Details

            });
            //Employee emp = _DB.tbl_Employee.Where(x => x.ID == Id).FirstOrDefault();
            //return View(emp);


        }

        public async Task<IActionResult> JoinTable()
        {
            List<CourseViewModel> courses = _context.Courses.ToList();
            List<StudentViewModel> students = _context.Students.ToList();
            var stdlist =
                from s in students
                join c in courses
                on s.CourseId equals c.CourseId
                into Stu_Cou
                from c in Stu_Cou.DefaultIfEmpty()
                select new JoinModel
                {
                    Courses_details = c,
                    Students_details = s
                };
            return View(stdlist);
        }

        public IActionResult GeneratePdf(string html)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = new PdfDocument();
            PdfFont font = doc.AddFont(PdfStandardFont.Helvetica);
            font.Size = 22;
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginTop = 50;
            html = html.Replace("start", "<").Replace("end", ">");
            doc = converter.ConvertHtmlString(html);
            byte[] pdfFile = doc.Save();
            doc.Close();
            return File(pdfFile, "application/pdf");
        }


        //Add or Edit Student

    }
}
