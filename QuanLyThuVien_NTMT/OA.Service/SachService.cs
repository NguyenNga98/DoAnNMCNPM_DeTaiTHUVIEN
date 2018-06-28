using Cross.ViewModel;
using OA.Data.Model;
using OA.Repository.Interface;
using OA.Service.Interface;
using System;
using System.Collections.Generic;

namespace OA.Service
{
    public class SachService : ISachService
    {
        private readonly IRepository<Sach> _sachRepository;
        private readonly IRepository<MuonTraSach> _muonTraSachRepository;
        private readonly IDocGiaRepository _docGiaRepository;
        private readonly IRepository<QuyDinhMuonSach> _quyDinhMuonRepository;

        public SachService(IRepository<Sach> sachRepository, IRepository<MuonTraSach> muonTraSachRepository, IDocGiaRepository docGiaRepository, IRepository<QuyDinhMuonSach> quyDinhMuonRepository)
        {
            _sachRepository = sachRepository;
            _muonTraSachRepository = muonTraSachRepository;
            _docGiaRepository = docGiaRepository;
            _quyDinhMuonRepository = quyDinhMuonRepository;
        }

        public void ThemSach(SachModel model)
        {
            Sach entity = new Sach()
            {
                Tensach = model.Tensach,
                TacGia = model.TacGia,
                TheLoaiId = model.TheLoaiId,
                NamXuatBan = model.NamXuatBan,
                NhaXuatBan = model.NhaXuatBan,
                NgayNhapSach = model.NgayNhapSach,
                TinhTrang = model.TinhTrang
            };
            _sachRepository.Insert(entity);
        }

        public void SuaSach(SachModel model)
        {
            throw new NotImplementedException();
        }

        public void XoaSach(Sach entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sach> GetAll()
        {
            return _sachRepository.Include(x => x.TheLoai);
        }

        public void MuonSach(int id,MuonSachModel model)
        {
            var entity = new MuonTraSach()
            {
                SachId = id,
                DocGiaId = model.DocGiaId,
             //   SachId = model.SachId,
                NgayMuon = model.NgayMuon
            };
            var docGia = _docGiaRepository.Get(model.DocGiaId);
            
            _muonTraSachRepository.Insert(entity);
            docGia.SoSachDangMuon += 1;
            _docGiaRepository.Update(docGia);
        }

        public Sach GetById(int id)
        {
            return _sachRepository.Get(id);
        }

        public MuonTraSach GetMuonTraSach(int id)
        {
            return _muonTraSachRepository.Get(id);
        }

        public void TraSach(int id)
        {
            var muonTraSach = _muonTraSachRepository.Get(id);
            var docGia = _docGiaRepository.Get(muonTraSach.DocGiaId);
            var sach = _sachRepository.Get(muonTraSach.SachId);
            _muonTraSachRepository.Delete(muonTraSach);
            docGia.SoSachDangMuon -= 1;
            sach.TinhTrang = true;
            _docGiaRepository.Update(docGia,x=>x.SoSachDangMuon);
            _sachRepository.Update(sach,x=>x.TinhTrang);
        }

        public bool CheckSoSach(int id)
        {
            var docGia = _docGiaRepository.Get(id);
            var quyDinh = _quyDinhMuonRepository.GetSingle();
            if (docGia.SoSachDangMuon >= quyDinh.SoSachMuonToiDa)
            {
                return false;
            }
            return true;
        }
    }
}
