using AuthSystem.Models;
using System.Text.Json.Serialization;

namespace PFA.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EndroitId { get; set; }
        public DateTime VisitDate { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Endroit Endroit { get; set; }
    }
}
