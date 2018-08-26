using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    class cart
    {
        [PrimaryKey]
        public string product_name { get; set; }


        public string account_name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double percent { get; set; }
        public double subtotal { get; set; }
    }
}
