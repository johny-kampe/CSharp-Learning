using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForWalksDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LenghtInKm = table.Column<double>(type: "float", nullable: false),
                    WalkImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Easy" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), "Medium" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LenghtInKm", "Name", "RegionID", "WalkImgUrl" },
                values: new object[,]
                {
                    { new Guid("04ab77f0-e145-4fbf-b641-989df24e5573"), "This coastal walk takes you along the unique Boulder Bank, a long narrow bar of rocks that extends into Tasman Bay.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 8.0, "Boulder Bank Walkway", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("09601132-f92d-457c-b47e-da90e117b33c"), "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 2.0, "Botanic Garden Walk", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("135a6e58-969f-47e1-8278-d7fbf2b3bd69"), "Explore the lush and peaceful White Pine Bush on this easy walk, with a variety of native flora and fauna to discover.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 2.0, "The White Pine Bush Track", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("1cc5f2bc-ff4b-47c0-a475-1add56c6497b"), "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 8.1999999999999993, "Makara Beach Walkway", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("1ea0b064-2d44-4324-91ee-6dd86c91b713"), "Explore the picturesque Maitai Valley on this easy walk, with a tranquil river and native bush to enjoy.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "Maitai Valley Walk", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("24ef9346-17e2-467e-bfc0-d062a9042bf1"), "This walk takes you to the top of Bluff Hill, with panoramic views of Bluff and the surrounding coastline.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 6.0, "The Bluff Hill Walkway", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("2d9d6604-bef9-4b0a-805d-630240a29595"), "Enjoy panoramic views of Tauranga and Mount Maunganui on this walk through the Papamoa Hills, with a mix of bush and open farmland.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "The Papamoa Hills Regional Park Walk", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("30d654c7-89ac-4704-8333-5065b740150b"), "This walk takes you to the summit of Mount Eden, the highest natural point in Auckland, with panoramic views of the city.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 2.0, "Mount Eden Summit Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("327aa9f7-26f7-4ddb-8047-97464374bb63"), "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 3.5, "Mount Victoria Loop", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("43132402-3d5e-467a-8cde-351c5c7c5dde"), "This walk takes you to the geographical centre of New Zealand, with stunning views of Nelson and its surroundings.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 1.0, "Centre of New Zealand Walkway", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("a7796ab6-5426-46af-b755-65d9b9e12978"), "Experience the stunning scenery of the southern Fiordland and the coast on this challenging multi-day walk, with beautiful forest and alpine views.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 60.0, "The Hump Ridge Track", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("b5aa2791-3616-4db6-ab33-c54d03d17f62"), "This walk takes you to the summit of Mount Maunganui, with stunning views of the ocean and surrounding landscape.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 3.0, "Mount Maunganui Summit Walk", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("bdf28703-6d0e-4822-ad8b-e2923f4e95a2"), "This coastal walk takes you along the beautiful beaches of Takapuna and Milford, with stunning views of Rangitoto Island.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 5.0, "Takapuna to Milford Coastal Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f2b56c63-eb99-475a-881c-278f3da03e3d"), "One of New Zealand’s most famous walks, the Kepler Track offers stunning alpine vistas and takes you through a range of landscapes from peaceful beech forests to open tussock lands.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 32.0, "The Kepler Track", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f7578324-f025-4c86-83a9-37a7f3d8fe81"), "Explore the beautiful Cornwall Park on this leisurely walk, with a wide variety of trees, gardens, and animals to admire.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 3.0, "Cornwall Park Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionID",
                table: "Walks",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
