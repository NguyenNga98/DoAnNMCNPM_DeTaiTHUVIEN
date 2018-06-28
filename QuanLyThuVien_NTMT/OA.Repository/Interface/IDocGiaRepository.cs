using System.Collections.Generic;
using OA.Data.Model;

namespace OA.Repository.Interface
{
    public interface IDocGiaRepository : IRepository<DocGia>
    {
        IEnumerable<DocGia> ThenInclude();
        DocGia IncludeSach(int id);
    }
}