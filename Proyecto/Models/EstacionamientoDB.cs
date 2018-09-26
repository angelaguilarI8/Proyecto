using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class EstacionamientoDB : DbContext
    {
        public DbSet<Estacionamiento> Estacionamiento { get; set; }


    }

}
