using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admins
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(50)]
        public string İsim { get; set; }
        [StringLength(50)]
        public string Soyisim { get; set; }
        [StringLength(50)]
        public string AdminMail { get; set; }
        [StringLength(50)]
        public string AdminŞifre { get; set; }
    }
}
