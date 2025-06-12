
using CRUDMVVMQ22025.Models;
using SQLite;

namespace CRUDMVVMQ22025.Services
{
    public class EmpleadoService
    {
        private readonly SQLiteConnection _connection;

        public EmpleadoService()
        {
            // Path to storage database
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db3");
            // Initialize connection and create database
            _connection = new SQLiteConnection(dbPath);
            // Create table
            _connection.CreateTable<Empleado>();

            /*Empleado empleado = new Empleado();
            empleado.Nombre = "Juan Perez";
            empleado.Direccion = "San Pedro Sula";
            empleado.Email = "juancito@gmail.com";
            Insert(empleado);*/
        }

        public List<Empleado> GetAll() 
        {
            // It's equal to SELECT * FROM Empleado
            return _connection.Table<Empleado>().ToList();
        }

        public int Insert(Empleado empleado)
        { 
            // It's equal to INSERT Empleado VALUES(....
            return _connection.Insert(empleado);
        }

        public int Update(Empleado empleado) 
        {
            // It's equal to UPDATE Empleado set xxxxx=xxx WHERE id = xxx
            return _connection.Update(empleado);
        }

        public int Delete(Empleado empleado) 
        {
            // It's equal to DELETE FROM Empleado WHERE id = xxx
            return _connection.Delete(empleado);
        }
    }
}
