using AxiHotel.Data.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;


namespace AxiHotel.Data.Repositories
{
    //Define la clase WorkerRepository, que es un repositorio
    //encargado de interactuar con la tabla Worker en la base de datos.
    public class WorkerRepository
    {
        //Campo privado y solo lectura que almacena la cadena de conexión hacia la base de datos.
        private readonly string _connString;
        //Constructor de la clase.
        public WorkerRepository()
        {
            _connString = ConfigurationManager.ConnectionStrings["AxiHotel"].ConnectionString;
        }
        //Inicio de Sesion
        //Método público que busca un Worker en la base de datos a partir de su nombre de usuario (UserWorker).
        //Se usa en el login.
        public Worker GetByUserName(string username)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmd = conn.CreateCommand())
            {
                //Define el texto SQL: selecciona columnas de la tabla Worker donde UserWorker coincida con un parámetro @use
                cmd.CommandText = @"SELECT IdWorker, FullNameWorker, IdentifyWorker, AddressWorker, PhoneWorker, UserWorker, PasswordWorker, JobTitle
                                    FROM Worker WHERE UserWorker = @user";
                cmd.Parameters.AddWithValue("@user", username ?? string.Empty);
                //Abre la conexión con la base de datos.
                conn.Open();
                //Ejecuta la consulta y obtiene un lector de datos (SqlDataReader) para recorrer los resultados.
                using (var r = cmd.ExecuteReader())
                {
                    //Avanza a la primera fila del resultado. Si existe un registro, entra al bloque.
                    if (r.Read())
                    {
                        return new Worker
                        {
                            IdWorker = r.GetInt32(0),
                            FullNameWorker = r.IsDBNull(1) ? null : r.GetString(1),
                            IdentifyWorker = r.IsDBNull(2) ? null : r.GetString(2),
                            AddressWorker = r.IsDBNull(3) ? null : r.GetString(3),
                            PhoneWorker = r.IsDBNull(4) ? null : r.GetString(4),
                            UserWorker = r.IsDBNull(5) ? null : r.GetString(5),
                            PasswordWorker = r.IsDBNull(6) ? null : r.GetString(6),
                            JobTitle = r.IsDBNull(7) ? null : r.GetString(7)
                        };
                    }
                }
            }
            //Si no se encontró ningún usuario con ese UserWorker, devuelve null
            return null;
        }
    }
}
