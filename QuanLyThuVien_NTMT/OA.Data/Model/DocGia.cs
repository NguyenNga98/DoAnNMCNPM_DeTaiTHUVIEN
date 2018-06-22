using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Data.Model
{
    public class DocGia : BaseEntity
    {      
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayLapThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int SoSachDangMuon { get; set; }
        public int LoaiDocGiaId { get; set; }
        [ForeignKey("LoaiDocGiaId")]
        public LoaiDocGia LoaiDocGia { get; set; }
        public ICollection<MuonTraSach> MuonTraSachs { get; set; }
    }
}
