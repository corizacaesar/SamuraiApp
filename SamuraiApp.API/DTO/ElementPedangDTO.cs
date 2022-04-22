using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class ElementPedangDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int TahunPembuatan { get; set; }
        public int Berat { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
    }
}
