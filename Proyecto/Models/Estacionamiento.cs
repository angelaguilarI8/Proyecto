using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Estacionamiento
    {
        public int EstacionamientoID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Create Date")]
        [DisplayFormat(DataFormatString = "{00:dd/MM/yy}")]
        public DateTime Fecha { get; set; }
        [Required]
        [Validation]
        public int Nivel { get; set; }
    }
    public class Validation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int duration = (int)value;
            if (duration > 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Validation()
        {
            ErrorMessage = "No hay mas de 3 niveles";
        }
    }

}
