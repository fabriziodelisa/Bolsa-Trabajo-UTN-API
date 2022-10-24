using ApiBolsaTrabajoUTN.API.Enums;
using System.Text.Json.Serialization;

namespace ApiBolsaTrabajoUTN.API.Models.Career
{
    public class CareerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CareerTypes Type { get; set; }
        public string? Abbreviation { get; set; }
        public int TotalSubjets { get; set; }
    }
}
