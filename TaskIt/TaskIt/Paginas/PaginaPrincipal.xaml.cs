using Proyecto_Creacion_Interfaces.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Creacion_Interfaces.Paginas
{
   public partial class PaginaPrincipal : Page
   {
      private List<Tarea> tareas;
      public PaginaPrincipal()
      {
         InitializeComponent();
         string tema = Properties.Settings.Default.Tema;
         CargarTema();
         tareas = new List<Tarea>
         {
            new Tarea("Tarea 1", "27/02/2023", "Descripcion tarea 1"),
            new Tarea("Tarea 2", "27/02/2023", "Descripcion tarea 1"),
            new Tarea("Tarea 3", "27/02/2023", "Descripcion tarea 1"),
            new Tarea("Tarea 4", "27/02/2023", "Descripcion tarea 1"),
            new Tarea("Tarea 5", "27/02/2023", "Descripcion tarea 1"),
            new Tarea("Tarea 6", "27/02/2023", "Descripcion tarea 1"),
            new Tarea("Tarea 7", "27/02/2023", "Descripcion tarea 1")
         };

         ListBoxTareas.ItemsSource = tareas.Select(t => new { nombreTarea = t.nombreTarea, fecha = t.fecha, descripcion = t.descripcion }).ToList();
      }

      //Abrir dialogo nueva tarea
      private void crearTarea(object sender, RoutedEventArgs e)
      {
         // Crear la ventana del diálogo de nueva tarea
         var ventanaNuevaTarea = new VentanaNuevaTarea(ref tareas);
         ventanaNuevaTarea.Owner = Application.Current.MainWindow;
         // Mostrar la ventana como diálogo
         ventanaNuevaTarea.ShowDialog();

         if (ventanaNuevaTarea.DialogResult.HasValue && ventanaNuevaTarea.DialogResult.Value)
         {
            //resetear la lista
            ListBoxTareas.ItemsSource = null;
            ListBoxTareas.ItemsSource = tareas.Select(t => new { nombreTarea = t.nombreTarea, fecha = t.fecha, descripcion = t.descripcion }).ToList();
         }
      }

      //EliminarTarea
      private void EliminarTarea(object sender, RoutedEventArgs e)
      {
         if (ListBoxTareas.SelectedItems.Count > 0)
         {
            int index = ListBoxTareas.SelectedItems.IndexOf(ListBoxTareas.SelectedItem);
            if (index != -1)
            {
               this.tareas.RemoveAt(index);
               ListBoxTareas.ItemsSource = null;
               ListBoxTareas.ItemsSource = tareas.Select(t => new { nombreTarea = t.nombreTarea, fecha = t.fecha, descripcion = t.descripcion }).ToList();
            }
         }
      }

      private void ListBoxTareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         if (ListBoxTareas.SelectedIndex != -1)
         {
            Console.WriteLine("El índice del elemento seleccionado es: " + ListBoxTareas.SelectedIndex);
         }
      }
      public void CargarTema()
      {
         Temas temas = new Temas();
         Application.Current.Resources.MergedDictionaries.Clear();
         Application.Current.Resources.MergedDictionaries.Add(temas.CargarTema());
      }
   }
}
