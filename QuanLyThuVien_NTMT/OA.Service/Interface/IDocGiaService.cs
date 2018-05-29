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
        DocGia GetUser(int id);
        void InsertDocGia(DocGia docGia);
        void UpdateDocGia(DocGia docGia);
        void DeleteDocGia(int id);
    }
}
