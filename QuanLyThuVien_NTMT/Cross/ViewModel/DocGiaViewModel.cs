﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cross.ViewModel
{
    public class DocGiaViewModel
    {

    }
    public class CreateDocGiaModel
    {
        [Required(ErrorMessage = "Tên độc giả không được để trống")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Địa chỉ độc giả không được để trống")]
        public string DiaChi { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayLapThe { get; set; }
        public int LoaiDocGiaId { get; set; }
    }
}
