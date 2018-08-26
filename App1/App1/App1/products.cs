using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    class products
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string image { get; set; }
        public string type { get; set; }
        [Unique]
        public string product_name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}
