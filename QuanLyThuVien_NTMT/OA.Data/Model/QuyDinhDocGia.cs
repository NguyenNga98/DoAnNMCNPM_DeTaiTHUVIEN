using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data.Model
{
    public class QuyDinhDocGia : BaseEntity
    {
        public int TuoiToiThieu { get; set; }
        public int TuoiToiDa { get; set; }
        public int ThoiHanThe { get; set; }
    }
}
