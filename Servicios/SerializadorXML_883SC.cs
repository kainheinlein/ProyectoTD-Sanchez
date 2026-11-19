using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Servicios
{
    public class SerializadorXML_883SC
    {
        public void Serializar_883SC<T>(List<T> lista, string ruta)
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(fs, lista);
            }
        }

        /// Un XML valido sin elementos devuelve una lista vacia; decidir si eso es un error es de la BLL.
        public List<T> Deserializar_883SC<T>(string ruta)
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Open))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    return (List<T>)serializer.Deserialize(fs);
                }
                catch (InvalidOperationException ex)
                {
                    //XmlSerializer envuelve los errores de formato (XmlException) en InvalidOperationException
                    throw new FormatException("El archivo no tiene el formato XML esperado", ex);
                }
            }
        }

        /// Texto del archivo, para mostrarlo como verificacion visual
        public string LeerTexto_883SC(string ruta)
        {
            return File.ReadAllText(ruta, Encoding.UTF8);
        }
    }
}
