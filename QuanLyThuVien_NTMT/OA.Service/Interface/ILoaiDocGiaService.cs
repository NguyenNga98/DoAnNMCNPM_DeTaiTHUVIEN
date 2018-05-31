using System.Collections;
using System.Collections.Generic;
using Cross.ViewModel;
using OA.Data.Model;

namespace OA.Service.Interface
{
    public interface ILoaiDocGiaService
    {
        void Create(LoaiDocGiaModel model);
        void Delete(DocGia docGia);
        void Edit(DocGia docGia);
        IEnumerable<LoaiDocGia> GetAll();
    }
}