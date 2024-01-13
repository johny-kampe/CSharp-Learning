namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LenghtInKm { get; set; }
        public string? WalkImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionID { get; set; }

        
        // Navigation properties 
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
