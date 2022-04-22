namespace SamuraiApp.API.DTO
{
    public class PedangCreateWithElementDTO
    {
        public string Nama { get; set; }
        public int TahunPembuatan { get; set; }
        public int Berat { get; set; }
        public List<ElementDTO> Elements { get; set; } = new List<ElementDTO>();
    }
}
