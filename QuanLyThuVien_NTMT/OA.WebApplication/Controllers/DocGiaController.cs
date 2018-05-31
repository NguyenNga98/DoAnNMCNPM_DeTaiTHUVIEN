using System;
using Cross.ViewModel;
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
        public IActionResult Create(CreateDocGiaModel model)
        {
           
            if(ModelState.IsValid)
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
                    ModelState.AddModelError("","Tuổi không hợp lệ");
                }
            }
            return View(model);
        }
    }
}