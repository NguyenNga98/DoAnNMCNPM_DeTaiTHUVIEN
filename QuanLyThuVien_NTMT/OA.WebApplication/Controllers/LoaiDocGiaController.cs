using Cross.ViewModel;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Interface;

namespace OA.WebApplication.Controllers
{
    public class LoaiDocGiaController : Controller
    {
        private readonly ILoaiDocGiaService _loaiDocGiaService;

        public LoaiDocGiaController(ILoaiDocGiaService loaiDocGiaService)
        {
            _loaiDocGiaService = loaiDocGiaService;
        }

        public IActionResult Index()
        {
            var listLoaiDocGia = _loaiDocGiaService.GetAll();
            return View(listLoaiDocGia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoaiDocGiaModel model)
        {
            if (ModelState.IsValid)
            {
                _loaiDocGiaService.Create(model);
                return Redirect("Index");
            }
            return View(model);
        }
    }
}