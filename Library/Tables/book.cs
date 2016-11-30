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
        public string name_book { get; set; }
        public string year { get; set; }
        public string number_pages { get; set; }
        public string number_copies { get; set; }

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
