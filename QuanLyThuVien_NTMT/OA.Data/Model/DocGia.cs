using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data.Model
{
    public class DocGia : BaseEntity
    {
        //CÁi này anh chia ra 3 tầng thấy chưa chưa 1
        //2
        //3 OK? là mấy cái 
        //ok ? Data ,service,App OK?ok
        //rồi / Tầng Data để chứa các cái gọi là entity hay là để ấy ra database .
        //Gồm các table ok? CÁi này gọi là Code first có nghĩa 
        //là mình viết code trước xong rồi tự zen ra database
        //,mình không phải viết data ở trong sql server dạ
        //Thằng Code First này nó tự động tìm thuộc tính nào có từ Id là nó sẽ mặc định khóa chính
        //Để int thì nó tự tăng ví dụ tạo độc giả thứ nhất id là 1 thì tạo ông thứ 2 sẽ có id là 2 
       // 2645 hic :D
        //khi thêm độc giả mình không cần thêm Id z mấy cái hàm bên trong 
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayLapThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int LoaiDocGiaId { get; set; }
        [ForeignKey("LoaiDocGiaId")]
        public LoaiDocGia LoaiDocGia { get; set; }
        public ICollection<MuonTraSach> MuonTraSachs { get; set; }
    }
}
