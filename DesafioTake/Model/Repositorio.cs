using System.ComponentModel;

namespace DesafioTake.Model
{
    public class Repositorio
    {
        public string Full_Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public DateTime Created_At { get; set; }
	public string Language { get; set; }
    }
}
