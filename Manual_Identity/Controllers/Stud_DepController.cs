using Manual_Identity.Data;
using Manual_Identity.Models;
using Microsoft.AspNetCore.Mvc;
//<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
//=======
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27

namespace Manual_Identity.Controllers
{
    public class Stud_DepController : Controller
    {
        private readonly AppDbContext _context;
        //List<StudentViewModel> student=new List<StudentViewModel>();
        //List<CourseViewModel> course = new List<CourseViewModel>();

        //public async Task<IActionResult> JoinTable()
        //{
        //    List<CourseViewModel> courses = _context.Courses.ToList();
        //    List<StudentViewModel> students = _context.Students.ToList(; 
        //    var join_table = from course in _context.Courses
        //                    from student in _context.Students
        //                    where student.CourseId == course.CourseId
        //                    select new 
        //                    {
        //                        //StudentId = student.StudentId,
        //                        StudentName = student.StudentName,
        //                        FatherName = student.FatherName,
        //                        CourseId = course.CourseId,
        //                        Name = course.Name,
        //                        Details = course.Details,
        //                        Address = student.Address,

        //                    };
        //    return View(join_table);

        //    //var StudentViewModel = from s in student
        //    //                       join c in course on s.CourseId equals c.CourseId into st2
        //    //                       from c in st2.DefaultIfEmpty()
        //    //                       select new StudentViewModel { studentVm = s, studentAdditionalInfoVm = st };
        //    //return View(studentViewModel);
        //}

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
//<<<<<<< HEAD
            
//=======
            var res = _context.Students.Where(x => x.StudentName == model.StudentName &&
            x.FatherName == model.FatherName && x.CourseId == model.CourseId && x.Address == model.Address).FirstOrDefault();
            if (res != null)
            {
                ViewBag.Message = "Exist";
                return View("Student");
            }

//>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27
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
//<<<<<<< HEAD


//=======
//>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27
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
        public async Task<IActionResult> JoinTable()
        {
            List<CourseViewModel> courses = _context.Courses.ToList();
            List<StudentViewModel> students = _context.Students.ToList();
            var stdlist =
                //from s in students
                //from c in courses
                //where s.CourseId ==c.CourseId
                //select new JoinModel
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

//<<<<<<< HEAD

//=======
//>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27
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
                StudentName = student.StudentName,
                FatherName = student.FatherName,
                CourseId = student.CourseId,
                Address = student.Address
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
            //<<<<<<< HEAD

            if (ModelState.IsValid)
            {

                //=======
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
                        //>>>>>>> 0ab365ef4b88f303d38a71dfe6eba7c3d22a4e27
                        return RedirectToAction("CourseList", "Stud_Dep");
                    }
                    else
                    {
                        _context.Entry(model).State = EntityState.Modified;
                        _context.SaveChanges();
                        //<<<<<<< HEAD
                        //=======
                        //ViewBag.Courses = _context.Courses.ToList();

                        //ViewBag.Courses = new SelectList(_context.Courses, "CourseId");
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
            //var list = await _context.Courses.ToListAsync();
            //return View(list);
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

    }
}
