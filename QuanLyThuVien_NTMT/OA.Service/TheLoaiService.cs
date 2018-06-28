using System;
using System.Collections.Generic;
using System.Text;
using Cross.ViewModel;
using OA.Data.Model;
using OA.Repository.Interface;
using OA.Service.Interface;

namespace OA.Service
{
    public class TheLoaiService : ITheLoaiService
    {
        private readonly IRepository<TheLoai> _repository;

        public TheLoaiService(IRepository<TheLoai> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TheLoai> GetAll()
        {
            return _repository.GetAll();
        }

        public void ThemTheLoai(TheLoaiModel model)
        {
            TheLoai entity = new TheLoai()
            {
                TenTheLoai = model.TenTheLoai
            };
            _repository.Insert(entity);
        }
    }
}
