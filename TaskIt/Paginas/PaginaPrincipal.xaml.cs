using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaskIt.Themes;
using TaskIt.Modelo;
using TaskIt.Logica;
using System.Collections;
using System.Globalization;

namespace TaskIt.Paginas
{
   public partial class PaginaPrincipal : Page
   {
      private List<Tarea> listaTareas;
      private int index;
      //Orden
      private bool ordenAscNombre = true;
      private bool ordenAscFecha = true;
      public PaginaPrincipal()
      {
         InitializeComponent();
         //Carga el tema
         string tema = Properties.Settings.Default.Tema;
         CargarTema();
         //carga la base de datos con las tareas guardadas
         listaTareas = TareaLogica.Instancia.GetTareas();

         ListBoxTareas.ItemsSource = listaTareas.Select(t => new { nombreTarea = t.nombre, fecha = t.fecha, descripcion = t.descripcion }).ToList();
      }

      //Abrir dialogo nueva tarea
      private void crearTarea(object sender, RoutedEventArgs e)
      {
         // Crear la ventana del diálogo de nueva tarea
         var ventanaNuevaTarea = new VentanaNuevaTarea(ref listaTareas);
         ventanaNuevaTarea.Owner = Application.Current.MainWindow;
         // Mostrar la ventana como diálogo
         ventanaNuevaTarea.ShowDialog();
         //si se añade correctamente la tarea
         if (ventanaNuevaTarea.DialogResult.HasValue && ventanaNuevaTarea.DialogResult.Value)
         {
            //actualiza la vista de la lista de tareas
            ListBoxTareas.ItemsSource = null;
            listaTareas = TareaLogica.Instancia.GetTareas();
            ListBoxTareas.ItemsSource = listaTareas.Select(t => new { nombreTarea = t.nombre, fecha = t.fecha, descripcion = t.descripcion }).ToList();
         }
      }

      //EliminarTarea
      private void EliminarTarea(object sender, RoutedEventArgs e)
      {
         if (ListBoxTareas.SelectedItems.Count > 0)
         {
            if (index != -1)
            {
               TareaLogica.Instancia.Eliminar(listaTareas.ElementAt(index));
               //actualiza la vista de la lista de tareas
               ListBoxTareas.ItemsSource = null;
               listaTareas = TareaLogica.Instancia.GetTareas();
               ListBoxTareas.ItemsSource = listaTareas.Select(t => new { nombreTarea = t.nombre, fecha = t.fecha, descripcion = t.descripcion }).ToList();
            }
         }
      }
      private void Ver_Detalles(object sender, RoutedEventArgs e)
      {
         // Crear la ventana del diálogo de nueva tarea
         var ventanaDetalles = new VentanaDetalles();
         ventanaDetalles.Owner = Application.Current.MainWindow;

         Button botonPresionado = sender as Button;
         ListBoxItem listBoxItem = FindAncestor<ListBoxItem>(botonPresionado);
         int index = ListBoxTareas.Items.IndexOf(listBoxItem.Content);

         if (index != -1)
         {
            ventanaDetalles.NombreTarea.Text = listaTareas.ElementAt(index).nombre;
            ventanaDetalles.FechaTarea.Text = listaTareas.ElementAt(index).fecha;
            ventanaDetalles.DescripcionTarea.Text = listaTareas.ElementAt(index).descripcion;
         }

         ventanaDetalles.ShowDialog();
      }

      //Metodo para ordenar la lista por nombre
      private void Ordenar_Nombre(object sender, RoutedEventArgs e)
      {
         if (ordenAscNombre)
         {
            listaTareas.Sort(new ComparadorTareaPorNombre());
         }
         else
         {
            listaTareas.Sort(new ComparadorTareaPorNombreDesc());
         }
         ordenAscNombre = !ordenAscNombre;
         ListBoxTareas.ItemsSource = listaTareas.Select(t => new { nombreTarea = t.nombre, fecha = t.fecha, descripcion = t.descripcion }).ToList();
      }

      //Metodo para ordenar la lista por fecha
      private void Ordenar_Fecha(object sender, RoutedEventArgs e)
      {
         if (ordenAscFecha)
         {
            listaTareas.Sort(new ComparadorTareaPorFecha());
         }
         else
         {
            listaTareas.Sort(new ComparadorTareaPorFechaDesc());
         }
         ordenAscFecha = !ordenAscFecha;
         ListBoxTareas.ItemsSource = listaTareas.Select(t => new { nombreTarea = t.nombre, fecha = t.fecha, descripcion = t.descripcion }).ToList();
      }

      private void ListBoxTareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         if (ListBoxTareas.SelectedIndex != -1)
         {
            index = ListBoxTareas.SelectedIndex;
         }
      }
      public void CargarTema()
      {
         Temas temas = new Temas();
         Application.Current.Resources.MergedDictionaries.Clear();
         Application.Current.Resources.MergedDictionaries.Add(temas.CargarTema());
      }

      public static T FindAncestor<T>(DependencyObject current)
    where T : DependencyObject
      {
         current = VisualTreeHelper.GetParent(current);

         while (current != null)
         {
            if (current is T result)
            {
               return result;
            }

            current = VisualTreeHelper.GetParent(current);
         }
         return null;
      }
   }
   public class ComparadorTareaPorNombre : IComparer<Tarea>
   {
      public int Compare(Tarea x, Tarea y)
      {
         return x.nombre.CompareTo(y.nombre);
      }
   }

   public class ComparadorTareaPorFecha : IComparer<Tarea>
   {
      public int Compare(Tarea x, Tarea y)
      {
         DateTime fechaX = DateTime.ParseExact(x.fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
         DateTime fechaY = DateTime.ParseExact(y.fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
         return fechaX.CompareTo(fechaY);
      }
   }

   public class ComparadorTareaPorNombreDesc : IComparer<Tarea>
   {
      public int Compare(Tarea x, Tarea y)
      {
         return y.nombre.CompareTo(x.nombre);
      }
   }

   public class ComparadorTareaPorFechaDesc : IComparer<Tarea>
   {
      public int Compare(Tarea x, Tarea y)
      {
         DateTime fechaX = DateTime.ParseExact(x.fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
         DateTime fechaY = DateTime.ParseExact(y.fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
         return fechaY.CompareTo(fechaX);
      }
   }
}

