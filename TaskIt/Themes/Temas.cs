using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace TaskIt.Themes
{
    public class Temas
    {
        public ResourceDictionary CargarTema()
        {
            string tema = Properties.Settings.Default.Tema;
            ResourceDictionary newres;
            if (tema == null)
            {
                tema = "AzulProfundo";
                Properties.Settings.Default.Save();

            }

            string ubicacion = "Themes/" + tema + ".xaml"; 

            if (File.Exists(@"" + tema + ".xaml"))
            {
                newres = new ResourceDictionary
                {
                    Source = new Uri(ubicacion, UriKind.Relative)
                };
            }
            else
            {
                newres = new ResourceDictionary
                {
                    Source = new Uri(ubicacion, UriKind.Relative)
                };
                var settings = new System.Xml.XmlWriterSettings();
                settings.Indent = true;
                var writer = System.Xml.XmlWriter.Create(@"" + tema + ".xaml", settings);
                XamlWriter.Save(newres, writer);
            }
            return newres;
        }
    }
}
