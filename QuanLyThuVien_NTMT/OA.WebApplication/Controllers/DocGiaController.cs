using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA.Data.Model;
using OA.Service.Interface;

namespace OA.WebApplication.Controllers
{
    public class DocGiaController : Controller
    {
        private readonly IDocGiaService _docGiaService;
        private readonly ILoaiDocGiaService _loaiDocGiaService;
        public DocGiaController(IDocGiaService docGiaService, ILoaiDocGiaService loaiDocGiaService)
        {
            _docGiaService = docGiaService;
            _loaiDocGiaService = loaiDocGiaService;
        }
        public IActionResult Index()
        {
            var listDocGia = _docGiaService.GetAll();
            return View(listDocGia);
        }
        public IActionResult Create()
        {
            ViewData["LoaiDocGiaId"] = new SelectList(_loaiDocGiaService.GetAll(), "Id", "TenLoaiDocGia");
            return View();
        }
        [HttpPost]
        public IActionResult Create(DocGia model)
        {
            if(ModelState.IsValid)
            {
                _docGiaService.InsertDocGia(model);
                return Redirect("Index");
            }
            return View(model);
        }
    }
}