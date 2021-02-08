using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelMVCUI.ViewModels
{
    public class PersonelFormViewModels
    {
        public IEnumerable<Departman> Departmans { get; set; }
        public Personel Personels { get; set; }
    }
}