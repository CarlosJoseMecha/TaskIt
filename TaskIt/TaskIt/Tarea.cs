using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Creacion_Interfaces
{
   public class Tarea
   {
      public string nombreTarea { get; set; }
      public string fecha { get; set; }
      public string descripcion { get; set; }

      public Tarea(string nombreTarea, string fecha, string descripcion)
      {
         this.nombreTarea = nombreTarea;
         this.fecha = fecha;
         this.descripcion = descripcion;
      }

      //GET
      public string GetNombreTarea()
      {
         return nombreTarea;
      }

      public string GetFecha()
      {
         return fecha;
      }

      public string GetDescripcion()
      {
         return descripcion;
      }

      //SET
      public void SetNombreTarea(string nombreTarea)
      {
         this.nombreTarea = nombreTarea;
      }

      public void SetFecha(string fecha)
      {
         this.fecha = fecha;
      }

      public void SetDescripcion(string descripcion)
      {
         this.descripcion = descripcion;
      }

      public override string ToString()
      {
         return $"{this.nombreTarea} - {this.fecha} - {this.descripcion}";
      }

   }
}
