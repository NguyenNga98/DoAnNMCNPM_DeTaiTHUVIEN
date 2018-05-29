using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cross.ViewModel;
using Elect.Mapper.AutoMapper.ObjUtils;
using OA.Data.Model;
using OA.Repository.Interface;
using OA.Service.Interface;

namespace OA.Service
{
    public class DocGiaService : IDocGiaService
    {
        private readonly IRepository<DocGia> _repository;
        private readonly IMapper _mapper;
        public DocGiaService(IRepository<DocGia> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void DeleteDocGia(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocGia> GetAll()
        {
            return _repository.GetAll();
        }

        public DocGia GetUser(int id)
        {
            return _repository.Get(id);
        }

        public void InsertDocGia(DocGia docGia)
        {
            int tuoi = DateTime.Now.Year - docGia.NgaySinh.Year;
    //        CheckQuyDinh(tuoi);
            docGia.NgayHetHan = docGia.NgayLapThe.AddMonths(4);
            _repository.Insert(docGia);
        }

        public void UpdateDocGia(DocGia docGia)
        {
            throw new NotImplementedException();
        }
        private bool CheckQuyDinh(int tuoi)
        {
            if(tuoi < 18 || tuoi > 55)
            {
                return false;
            }
            return true;
        }
    }
}
