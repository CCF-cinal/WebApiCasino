namespace WebApiCasino.Entidades
{
    public class Premio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RifaId { get; set; }
        public Rifa Rifa { get; set; }
    }
}
