namespace WebAPI.Models
{
    public class ListaItem
    {
        public int Id { get; set; }
        public string? Tytul { get; set; }
        public string? Rezyser { get; set; }
        public string? Gatunek { get; set; }
        public int Rok_wydania { get; set; }
    }
}