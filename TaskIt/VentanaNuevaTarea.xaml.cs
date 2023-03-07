using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskIt.Logica;
using TaskIt.Modelo;

namespace TaskIt
{
   public partial class VentanaNuevaTarea : Window
   {
      private List<Tarea> listaTareas;
      public VentanaNuevaTarea(ref List<Tarea> listaTareas)
      {
         InitializeComponent();
         this.listaTareas = listaTareas;
      }

      //Controles ventana
      private void Border_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.ChangedButton == MouseButton.Left)
         {
            this.DragMove();
         }
      }
      private void closeButton_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }
      private void Button_Maximize(object sender, RoutedEventArgs e)
      {
         if (this.WindowState == WindowState.Maximized)
         {
            this.WindowState = WindowState.Normal;
         }
         else
         {
            this.WindowState = WindowState.Maximized;
         }
      }
      private void Button_Minimize(object sender, RoutedEventArgs e)
      {
         this.WindowState = WindowState.Minimized;
      }

      //Metodo que cree una nueva tarea.
      //TODO: Validar todo lo que se introduce, no permitir campos vacios.
      private void CrearNuevaTarea(object sender, RoutedEventArgs e)
      {
         Tarea nuevaTarea = new Tarea()
         {
            nombre = Nombre_Tarea.Text,
            fecha = Fecha.Text,
            descripcion = Descripcion.Text
         };

         bool res = TareaLogica.Instancia.Guardar(nuevaTarea);
         this.DialogResult = true;
         this.Close();
      }

      //Metodo cancelar ventana dialogo añadir nueva tarea.
      private void CancelarNuevaTarea(object sender, RoutedEventArgs e)
      {
         this.DialogResult = false;
         this.Close();
      }
   }

}
