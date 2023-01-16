using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Belu_Ioana_Proiect.Models
{
    public class ListaAlimente
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Jurnal))]
        public int JurnalID { get; set; }
        public int AlimenteID { get; set; }
    }
}
