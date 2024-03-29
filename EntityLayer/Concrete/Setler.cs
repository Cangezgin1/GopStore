﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Setler
    {
        [Key]
        public int SetID { get; set; }
        [StringLength(100)]
        public string SetAdi { get; set; }
        [StringLength(250)]
        public string SetBilgisi { get; set; }
        public double Fiyat { get; set; }
        [StringLength(10)]
        public string Sinif { get; set; }
        public string SetImage { get; set; }

        public ICollection<Students_Setler> students_Setlers { get; set; }
        //public int StudentID { get; set; }
    }
}
