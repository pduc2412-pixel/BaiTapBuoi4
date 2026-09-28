using Microsoft.AspNetCore.Mvc;
using LoginDemoCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoginDemoCore.Controllers
{
    public class BookController : Controller
    {
        // Danh sách sách mẫu, lưu tạm trong bộ nhớ (chưa dùng database)
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        // GET: Book
        // Chức năng 1 - Danh sách sách
        public IActionResult Index()
        {
            return View(books);
        }

        // GET: Book/Detail/1
        // Chức năng 2 - Chi tiết sách
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // Chức năng 3 - Thêm sách + Bài 3 - Validation (Data Annotation + ModelState)
        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (!ModelState.IsValid)
            {
                // Dữ liệu không hợp lệ (tên rỗng hoặc giá <= 0) -> hiển thị lại form kèm lỗi
                return View(model);
            }

            model.Id = books.Max(b => b.Id) + 1;
            books.Add(model);

            ViewBag.Message = "Thêm sách thành công";
            ModelState.Clear();
            return View(new Book());
        }
    }
}
