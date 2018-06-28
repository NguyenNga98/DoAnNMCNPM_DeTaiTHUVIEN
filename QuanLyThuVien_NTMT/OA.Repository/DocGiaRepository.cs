using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Data.Model;
using OA.Repository.Interface;

namespace OA.Repository
{
    public class DocGiaRepository : Repository<DocGia>, IDocGiaRepository
    {
        private readonly ThuVienContext _context;
        public IEnumerable<DocGia> ThenInclude()
        {
            return _context.DocGia.Include(x=>x.LoaiDocGia).Include(x => x.MuonTraSachs).ThenInclude(y => y.Sach).ToList();
        }

        public DocGia IncludeSach(int id)
        {
            return _context.DocGia.Find(id);
        }

        public DocGiaRepository(ThuVienContext context) : base(context)
        {
            _context = context;
        }
    }
}
