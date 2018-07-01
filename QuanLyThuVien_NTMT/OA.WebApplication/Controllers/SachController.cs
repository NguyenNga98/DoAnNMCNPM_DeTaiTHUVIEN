using Cross.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA.Service.Interface;

namespace OA.WebApplication.Controllers
{
    public class SachController : Controller
    {
        private readonly ITheLoaiService _theLoaiService;
        private readonly ISachService _sachService;
        public SachController(ITheLoaiService theLoaiService, ISachService sachService)
        {
            _theLoaiService = theLoaiService;
            _sachService = sachService;
        }

        public IActionResult Index()
        {
            var listSach = _sachService.GetAll();
            return View(listSach);
        }
        public IActionResult ThemTheLoai()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThemTheLoai(TheLoaiModel model)
        {
            if (ModelState.IsValid)
            {
                _theLoaiService.ThemTheLoai(model);
                return Redirect("Index");
            }
            return View(model);
        }
        public IActionResult Create()
        {
            ViewData["TheLoaiId"] = new SelectList(_theLoaiService.GetAll(), "Id", "TenTheLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(SachModel model)
        {
            ViewData["TheLoaiId"] = new SelectList(_theLoaiService.GetAll(), "Id", "TenTheLoai");
            if (ModelState.IsValid)
            {
                _sachService.ThemSach(model);
                return Redirect("Index");
            }
            return View(model);
        }

        public IActionResult BorrowBooks(int? id)
        {
            if (id == null)
            {
                return Redirect("Index");
            }
            var sach = _sachService.GetById(id.Value);
            if (sach == null)
            {
                return RedirectToAction("Index", "Sach");
            }
            if(sach.TinhTrang == false)
            {
                return RedirectToAction("Index", "Sach");
            }
            ViewBag.Sach = _sachService.GetById(id.Value).Tensach;
           // var sach = _sachService.GetById(id.Value);
            return View();
        }

        [HttpPost]
        public IActionResult BorrowBooks(int id,MuonSachModel model)
        {
            //var sach = _sachService.GetById(id);
            //if (sach == null)
            //{
            //    return RedirectToAction("Index","Sach");
            //}
            if (ModelState.IsValid)
            {
              //  model.SachId = id;
                if (!_sachService.CheckSoSach(model.DocGiaId))
                {
                    ModelState.AddModelError("","Mượn quá số sách quy định.Vui lòng trả sách trước khi mượn");
                }
                else
                {
                    _sachService.MuonSach(id, model);
                    return RedirectToAction("Index", "Sach");
                }
                
            }
            return View(model);
        }

        public IActionResult GiveBook(int? id)
        {
            if (id == null)
                return NotFound();
            _sachService.TraSach(id.Value);
            return RedirectToAction("Index", "DocGia");
        }

       
    }
}