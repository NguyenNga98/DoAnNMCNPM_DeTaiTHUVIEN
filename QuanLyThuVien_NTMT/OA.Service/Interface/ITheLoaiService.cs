using System.Collections.Generic;
using Cross.ViewModel;
using OA.Data.Model;

namespace OA.Service.Interface
{
    public interface ITheLoaiService
    {
        IEnumerable<TheLoai> GetAll();
        void ThemTheLoai(TheLoaiModel model);
    }
}