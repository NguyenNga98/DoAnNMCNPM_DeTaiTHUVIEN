using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data.Model
{
    public class MuonTraSach : BaseEntity
    {
        public int DocGiaId { get; set; }
        public int SachId { get; set; }
        public DateTime NgayTra { get; set; }
        public decimal? TienPhat { get; set; }
        [ForeignKey("DocGiaId")]
        public DocGia DocGia { get; set; }
        [ForeignKey("SachId")]
        public Sach Sach { get; set; }
    }
}
