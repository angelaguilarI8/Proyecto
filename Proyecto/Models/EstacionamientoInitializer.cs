using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class EstacionamientoInitializer : DropCreateDatabaseAlways<EstacionamientoDB>
    {
        protected override void Seed(EstacionamientoDB context)
        {
            base.Seed(context);
            var Estacionamiento = new List<Estacionamiento>
            {
                new Estacionamiento

                {
                    Fecha = DateTime.Today,
                    Nivel = 2,
                    
                }
            };
            Estacionamiento.ForEach(s => context.Estacionamiento.Add(s));
            context.SaveChanges();
        }
    }
}
