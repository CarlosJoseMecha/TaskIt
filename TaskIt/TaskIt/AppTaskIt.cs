using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Creacion_Interfaces
{
   internal class AppTaskIt
   {
      private List<Task> tareas { get; set; }

      public AppTaskIt()
      {
         this.tareas = new List<Task>();
      }

      public void AñadirTarea(Task tarea)
      {
         this.tareas.Add(tarea);
      }

      public void EliminarTarea(Task tarea)
      {
         this.tareas.Remove(tarea);
      }
   }
}
