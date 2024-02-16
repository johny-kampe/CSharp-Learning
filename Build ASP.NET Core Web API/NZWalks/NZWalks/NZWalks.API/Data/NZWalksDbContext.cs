using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the data for Difficulties  
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImgUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImgUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImgUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImgUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImgUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);


            var walks = new List<Walk>
            {
                new Walk
                {
                    Id = Guid.Parse("327aa9f7-26f7-4ddb-8047-97464374bb63"),
                    Name = "Mount Victoria Loop",
                    Description = "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.",
                    LenghtInKm = 3.5,
                    WalkImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionID = Guid.Parse("CFA06ED2-BF65-4B65-93ED-C9D286DDB0DE")
                },
                new Walk
                {
                    Id = Guid.Parse("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"),
                    Name = "Makara Beach Walkway",
                    Description = "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.",
                    LenghtInKm = 8.2,
                    WalkImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("CFA06ED2-BF65-4B65-93ED-C9D286DDB0DE")
                },
                new Walk
                {
                    Id = Guid.Parse("09601132-f92d-457c-b47e-da90e117b33c"),
                    Name = "Botanic Garden Walk",
                    Description = "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.",
                    LenghtInKm = 2,
                    WalkImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionID = Guid.Parse("CFA06ED2-BF65-4B65-93ED-C9D286DDB0DE")
                },
                new Walk
                {
                    Id = Guid.Parse("30d654c7-89ac-4704-8333-5065b740150b"),
                    Name = "Mount Eden Summit Walk",
                    Description = "This walk takes you to the summit of Mount Eden, the highest natural point in Auckland, with panoramic views of the city.",
                    LenghtInKm = 2,
                    WalkImgUrl = "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionID = Guid.Parse("F7248FC3-2585-4EFB-8D1D-1C555F4087F6")
                },
                new Walk
                {
                    Id = Guid.Parse("f7578324-f025-4c86-83a9-37a7f3d8fe81"),
                    Name = "Cornwall Park Walk",
                    Description = "Explore the beautiful Cornwall Park on this leisurely walk, with a wide variety of trees, gardens, and animals to admire.",
                    LenghtInKm = 3,
                    WalkImgUrl = "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("54466F17-02AF-48E7-8ED3-5A4A8BFACF6F"),
                    RegionID = Guid.Parse("F7248FC3-2585-4EFB-8D1D-1C555F4087F6")
                },
                new Walk
                {
                    Id = Guid.Parse("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"),
                    Name = "Takapuna to Milford Coastal Walk",
                    Description = "This coastal walk takes you along the beautiful beaches of Takapuna and Milford, with stunning views of Rangitoto Island.",
                    LenghtInKm = 5,
                    WalkImgUrl = "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("F7248FC3-2585-4EFB-8D1D-1C555F4087F6")
                },
                new Walk
                {
                    Id = Guid.Parse("43132402-3d5e-467a-8cde-351c5c7c5dde"),
                    Name = "Centre of New Zealand Walkway",
                    Description = "This walk takes you to the geographical centre of New Zealand, with stunning views of Nelson and its surroundings.",
                    LenghtInKm = 1.0,
                    WalkImgUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("906CB139-415A-4BBB-A174-1A1FAF9FB1F6")
                },
                new Walk
                {
                    Id = Guid.Parse("1ea0b064-2d44-4324-91ee-6dd86c91b713"),
                    Name = "Maitai Valley Walk",
                    Description = "Explore the picturesque Maitai Valley on this easy walk, with a tranquil river and native bush to enjoy.",
                    LenghtInKm = 5.0,
                    WalkImgUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("906CB139-415A-4BBB-A174-1A1FAF9FB1F6")
                },
                new Walk
                {
                    Id = Guid.Parse("04ab77f0-e145-4fbf-b641-989df24e5573"),
                    Name = "Boulder Bank Walkway",
                    Description = "This coastal walk takes you along the unique Boulder Bank, a long narrow bar of rocks that extends into Tasman Bay.",
                    LenghtInKm = 8.0,
                    WalkImgUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("F808DDCD-B5E5-4D80-B732-1CA523E48434"),
                    RegionID = Guid.Parse("906CB139-415A-4BBB-A174-1A1FAF9FB1F6")
                },
                new Walk
                {
                    Id = Guid.Parse("b5aa2791-3616-4db6-ab33-c54d03d17f62"),
                    Name = "Mount Maunganui Summit Walk",
                    Description = "This walk takes you to the summit of Mount Maunganui, with stunning views of the ocean and surrounding landscape.",
                    LenghtInKm = 3.0,
                    WalkImgUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("14CEBA71-4B51-4777-9B17-46602CF66153")
                },
                new Walk
                {
                    Id = Guid.Parse("2d9d6604-bef9-4b0a-805d-630240a29595"),
                    Name = "The Papamoa Hills Regional Park Walk",
                    Description = "Enjoy panoramic views of Tauranga and Mount Maunganui on this walk through the Papamoa Hills, with a mix of bush and open farmland.",
                    LenghtInKm = 5.0,
                    WalkImgUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("14CEBA71-4B51-4777-9B17-46602CF66153")
                },
                new Walk
                {
                    Id = Guid.Parse("135a6e58-969f-47e1-8278-d7fbf2b3bd69"),
                    Name = "The White Pine Bush Track",
                    Description = "Explore the lush and peaceful White Pine Bush on this easy walk, with a variety of native flora and fauna to discover.",
                    LenghtInKm = 2.0,
                    WalkImgUrl = "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("14CEBA71-4B51-4777-9B17-46602CF66153")
                },
                new Walk
                {
                    Id = Guid.Parse("24ef9346-17e2-467e-bfc0-d062a9042bf1"),
                    Name = "The Bluff Hill Walkway",
                    Description = "This walk takes you to the top of Bluff Hill, with panoramic views of Bluff and the surrounding coastline.",
                    LenghtInKm = 6.0,
                    WalkImgUrl = "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C"),
                    RegionID = Guid.Parse("F077A22E-4248-4BF6-B564-C7CF4E250263")
                },
                new Walk
                {
                    Id = Guid.Parse("f2b56c63-eb99-475a-881c-278f3da03e3d"),
                    Name = "The Kepler Track",
                    Description = "One of New Zealand’s most famous walks, the Kepler Track offers stunning alpine vistas and takes you through a range of landscapes from peaceful beech forests to open tussock lands.",
                    LenghtInKm = 32.0,
                    WalkImgUrl = "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("F808DDCD-B5E5-4D80-B732-1CA523E48434"),
                    RegionID = Guid.Parse("F077A22E-4248-4BF6-B564-C7CF4E250263")
                },
                new Walk
                {
                    Id = Guid.Parse("a7796ab6-5426-46af-b755-65d9b9e12978"),
                    Name = "The Hump Ridge Track",
                    Description = "Experience the stunning scenery of the southern Fiordland and the coast on this challenging multi-day walk, with beautiful forest and alpine views.",
                    LenghtInKm = 60.0,
                    WalkImgUrl = "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    DifficultyId = Guid.Parse("F808DDCD-B5E5-4D80-B732-1CA523E48434"),
                    RegionID = Guid.Parse("F077A22E-4248-4BF6-B564-C7CF4E250263")
                }
            };

            modelBuilder.Entity<Walk>().HasData(walks);
        }
    }
}
