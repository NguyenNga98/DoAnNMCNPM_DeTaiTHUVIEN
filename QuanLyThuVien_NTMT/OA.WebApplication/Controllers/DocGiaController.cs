using Cross.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA.Service.Interface;
using System;
using System.Linq;

namespace OA.WebApplication.Controllers
{
    public class DocGiaController : Controller
    {
        private readonly IDocGiaService _docGiaService;
        private readonly ILoaiDocGiaService _loaiDocGiaService;
        private readonly ISachService _sachService;
        public DocGiaController(IDocGiaService docGiaService, ILoaiDocGiaService loaiDocGiaService, ISachService sachService)
        {
            _docGiaService = docGiaService;
            _loaiDocGiaService = loaiDocGiaService;
            _sachService = sachService;
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
        public IActionResult Create(CreateDocGiaModel model)
        {

            if (ModelState.IsValid)
            {
                int tuoi = DateTime.Now.Year - model.NgaySinh.Year;
                bool checkTuoi = _docGiaService.CheckQuyDinh(tuoi);
                if (checkTuoi)
                {
                    _docGiaService.InsertDocGia(model);
                    return Redirect("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tuổi không hợp lệ");
                }
            }
            return View(model);
        }

        public IActionResult Detail(int? id)
        {
            var listDocGia = _docGiaService.GetAll();
            var docGia = listDocGia.FirstOrDefault(x => x.Id == id);
            if (docGia == null)
            {
                return RedirectToAction("Index", "Docgia");
            }
            //   var sach = docGia.MuonTraSachs.Single(x => x.SachId == sachId);
            return View(docGia);
        }
        [HttpPost]
        public IActionResult Detail(int id)
        {
            var a = _docGiaService.GetAll().Single(x => x.Id == id).MuonTraSachs;
            foreach (var i in a)
            {
                _sachService.GetById(i.SachId);
            }
            ViewData["LoaiDocGiaId"] = new SelectList(a, "Id", "SachId");
            //     var listDocGia = _docGiaService.GetAll();


            //   var sach = docGia.MuonTraSachs.Single(x => x.SachId == sachId);
            return View();
        }
        public IActionResult GiaHanThe(int? id)
        {
            if (id == null)
            {
                return Redirect("Index");
            }
            var docGia = _docGiaService.GetDocGia(id.Value);
            if (docGia == null)
            {
                return RedirectToAction("Index", "Sach");
            }

            return View();
        }
        [HttpPost]
        public IActionResult GiaHanThe(int id,GiaHanTheModel model)
        {
            if (ModelState.IsValid)
            {
                _docGiaService.GiaHanThe(id,model);
                return Redirect("Index");
            }
            return View(model);
        }
    }
}