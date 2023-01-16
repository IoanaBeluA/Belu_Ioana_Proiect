using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belu_Ioana_Proiect.Models;


namespace Belu_Ioana_Proiect.Data
{
    public class JurnalDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public JurnalDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Jurnal>().Wait();
            _database.CreateTableAsync<Alimente>().Wait();
            _database.CreateTableAsync<ListaAlimente>().Wait();

        }
        public Task<List<Jurnal>> GetJurnalAsync()
        {
            return _database.Table<Jurnal>().ToListAsync();
        }
        public Task<Jurnal> GetJurnalAsync(int id)
        {
            return _database.Table<Jurnal>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveJurnalAsync(Jurnal slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteJurnalAsync(Jurnal slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveAlimenteAsync(Alimente alimente)
        {
            if (alimente.ID != 0)
            {
                return _database.UpdateAsync(alimente);
            }
            else
            {
                return _database.InsertAsync(alimente);
            }
        }
        public Task<int> DeleteAlimenteAsync(Alimente alimente)
        {
            return _database.DeleteAsync(alimente);
        }
        public Task<List<Alimente>> GetAlimenteAsync()
        {
            return _database.Table<Alimente>().ToListAsync();
        }
        public Task<int> SaveListaAlimenteAsync(ListaAlimente listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Alimente>> GetListaAlimenteAsync(int jurnalid)
        {
            return _database.QueryAsync<Alimente>(
            "select P.ID, P.Description from Alimente P"
            + " inner join ListaAlimente LP"
            + " on P.ID = LP.AlimenteID where LP.JurnalID = ?",
            jurnalid);
        }
    }
}
