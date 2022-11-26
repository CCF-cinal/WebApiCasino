namespace WebApiCasino.Entidades
{
    public class Rifa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Participante> participantes { get; set; }
        public List<Premio> premios { get; set; }
        //public int Sumatoria { get; set; }
    }
}
