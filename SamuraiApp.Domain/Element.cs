using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Element
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public Pedang Pedang { get; set; }
        public int? PedangId { get; set; }
    }
}
