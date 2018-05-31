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
        private readonly IRepository<QuyDinhDocGia> _quyDinhRepository;
        private readonly IMapper _mapper;
        public DocGiaService(IRepository<DocGia> repository,IMapper mapper, IRepository<QuyDinhDocGia> quyDinhRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _quyDinhRepository = quyDinhRepository;
        }
        public void DeleteDocGia(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocGia> GetAll()
        {
            return _repository.Include(x => x.LoaiDocGia);
        }

        public DocGia GetUser(int id)
        {
            return _repository.Get(id);
        }

        public void InsertDocGia(CreateDocGiaModel model)
        {
            var entity = new DocGia()
            {
                HoTen = model.HoTen,
                Email = model.Email,
                DiaChi = model.DiaChi,
                NgaySinh = model.NgaySinh,
                NgayLapThe = model.NgayLapThe,
                NgayHetHan = model.NgayLapThe.AddMonths(GetThoiHanThe()),
                LoaiDocGiaId = model.LoaiDocGiaId

            };
            _repository.Insert(entity);
        }

        public void UpdateDocGia(DocGia docGia)
        {
            throw new NotImplementedException();
        }

        public void EditQuyDinĐinhocGia(QuyDinhDocGia quyDinh)
        {
            _quyDinhRepository.Update(quyDinh);
        }
        public bool CheckQuyDinh(int tuoi)
        {
            int tuoiToiDa = _quyDinhRepository.GetSingle().TuoiToiDa;
            int tuoiToiThieu = _quyDinhRepository.GetSingle().TuoiToiThieu;
            if(tuoi < tuoiToiThieu || tuoi > tuoiToiDa)
            {
                return false;
            }
            return true;
        }

        private int GetThoiHanThe()
        {
            return _quyDinhRepository.GetSingle().ThoiHanThe;
        }
    }
}
