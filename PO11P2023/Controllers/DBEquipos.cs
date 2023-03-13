using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PO11P2023.Controllers
{
    public class DBEquipos
    {
        //Global Variables
        readonly SQLite.SQLiteAsyncConnection _conexion;
        // Constructor vacio
        public DBEquipos() 
        { }

        public DBEquipos (String dbpath)
        {
            _conexion = new SQLite.SQLiteAsyncConnection(dbpath);

            //Creacion de Objetos de Base de datos
            _conexion.CreateTableAsync<Models.Equipos>().Wait();

        }

        // CRUD - Create / Read / Update / Delete
        public System.Threading.Tasks.Task <int> StoreEquipo(Models.Equipos equipo)
        {
            if(equipo.Id== 0)
            {
                return _conexion.InsertAsync(equipo);
            }
            else
            {
                return _conexion.UpdateAsync(equipo);
            }

        }

        //Read - list
        public Task<List<Models.Equipos>> ListaEquipos()
        {
            return _conexion.Table<Models.Equipos>().ToListAsync();
        }
        //Get
        public Task<Models.Equipos> GetEquipos(int pid) 
        {
            return _conexion.Table<Models.Equipos>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }
        //Delete
        public Task<int> DeleteEquipo(Models.Equipos equipos)
        {
            return _conexion.DeleteAsync(equipos);
        }

    }
}
