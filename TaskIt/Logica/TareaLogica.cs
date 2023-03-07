using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TaskIt.Modelo;
using System.Data.SQLite;
namespace TaskIt.Logica
{
   public class TareaLogica
   {
      public static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

      private static TareaLogica instance = null;

      public TareaLogica()
      {

      }

      public static TareaLogica Instancia
      {
         get
         {
            if (instance == null)
            {
               instance = new TareaLogica();
            }
            return instance;
         }
      }
      //metodo para guardar en la base de datos
      public bool Guardar(Tarea obj)
      {
         bool res = true;
         using (SQLiteConnection connection = new SQLiteConnection(cadena))
         {
            connection.Open(); // Open the connection
            string query = "INSERT INTO Tareas(nombre, fecha, descripcion) values(@nombre, @fecha, @descripcion)";
            //realizamos la conexion
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@nombre", obj.nombre));
            command.Parameters.Add(new SQLiteParameter("@fecha", obj.fecha));
            command.Parameters.Add(new SQLiteParameter("@descripcion", obj.descripcion));
            //especifica el tipo de comando que se va a usar
            command.CommandType = System.Data.CommandType.Text;
            //devuelve el numero de filas afectadas en la base de datos
            if (command.ExecuteNonQuery() < 1)
            {
               res = false;
            }

         }
         return res;
      }

      public List<Tarea> GetTareas()
      {
         List<Tarea> oLista = new List<Tarea>();

         using (SQLiteConnection connection = new SQLiteConnection(cadena))
         {
            connection.Open(); // Open the connection
            string query = "SELECT * FROM Tareas";
            //realizamos la conexion
            SQLiteCommand command = new SQLiteCommand(query, connection);
            //especifica el tipo de comando que se va a usar
            command.CommandType = System.Data.CommandType.Text;

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
               while (reader.Read())
               {
                  oLista.Add(new Tarea()
                  {
                     id = int.Parse(reader["id"].ToString()),
                     nombre = reader["nombre"].ToString(),
                     fecha = reader["fecha"].ToString(),
                     descripcion = reader["descripcion"].ToString(),
                  });
               }
            }
         }
         return oLista;
      }

      public bool Eliminar(Tarea obj)
      {
         bool res = true;
         using (SQLiteConnection connection = new SQLiteConnection(cadena))
         {
            connection.Open(); // Open the connection
            string query = "DELETE FROM Tareas WHERE id = @id";
            //realizamos la conexion
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", obj.id));
            //especifica el tipo de comando que se va a usar
            command.CommandType = System.Data.CommandType.Text;
            //devuelve el numero de filas afectadas en la base de datos
            if (command.ExecuteNonQuery() < 1)
            {
               res = false;
            }

         }
         return res;
      }
   }
}
