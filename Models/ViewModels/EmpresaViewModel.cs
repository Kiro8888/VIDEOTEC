using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIDEOTEC.Models.ViewModels
{
    public class EmpresaViewModel
    {
        public int Emp_id_empresa { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name ="Nombre")]
        public string Emp_nombre { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "Telefono")]
        public string Emp_telefono { get; set; }
        [Required]
     
        [Display(Name = "Direccion")]
        public string Emp_direccion { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Emp_correo { get; set; }
        [Required]
        [Display(Name = "Logo")]
        public string Emp_logo { get; set; }
    }
}