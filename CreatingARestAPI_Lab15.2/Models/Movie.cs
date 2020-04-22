using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingARestAPI_Lab15._2.Models
{
    public class Movie
    {
        private int id;
        private string name;
        private string category;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
    }
}
