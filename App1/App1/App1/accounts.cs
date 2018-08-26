using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    class accounts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int contact { get; set; }
    }
}
