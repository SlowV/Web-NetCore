using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebNetCore.Models;

namespace MyWebNetCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly WebModelContext _context;

        
        public StudentController(WebModelContext context)
        {
            _context = context;
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() {
                    Name = "Bánh mỳ",
                    CategoryId = 1,
                    Images = "http://www.puratosgrandplace.com/Data/Sites/1/media/news/ba%CC%81nh-mi%CC%80-5.jpg",
                    Status = 1
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("Student")]
        // GET: Student
        public ActionResult Index()
        {
            var item = _context.Students.ToList();
            return View(item);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Student/Store
        [HttpPost]
        public ActionResult Store(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Student/Edit/5
        [Route("Student/Edit/{id}")]
        public ActionResult<Student> Edit(long id)
        {
            var item = _context.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Student/Edit/5
        [HttpPost("{id}")]
        public ActionResult Update(long id, Student student)
        {
            var user = _context.Students.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = student.Name;
            user.RollNumber = student.RollNumber;
            user.Avatar = student.Avatar;
            _context.Students.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Student/Delete/5
        [HttpPost]
        [Route("Student/Delete/{id}")]
        public ActionResult Delete(long id)
        {
            var user = _context.Students.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Students.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}