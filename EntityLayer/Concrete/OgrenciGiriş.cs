using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OgrenciGiriş
    {
        [Key]
        public int ID { get; set; }
        [StringLength(25)]
        public string KullanıcıAdı { get; set; }
        [StringLength(6)]
        public string Sifre { get; set; }
    }
}
