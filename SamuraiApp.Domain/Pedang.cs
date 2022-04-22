using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Pedang
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int TahunPembuatan { get; set; }
        public int Berat { get; set; }
        public Samurai Samurai { get; set; }
        public int? SamuraiId { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();

    }
}
