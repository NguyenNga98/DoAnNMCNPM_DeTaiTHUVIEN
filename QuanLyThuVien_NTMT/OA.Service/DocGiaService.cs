using Cross.ViewModel;
using OA.Data.Model;
using OA.Repository.Interface;
using OA.Service.Interface;
using System;
using System.Collections.Generic;

namespace OA.Service
{
    public class DocGiaService : IDocGiaService
    {
        private readonly IDocGiaRepository _repository;
        private readonly IRepository<QuyDinhDocGia> _quyDinhRepository;
        private readonly IRepository<MuonTraSach> _muonTraSachRepository;
        public DocGiaService(IDocGiaRepository repository, IRepository<QuyDinhDocGia> quyDinhRepository, IRepository<MuonTraSach> muonTraSachRepository)
        {
            _repository = repository;
            _quyDinhRepository = quyDinhRepository;
            _muonTraSachRepository = muonTraSachRepository;
        }
        public void DeleteDocGia(int id)
        {
            var docGia = _repository.Get(id);
            _repository.Delete(docGia);
        }

        public IEnumerable<DocGia> GetAll()
        {
            return _repository.ThenInclude();
        }

        public DocGia GetDocGia(int id)
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
        public void GiaHanThe(int id,GiaHanTheModel model)
        {
            var docGia = _repository.Get(id);
            docGia.NgayHetHan = docGia.NgayHetHan.AddMonths(model.SoThangGiaHan);
            _repository.Update(docGia, x => x.NgayHetHan);

        }
        public void TraSach(int id)
        {
            var muonTraSach = _muonTraSachRepository.Get(id);
            var docGia = _repository.Get(muonTraSach.DocGiaId);
            _muonTraSachRepository.Delete(muonTraSach);
            docGia.SoSachDangMuon -= 1;
            _repository.Update(docGia);
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
