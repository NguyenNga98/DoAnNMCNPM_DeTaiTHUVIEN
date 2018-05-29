using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data.Model
{
    public class LoaiDocGia : BaseEntity
    {
        public string TenLoaiDocGia { get; set; }
        public virtual ICollection<DocGia> DocGias { get; set; }
    }
}
