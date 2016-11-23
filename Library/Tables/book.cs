using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tables
{
    public class Book: IEntity
    {
        public int id_library_cipher { get; set; }
        public string author { get; set; }
        public int ID_test { get; set; }

        public Type GetEntityType()
        {
            return typeof(Book);
        }

        public string GetIDField()
        {
            return "id_library_cipher";
        }

        public int ID()
        {
            return id_library_cipher;
        }
    }
}
