using FirstProject.Data;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{

    public class StudentController : Controller
    {
        StudentDbContext studentDb = new();

        public async Task<IActionResult> Index()
        {
            var studentList = await studentDb.Students.ToListAsync();
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            studentDb.Add(student);
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var Std = await studentDb.Students.FindAsync(Id);
            return View(Std);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Student student)
        {
            studentDb.Update(student);
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var Std = await studentDb.Students.FindAsync(Id);
            return View(Std);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Student student)
        {
            studentDb.Remove(student);
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }






    }
}
