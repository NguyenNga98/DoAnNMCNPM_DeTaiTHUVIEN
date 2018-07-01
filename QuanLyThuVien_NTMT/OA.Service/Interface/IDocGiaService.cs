using System;
using System.Collections.Generic;
using System.Text;
using Cross.ViewModel;
using OA.Data.Model;

namespace OA.Service.Interface
{
    public interface IDocGiaService
    {
        IEnumerable<DocGia> GetAll();
        DocGia GetDocGia(int id);
        void InsertDocGia(CreateDocGiaModel model);
        void UpdateDocGia(DocGia docGia);
        void DeleteDocGia(int id);
        bool CheckQuyDinh(int tuoi);
        void TraSach(int id);
        void GiaHanThe(int id,GiaHanTheModel model);
    }
}
