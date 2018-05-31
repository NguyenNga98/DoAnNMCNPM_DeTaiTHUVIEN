using System;
using System.Collections.Generic;
using System.Text;
using Cross.ViewModel;
using OA.Data.Model;
using OA.Repository.Interface;
using OA.Service.Interface;

namespace OA.Service
{
    public class LoaiDocGiaService : ILoaiDocGiaService
    {
        private readonly IRepository<LoaiDocGia> _repository;

        public LoaiDocGiaService(IRepository<LoaiDocGia> repository)
        {
            _repository = repository;
        }

        public void Create(LoaiDocGiaModel model)
        {
            var entity = new LoaiDocGia()
            {
                TenLoaiDocGia = model.TenLoaiDocGia
            };
            _repository.Insert(entity);
        }

        public void Delete(DocGia docGia)
        {
            throw new NotImplementedException();
        }

        public void Edit(DocGia docGia)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiDocGia> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
