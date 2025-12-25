using System; // DateTime için

namespace CommonIssues.Models 
{
    public class Issue // Issues tablosu modeli
    {
        public int Id { get; set; } // PK=Id

        public required string Title { get; set; } 
        // Boş geçilemez, zorunlu alan

        public required string Description { get; set; } 
        // Açıklama

        public required string Location { get; set; } 
        // Yer bilgisi 

        public required string Status { get; set; } 
        // Açık / Çözüldü

        public DateTime CreatedDate { get; set; } 
        // Kayıt tarihi
    }
}
