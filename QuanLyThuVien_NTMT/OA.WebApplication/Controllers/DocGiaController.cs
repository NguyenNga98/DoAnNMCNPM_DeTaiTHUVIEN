using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cross.ViewModel;
using Microsoft.AspNetCore.Mvc;
using OA.Data.Model;
using OA.Service.Interface;

namespace OA.WebApplication.Controllers
{
    public class DocGiaController : Controller
    {
        private readonly IDocGiaService _docGiaService;
        public DocGiaController(IDocGiaService docGiaService)
        {
            _docGiaService = docGiaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
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