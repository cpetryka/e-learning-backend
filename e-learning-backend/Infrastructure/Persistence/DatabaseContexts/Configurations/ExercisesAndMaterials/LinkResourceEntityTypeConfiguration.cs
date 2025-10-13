using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class LinkResourceEntityTypeConfiguration : IEntityTypeConfiguration<LinkResource>
{
    public void Configure(EntityTypeBuilder<LinkResource> builder)
    {
        builder.HasKey(cl => cl.Id);
        builder.Property(cl => cl.Link)
            .IsRequired()
            .HasMaxLength(500);
        
        var classId1 = Guid.Parse("43333333-3333-3333-3333-333333333333");
        var classId2 = Guid.Parse("53333333-3333-3333-3333-333333333333");
        var classId3 = Guid.Parse("63333333-3333-3333-3333-333333333333");
        var classId4 = Guid.Parse("73333333-3333-3333-3333-333333333333");
        var classId5 = Guid.Parse("83333333-3333-3333-3333-333333333333");
        var classId6 = Guid.Parse("93333333-3333-3333-3333-333333333333");
        
       builder.HasData(
        new
        {
            Id = Guid.Parse("f7ac9193-6db7-4ee4-98bf-4de600903c86"),
            Link = "https://example.com/resource/11c21ef3",
            ClassId = Guid.Parse("5e232654-e629-49e3-98c2-4559505165c6"),
            Date = new DateTime(2025, 10, 8, 2, 27, 9, 371, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("56ff1d6b-5506-4494-b280-ae79eb600fce"),
            Link = "https://example.com/resource/6d5b7d85",
            ClassId = Guid.Parse("d0df950c-ad65-4fc0-8e10-64788b75781a"),
            Date = new DateTime(2025, 12, 28, 15, 58, 32, 384, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("a610d0f3-2bf5-4463-adc1-ff706fe1f3ac"),
            Link = "https://example.com/resource/35efc4a8",
            ClassId = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8"),
            Date = new DateTime(2026, 3, 11, 11, 54, 14, 636, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("5544cd52-bf28-4f59-875c-e38d869dbf95"),
            Link = "https://example.com/resource/556eaa9b",
            ClassId = Guid.Parse("d539b5bd-da7d-4d50-9f6d-bcee91ef88fb"),
            Date = new DateTime(2026, 1, 9, 18, 12, 30, 664, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("af020b67-1310-443b-8836-66c41aefab7a"),
            Link = "https://example.com/resource/f7181d15",
            ClassId = Guid.Parse("1619b967-7450-472f-9ced-a9c4ab701318"),
            Date = new DateTime(2025, 12, 19, 0, 1, 42, 986, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("db1c3b6e-0df6-4151-b968-ff8bc1873550"),
            Link = "https://example.com/resource/572c3f02",
            ClassId = Guid.Parse("54231f0d-9be4-4b19-ac3c-307411c36d84"),
            Date = new DateTime(2026, 2, 25, 18, 15, 0, 795, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("36f23c8a-93af-42d6-86b9-f58f525fb31c"),
            Link = "https://example.com/resource/edbef2a0",
            ClassId = Guid.Parse("898a95d6-d2fb-4519-b6ee-fc4928a2831e"),
            Date = new DateTime(2026, 1, 10, 10, 20, 16, 429, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("5ebd3b72-51de-482d-b792-247dca75d90f"),
            Link = "https://example.com/resource/03fd2fae",
            ClassId = Guid.Parse("bfbd200d-398b-4789-a002-32ea570134eb"),
            Date = new DateTime(2025, 12, 10, 18, 21, 54, 491, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("956c754f-72b1-4ce1-81e7-8fd512f4117f"),
            Link = "https://example.com/resource/06dc63db",
            ClassId = Guid.Parse("809377e4-4e50-4f00-92e2-fae20a9ce4d4"),
            Date = new DateTime(2025, 12, 14, 13, 9, 16, 233, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("81cb9a10-6fe9-4dca-8815-9ba2e853ae39"),
            Link = "https://example.com/resource/b547c9f5",
            ClassId = Guid.Parse("4d93311e-5e96-41e3-8b56-7035de6b7000"),
            Date = new DateTime(2025, 12, 8, 20, 16, 35, 608, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("5c17fa1c-75cd-44d9-b568-e0f67c7394d2"),
            Link = "https://example.com/resource/3deb84e6",
            ClassId = Guid.Parse("bc146c66-85f0-4d8e-94bc-d9bdaeb6f1c4"),
            Date = new DateTime(2026, 2, 6, 12, 32, 21, 730, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("44819bc1-a56c-40ea-909b-e13e0782da59"),
            Link = "https://example.com/resource/cf16b6be",
            ClassId = Guid.Parse("f8190291-dccf-4321-8e66-a13e616df8de"),
            Date = new DateTime(2026, 1, 14, 3, 35, 47, 445, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("acf69f38-7735-4f07-a5e4-da517aa9d946"),
            Link = "https://example.com/resource/f4a2d9f2",
            ClassId = Guid.Parse("e85e13df-ffd8-40c8-866c-8a3d5b62c968"),
            Date = new DateTime(2026, 2, 28, 8, 24, 30, 492, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("98c966c9-b79c-4eb4-8204-28c0f19e9954"),
            Link = "https://example.com/resource/a5dd046a",
            ClassId = Guid.Parse("8053903f-146d-4795-931c-f802e8628cbd"),
            Date = new DateTime(2026, 1, 25, 10, 57, 28, 803, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("9cfc0865-c3bd-466f-a920-b825203ba3dc"),
            Link = "https://example.com/resource/b419ddb4",
            ClassId = Guid.Parse("8cf5c033-1abf-4a96-8249-ad591b102dfc"),
            Date = new DateTime(2026, 1, 28, 5, 39, 50, 194, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("aaa668d4-7e6c-4514-8531-37fabe85bb26"),
            Link = "https://example.com/resource/a4f5b900",
            ClassId = Guid.Parse("f4fda6f5-96b8-4195-bc5b-944b34523e56"),
            Date = new DateTime(2025, 10, 19, 12, 57, 58, 754, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("e8871cf4-bea0-48b2-8291-c5098d16de3b"),
            Link = "https://example.com/resource/95b06884",
            ClassId = Guid.Parse("eb09b8ac-f801-44ff-85dd-6f63f6213603"),
            Date = new DateTime(2026, 1, 12, 8, 58, 38, 889, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("8d712159-abca-4523-a06b-e46f49ea8ec1"),
            Link = "https://example.com/resource/a4d03d5c",
            ClassId = Guid.Parse("bb271e47-7532-4488-8c9b-84856e35de10"),
            Date = new DateTime(2025, 12, 16, 0, 22, 39, 40, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("f1100f3d-281a-4c1c-b860-e4aaea16561b"),
            Link = "https://example.com/resource/d8f85e8e",
            ClassId = Guid.Parse("56e6affb-1bf8-4953-b14e-0899824125ac"),
            Date = new DateTime(2025, 11, 6, 8, 18, 59, 681, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("ffbd8ded-bec5-44d2-9b20-7803eef3d551"),
            Link = "https://example.com/resource/5b00798d",
            ClassId = Guid.Parse("5a96d050-90f7-41b3-bc8d-ad8ac2213455"),
            Date = new DateTime(2026, 1, 25, 2, 8, 8, 782, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("ca4d6504-57b9-48bf-828b-8aa53cb59ad3"),
            Link = "https://example.com/resource/f8ab544f",
            ClassId = Guid.Parse("2980c5de-ed0b-4115-9610-0688ab9ec4b5"),
            Date = new DateTime(2025, 11, 9, 12, 4, 22, 793, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("5c7b6e57-52fd-4063-a721-6b70017b8ccd"),
            Link = "https://example.com/resource/efd97512",
            ClassId = Guid.Parse("64de3b52-e261-4152-81fd-f1d74e3f7046"),
            Date = new DateTime(2026, 1, 14, 8, 56, 56, 352, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("99623b57-5946-4acf-9b4e-93965be65d2c"),
            Link = "https://example.com/resource/02a83f8f",
            ClassId = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63"),
            Date = new DateTime(2025, 11, 15, 16, 5, 58, 333, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("b3816847-2a11-4d28-8ab5-b1c654f2a053"),
            Link = "https://example.com/resource/17aa602c",
            ClassId = Guid.Parse("af2e3f3b-7d87-4834-8375-e2cbb87fac0c"),
            Date = new DateTime(2026, 2, 4, 14, 41, 34, 905, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("cef42c30-a3b5-49fb-ad14-4d60d1d5cbef"),
            Link = "https://example.com/resource/1baddb55",
            ClassId = Guid.Parse("9d186474-9046-4b72-b1e5-2b727d6bbcaf"),
            Date = new DateTime(2025, 10, 15, 22, 6, 6, 762, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("25aef597-cd74-4137-9b35-bbc9f8c6b605"),
            Link = "https://example.com/resource/0f6f46f1",
            ClassId = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de"),
            Date = new DateTime(2026, 2, 19, 21, 12, 3, 297, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("b5c18d07-9e2e-4425-8e27-833a1435eab2"),
            Link = "https://example.com/resource/6ae98cca",
            ClassId = Guid.Parse("f7cfc20c-93a3-475d-86a2-b8e85b8c67fe"),
            Date = new DateTime(2026, 2, 8, 15, 35, 15, 761, DateTimeKind.Utc)
        },
        new
        {
            Id = Guid.Parse("649c2ff0-02d0-40a8-a204-4afed3557c22"),
            Link = "https://example.com/resource/d11dcbeb",
            ClassId = Guid.Parse("d5665dc7-79cd-4752-94a5-655fb2bca54d"),
            Date = new DateTime(2026, 1, 10, 7, 10, 52, 417, DateTimeKind.Utc)
        }
);
    }
}