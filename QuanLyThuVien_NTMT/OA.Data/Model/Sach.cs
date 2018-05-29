using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data.Model
{
    public class Sach : BaseEntity
    {
        public string Tensach { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }
        public DateTime NgayNhapSach { get; set; }
        public bool? TinhTrang { get; set; }
        public int TheLoaiId { get; set; }
        [ForeignKey("TheLoaiId")]
        public TheLoai TheLoai { get; set; }
        public ICollection<MuonTraSach> MuonTraSachs { get; set; }
    }
}
