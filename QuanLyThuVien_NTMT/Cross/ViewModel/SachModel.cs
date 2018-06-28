using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cross.ViewModel
{
    public class SachModel
    {
        public string Tensach { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhapSach { get; set; }
        public bool? TinhTrang { get; set; }
        public int TheLoaiId { get; set; }
    }
    public class MuonSachModel
    {
        public int DocGiaId { get; set; }
        //public int SachId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayMuon { get; set; }
    }

    public class TrasachModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayTra { get; set; }
        public decimal? TienPhat { get; set; }
    }
}
