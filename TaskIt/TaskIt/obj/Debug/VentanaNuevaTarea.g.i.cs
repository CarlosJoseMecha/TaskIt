﻿#pragma checksum "..\..\VentanaNuevaTarea.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6AD66E2D788791E35CCB6DC1A66BC4B7E8CB6A543FCFCF628D6740AAA2D7874B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using Proyecto_Creacion_Interfaces;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Proyecto_Creacion_Interfaces {
    
    
    /// <summary>
    /// VentanaNuevaTarea
    /// </summary>
    public partial class VentanaNuevaTarea : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\VentanaNuevaTarea.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nombre_Tarea;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\VentanaNuevaTarea.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Fecha;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\VentanaNuevaTarea.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Descripcion;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto_Creacion_Interfaces;component/ventananuevatarea.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaNuevaTarea.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\VentanaNuevaTarea.xaml"
            ((Proyecto_Creacion_Interfaces.VentanaNuevaTarea)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 37 "..\..\VentanaNuevaTarea.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Nombre_Tarea = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Fecha = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.Descripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 82 "..\..\VentanaNuevaTarea.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelarNuevaTarea);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 83 "..\..\VentanaNuevaTarea.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CrearNuevaTarea);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

