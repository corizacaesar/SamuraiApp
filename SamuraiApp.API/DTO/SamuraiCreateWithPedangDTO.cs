namespace SamuraiApp.API.DTO
{
    public class SamuraiCreateWithPedangDTO
    {
        public string Name { get; set; }
        public List<PedangCreateDTO> Pedangs { get; set; } = new List<PedangCreateDTO>();
    }
}
