using Proyecto_Creacion_Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskIt
{
   public partial class MainWindow : Window
   {
      private List<Tarea> tareas;
      public MainWindow()
      {
         InitializeComponent();
         MouseMove += Window_MouseMove;
         tareas = new List<Tarea>();
         ListBoxTareas.ItemsSource = tareas.Select(t => new { nombreTarea = t.nombreTarea, fecha = t.fecha, descripcion = t.descripcion }).ToList();
      }

      //Controles ventana
      private void Border_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.ChangedButton == MouseButton.Left)
         {
            this.DragMove();
         }
      }

      private void Window_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Maximized)
         {
            double mouseX = e.GetPosition(this).X;
            double windowHeight = ActualHeight;
            double windowTop = e.GetPosition(this).Y;
            double windowLeft = (mouseX / ActualWidth) * (SystemParameters.PrimaryScreenWidth - RestoreBounds.Width);
            Top = windowTop - (windowHeight);
            Left = windowLeft;
            WindowState = WindowState.Normal;
            DragMove();
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

      //Abrir dialogo nueva tarea
      private void crearTarea(object sender, RoutedEventArgs e)
      {
         // Crear la ventana del diálogo de nueva tarea
         var ventanaNuevaTarea = new VentanaNuevaTarea(ref tareas);

         // Mostrar la ventana como diálogo
         ventanaNuevaTarea.Owner = this;
         ventanaNuevaTarea.ShowDialog();

         if (ventanaNuevaTarea.DialogResult.HasValue && ventanaNuevaTarea.DialogResult.Value)
         {
            //resetear la lista
            Console.WriteLine("Refrescando lista de tareas");
            ListBoxTareas.ItemsSource = null;
            ListBoxTareas.ItemsSource = tareas.Select(t => new { nombreTarea = t.nombreTarea, fecha = t.fecha, descripcion = t.descripcion }).ToList();
         }
      }

      //EliminarTarea
      //TODO: terminar de implementar el metodo de eliminar
      private void EliminarTarea(object sender, RoutedEventArgs e)
      {
        
         var tareaSeleccionada = ListBoxTareas.SelectedItem as Tarea;
         Console.WriteLine("Eliminando tarea: " + tareaSeleccionada.ToString());
         if (tareaSeleccionada != null)
         {
            this.tareas.Remove(tareaSeleccionada);
            ListBoxTareas.ItemsSource = null;
            ListBoxTareas.ItemsSource = tareas.Select(t => new { nombreTarea = t.nombreTarea, fecha = t.fecha, descripcion = t.descripcion }).ToList();
            Console.WriteLine("Eliminando tarea 2");
         }
         foreach (Tarea tarea in this.tareas)
         {
            Console.WriteLine(tarea.ToString());
         }
      }
   }
}
