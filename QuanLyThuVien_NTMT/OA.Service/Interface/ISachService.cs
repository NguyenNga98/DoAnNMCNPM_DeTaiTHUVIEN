using System.Collections.Generic;
using Cross.ViewModel;
using OA.Data.Model;

namespace OA.Service.Interface
{
    public interface ISachService
    {
        void ThemSach(SachModel model);
        void SuaSach(SachModel model);
        void XoaSach(Sach entity);
        IEnumerable<Sach> GetAll();
        void MuonSach(int id,MuonSachModel model);
        Sach GetById(int id);
        void TraSach(int id);
        bool CheckSoSach(int id);
    }
}