using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Data.Model
{
    public class MuonTraSach : BaseEntity
    {
        public int DocGiaId { get; set; }
        public int SachId { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime? NgayTra { get; set; }
        public decimal? TienPhat { get; set; }
        [ForeignKey("DocGiaId")]
        public DocGia DocGia { get; set; }
        [ForeignKey("SachId")]
        public Sach Sach { get; set; }
    }
}
