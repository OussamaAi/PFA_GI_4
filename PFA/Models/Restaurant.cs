namespace AuthSystem.Models
{
    public class Restaurant:Endroit
    {
       
         
        public string? TypeCuisine { get; set; }
        public DateTime? HeureOuverture { get; set; }
        public DateTime? HeureFermeture { get; set; }

        public IList<Table>? Tables { get; set; }

         
    }
}
