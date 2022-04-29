using Manual_Identity.Data;
using Manual_Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Manual_Identity.Controllers
{
    public class Stud_DepController : Controller
    {
        private readonly AppDbContext _context;

        public Stud_DepController(AppDbContext _context)
        {
            this._context = _context;
        }
        // Student
        [HttpGet]
        public async Task<IActionResult> Student(StudentViewModel model)
        {
            ViewBag.Courses = _context.Courses.ToList(); 
            return View(model);
        }

        //Add or Edit Student
        [HttpPost]
        public async Task<IActionResult> AdStudent(StudentViewModel model)
        {
            var res = _context.Students.Where(x => x.StudentName == model.StudentName &&
            x.FatherName == model.FatherName && x.CourseId==model.CourseId && x.Address==model.Address).FirstOrDefault();
            if (res != null)
            {
                ViewBag.Message = "Exist";
                return View("Student");
            }

            if (ModelState.IsValid)
            {
                if (model.StudentId == 0)
                {
                    _context.Students.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Student_List", "Stud_Dep");
                }
                else
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Student_List", "Stud_Dep");
                }
            }
            return View("Student");


        }
        
        //Student List
        [HttpGet]
        public async Task<IActionResult> Student_List()
        {
            return View(await _context.Students.ToListAsync());
        }

        //Student Delete
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
            if (student == null) { return View("NoFound"); }
            return View(new StudentViewModel
            {
                StudentId = student.StudentId,
                StudentName =student.StudentName,
                FatherName =student.FatherName,
                CourseId=student.CourseId,
                Address=student.Address      
            });

        }


        //Course
        [HttpGet]
        public async Task<IActionResult> Course(CourseViewModel model)
        {
            return View(model);
        }

        //Add or Edit Course
        [HttpPost]
        public async Task<IActionResult> AdCourse(CourseViewModel model)
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
                    
                    //ViewBag.Courses = new SelectList(_context.Courses,"CourseId"); 
                    //ViewBag.Courses = _context.Courses.ToListAsync();
                    return RedirectToAction("CourseList", "Stud_Dep");
                }
                else
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();
                    //ViewBag.Courses = _context.Courses.ToList();

                    //ViewBag.Courses = new SelectList(_context.Courses, "CourseId");
                    return RedirectToAction("CourseList", "Stud_Dep"); 

                }
            }
            ModelState.Clear();
            return View("Student");
        }
        
        //Course List
        public async Task<IActionResult> CourseList()
        {
            //var list = await _context.Courses.ToListAsync();
            //return View(list);
            return View(await _context.Courses.ToListAsync());
        }

        //Course Delete
        [HttpGet]
        public async Task<IActionResult> Course_Delete(int id)
        {

            var course = await _context.Courses.FindAsync(id);
            if(course == null) { return NotFound(); }
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
                CourseId=course.CourseId,
                Name = course.Name,
                Details = course.Details
              
            });
            //Employee emp = _DB.tbl_Employee.Where(x => x.ID == Id).FirstOrDefault();
            //return View(emp);

           
        }

    }
}
