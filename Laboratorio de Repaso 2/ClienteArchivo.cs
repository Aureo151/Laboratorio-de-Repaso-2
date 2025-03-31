using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Laboratorio_de_Repaso_2
{
    internal class ClienteArchivo
    {
        public void Guardar(string archivo, List <Cliente> clientes)
        {
            string json = JsonConvert.SerializeObject(clientes);
            System.IO.File.WriteAllText(archivo, json);

        }
        public List <Cliente> Leer(string archivo)
        {
            List<Cliente> lista = new List<Cliente>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();

            lista = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return lista;
        }
    }
}
