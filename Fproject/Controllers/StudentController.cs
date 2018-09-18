using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fproject.Controllers
{

    public class StudentController : Controller
    {
        private FprojectContext ORM = null;
        public StudentController(FprojectContext ORM)
        {
            this.ORM = ORM;
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student S)
        {
            ORM.Student.Add(S);
            ORM.SaveChanges();
            ViewBag.Messege = "New Student Added Successfully";
            return View();
        }
        [HttpGet]
        public IActionResult EditStudent(int Id)
        {
            Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }
        [HttpPost]
        public IActionResult EditStudent(Student S)
        {
            ORM.Student.Update(S);
            ORM.SaveChanges();
            return RedirectToAction("AllStudent");
        }

        public IActionResult AllStudent()
        {
            IList<Student> AllStudent = ORM.Student.ToList<Student>();
            return View(AllStudent);
        }
        public IActionResult DetailStudent(int Id)
        {
            Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }
        public IActionResult DeleteStudent(Student S)
        {
            ORM.Student.Remove(S);
            ORM.SaveChanges();
            return RedirectToAction("AllStudent");
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(Teacher T)
        {
            ORM.Teacher.Add(T);
            ORM.SaveChanges();
            return View();
        }

    }
}
