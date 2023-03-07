using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskIt.Modelo
{
   public class Tarea
   {
      public int id { get; set; }
      public string nombre { get; set; }
      public string fecha { get; set; }
      public string descripcion { get; set; }

      public override string ToString() => $" id: {id}, nombre: {nombre}, fecha: {fecha}, descripcion: {descripcion}";
   }
}
