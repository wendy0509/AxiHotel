using System;
using System.Collections.Generic;
using AxiHotel.Data.Models;
using AxiHotel.Data.Repositories;


namespace AxiHotel.Business
{
    public class WorkerService
    {
        //crea una variable privada que hace referencia al repositorio de trabajadores 
        //El que se encarga de consultar ne la base de datos
        private readonly WorkerRepository _repo;
        //Constructor de la clas e
        public WorkerService()
        {
            _repo = new WorkerRepository();
        }
        // Autenticación: devuelve Worker si OK, null o lanza excepción si no
        // es el metodo que autentica un usuario recibiendo el username y la contraseña
        public Worker Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Usuario y contraseña requeridos.");

            var user = _repo.GetByUserName(username);
            if (user == null)
                return null;

            // Si PasswordWorker es null o vacío -> fallar
            if (string.IsNullOrEmpty(user.PasswordWorker))
                return null;

            // Comparación directa en texto plano
            bool ok = password == user.PasswordWorker;
            return ok ? user : null;
        }

    }
}
