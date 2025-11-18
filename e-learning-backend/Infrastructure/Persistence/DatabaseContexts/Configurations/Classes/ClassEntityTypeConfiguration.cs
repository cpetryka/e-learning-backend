using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ClassEntityTypeConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Status)
            .WithMany()
            .HasForeignKey("ClassStatusId");

        builder.HasOne(c => c.Participation)
            .WithMany(p => p.Classes)
            .HasForeignKey(c => new { c.UserId, c.CourseId });

        builder.HasMany(c => c.Exercises)
            .WithOne(e => e.Class)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Files)
            .WithMany(f => f.Classes)
            .UsingEntity<Dictionary<string, object>>(
                "ClassFileResources", // nazwa tabeli pośredniczącej
                j => j
                    .HasOne<FileResource>()
                    .WithMany()
                    .HasForeignKey("FileResourceId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Class>()
                    .WithMany()
                    .HasForeignKey("ClassId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("ClassId", "FileResourceId");
                    j.HasData(
                        new
                        {
                            ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668"),
                            FileResourceId = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee")
                        },
                        new
                        {
                            ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668"),
                            FileResourceId = Guid.Parse("2d19abfd-6294-4374-80c1-113bb3df4082")
                        },
                        new
                        {
                            ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668"),
                            FileResourceId = Guid.Parse("80d90177-0b0b-45f5-bfd5-d1253b36bf53")
                        },
                        new
                        {
                            ClassId = Guid.Parse("3b436cdc-53ea-4c80-a947-ca1a7ccc350b"),
                            FileResourceId = Guid.Parse("2ad1247f-c66f-4f8c-ae0a-b9b0f11335fb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("04806df7-dc2d-481a-ab6a-fcf2be9cc16c"),
                            FileResourceId = Guid.Parse("892bd76e-c178-4f11-ba21-f6191b8da7e9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("04806df7-dc2d-481a-ab6a-fcf2be9cc16c"),
                            FileResourceId = Guid.Parse("93318896-c586-402b-a540-79760e0adb6f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("dd03fc90-7914-4c41-901f-feeae24142df"),
                            FileResourceId = Guid.Parse("36253f18-096f-42d0-8aae-60cb3c88cd97")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5e232654-e629-49e3-98c2-4559505165c6"),
                            FileResourceId = Guid.Parse("99f7a00e-a1ac-416a-ab62-d99f121db7ca")
                        },
                        new
                        {
                            ClassId = Guid.Parse("10761475-fd6f-452f-9817-0f5b11e907a9"),
                            FileResourceId = Guid.Parse("34f94c2f-fd23-45b1-8c88-f8b8a8dd21fc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("10761475-fd6f-452f-9817-0f5b11e907a9"),
                            FileResourceId = Guid.Parse("5a3892b1-8d2b-48bf-81ad-085eeed7f4cc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("10761475-fd6f-452f-9817-0f5b11e907a9"),
                            FileResourceId = Guid.Parse("e8482fb8-6886-42ac-9ccf-993a15327f9b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("a3c2b920-a1b2-4cd2-8db4-4945b467ce2f"),
                            FileResourceId = Guid.Parse("47fbd7e1-c3ed-4d59-93c9-4aaa1e4813fb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("a3c2b920-a1b2-4cd2-8db4-4945b467ce2f"),
                            FileResourceId = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("a3c2b920-a1b2-4cd2-8db4-4945b467ce2f"),
                            FileResourceId = Guid.Parse("892bd76e-c178-4f11-ba21-f6191b8da7e9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9005a051-a079-4dc2-82b9-f7b3ab128b2f"),
                            FileResourceId = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d0df950c-ad65-4fc0-8e10-64788b75781a"),
                            FileResourceId = Guid.Parse("e5a65f43-d917-4574-b6a1-0178cfb02fc7")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d3fd515d-c9a8-4a12-ae4b-045d2baaa725"),
                            FileResourceId = Guid.Parse("229fbf70-010a-4114-a41e-7e523e960e95")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d3fd515d-c9a8-4a12-ae4b-045d2baaa725"),
                            FileResourceId = Guid.Parse("506736bf-1e54-43bf-b889-803770af3634")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d3fd515d-c9a8-4a12-ae4b-045d2baaa725"),
                            FileResourceId = Guid.Parse("13d308dd-3a86-49a7-830a-2314d8a22a8c")
                        },
                        new
                        {
                            ClassId = Guid.Parse("a9b47a16-dd1a-4d4c-aab5-a2f2156dc72d"),
                            FileResourceId = Guid.Parse("dee85c51-24b8-4786-97d7-a844d4267769")
                        },
                        new
                        {
                            ClassId = Guid.Parse("653977fd-d020-4c27-90e4-2232412ef2f5"),
                            FileResourceId = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec")
                        },
                        new
                        {
                            ClassId = Guid.Parse("653977fd-d020-4c27-90e4-2232412ef2f5"),
                            FileResourceId = Guid.Parse("5a3892b1-8d2b-48bf-81ad-085eeed7f4cc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("653977fd-d020-4c27-90e4-2232412ef2f5"),
                            FileResourceId = Guid.Parse("a830f453-ac0b-4158-b599-4a2bec66a09f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8"),
                            FileResourceId = Guid.Parse("4f95d674-b2e2-479a-98ae-bfdf3913870a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8"),
                            FileResourceId = Guid.Parse("14762566-eca5-4870-a740-1328557c7885")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8"),
                            FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c5374e7c-5922-4208-820c-83b7bef81ea8"),
                            FileResourceId = Guid.Parse("1f5a05cb-46ef-4b2b-b9b2-588633a77330")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c5374e7c-5922-4208-820c-83b7bef81ea8"),
                            FileResourceId = Guid.Parse("740dc3b7-7a86-4280-ba1d-69af6626aaaa")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c5374e7c-5922-4208-820c-83b7bef81ea8"),
                            FileResourceId = Guid.Parse("fbb35abf-3399-41a4-8645-5529b5a0afb6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2c7ddd20-534a-4f7f-a722-909ab0a67aad"),
                            FileResourceId = Guid.Parse("31ec03c1-e879-47c4-8d6f-a8df029e51bc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2c7ddd20-534a-4f7f-a722-909ab0a67aad"),
                            FileResourceId = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2c7ddd20-534a-4f7f-a722-909ab0a67aad"),
                            FileResourceId = Guid.Parse("9efea894-ffa2-4d5c-b8e7-f555982d489a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("79c9212c-dc94-4f45-aca9-b35eecacc8d2"),
                            FileResourceId = Guid.Parse("109a9818-fbbc-45a5-bbf5-eb0d8917146d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("79c9212c-dc94-4f45-aca9-b35eecacc8d2"),
                            FileResourceId = Guid.Parse("2efadb1c-bd85-4b08-81c5-e4082a3d07b8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("79c9212c-dc94-4f45-aca9-b35eecacc8d2"),
                            FileResourceId = Guid.Parse("7122a8dc-cbbf-4009-b205-c93a1f6beffa")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d539b5bd-da7d-4d50-9f6d-bcee91ef88fb"),
                            FileResourceId = Guid.Parse("7e845b9d-c2a9-4c59-97de-892a4ac387d9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d539b5bd-da7d-4d50-9f6d-bcee91ef88fb"),
                            FileResourceId = Guid.Parse("5b84ceba-3936-4c1e-9c61-0c95bb6ab2ad")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d539b5bd-da7d-4d50-9f6d-bcee91ef88fb"),
                            FileResourceId = Guid.Parse("edb3c2db-481f-4ddc-bd52-243c5b67d8fa")
                        },
                        new
                        {
                            ClassId = Guid.Parse("eaf96048-a284-43eb-a1df-c18ab9c0c2c1"),
                            FileResourceId = Guid.Parse("ab5adb07-1292-49d4-8fed-109fd46f15e5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("eaf96048-a284-43eb-a1df-c18ab9c0c2c1"),
                            FileResourceId = Guid.Parse("2424fb63-5288-4071-b551-0a338c17d9db")
                        },
                        new
                        {
                            ClassId = Guid.Parse("eaf96048-a284-43eb-a1df-c18ab9c0c2c1"),
                            FileResourceId = Guid.Parse("ceb337a0-55b3-4ceb-8870-8d5796a09aa2")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6a505e6f-15c5-45b0-973c-b2ad02388314"),
                            FileResourceId = Guid.Parse("8ae9bba1-7234-44dc-9990-43e92623a8a6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6a505e6f-15c5-45b0-973c-b2ad02388314"),
                            FileResourceId = Guid.Parse("af7b709e-c04f-43bc-a73a-438c82180924")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6a505e6f-15c5-45b0-973c-b2ad02388314"),
                            FileResourceId = Guid.Parse("0470fa1e-b365-49cb-9516-8949ca60be85")
                        },
                        new
                        {
                            ClassId = Guid.Parse("597b6fe3-57e6-4831-a07c-991de998bfe2"),
                            FileResourceId = Guid.Parse("1c4237a0-6a5f-4820-a25e-b8a287b7e816")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a6b2eb1-25fe-465b-b2ea-56d584528c87"),
                            FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a6b2eb1-25fe-465b-b2ea-56d584528c87"),
                            FileResourceId = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5f50d51c-ba7f-4bb7-bf3f-88b1c10cbcf0"),
                            FileResourceId = Guid.Parse("c33ca3a8-436b-464a-8478-f18ef90d7c88")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5f50d51c-ba7f-4bb7-bf3f-88b1c10cbcf0"),
                            FileResourceId = Guid.Parse("08a2d00e-f098-4819-9b63-2601a2bfb797")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1619b967-7450-472f-9ced-a9c4ab701318"),
                            FileResourceId = Guid.Parse("b8f85bb4-1be7-437c-80a5-4963a13f81a3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1619b967-7450-472f-9ced-a9c4ab701318"),
                            FileResourceId = Guid.Parse("06692afa-8e02-4074-81e7-232d9c7c3beb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9dc8306e-d10a-473f-8d8c-24b8f04083a8"),
                            FileResourceId = Guid.Parse("830769a2-b9cc-478a-abb1-d266cf63f8b1")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9dc8306e-d10a-473f-8d8c-24b8f04083a8"),
                            FileResourceId = Guid.Parse("70f94315-d6c1-415d-b327-57430ee490c6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9dc8306e-d10a-473f-8d8c-24b8f04083a8"),
                            FileResourceId = Guid.Parse("0daa2725-4723-4d23-a2b7-a0cc78beb358")
                        },
                        new
                        {
                            ClassId = Guid.Parse("166b7349-a733-48e5-bb04-e9f0f5f1eeaf"),
                            FileResourceId = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4")
                        },
                        new
                        {
                            ClassId = Guid.Parse("fe37a1fd-f344-4940-ade7-bede9b784c78"),
                            FileResourceId = Guid.Parse("efd36d02-1d97-4fbe-a857-7aa4bc2e2efb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("fe37a1fd-f344-4940-ade7-bede9b784c78"),
                            FileResourceId = Guid.Parse("36851905-2710-4f01-b910-e4a1ffb65298")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1c617641-f474-4b97-b528-f1e0c2d31ced"),
                            FileResourceId = Guid.Parse("24dac690-6e8b-492e-8e17-9d3e537fb31e")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1c617641-f474-4b97-b528-f1e0c2d31ced"),
                            FileResourceId = Guid.Parse("2027b871-f60a-4d89-86fe-29d4d0b026db")
                        },
                        new
                        {
                            ClassId = Guid.Parse("54231f0d-9be4-4b19-ac3c-307411c36d84"),
                            FileResourceId = Guid.Parse("f8444b9b-13d7-4aaa-abda-3cb4420f4dab")
                        },
                        new
                        {
                            ClassId = Guid.Parse("54231f0d-9be4-4b19-ac3c-307411c36d84"),
                            FileResourceId = Guid.Parse("a85a21fd-8eb5-45e0-b33e-30cf35c82d9a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("54231f0d-9be4-4b19-ac3c-307411c36d84"),
                            FileResourceId = Guid.Parse("5a3892b1-8d2b-48bf-81ad-085eeed7f4cc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ca7d32b6-8910-4719-9ebf-ec1f79f6b3ab"),
                            FileResourceId = Guid.Parse("bcd14879-7cea-428a-b05f-27937fad0227")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ca7d32b6-8910-4719-9ebf-ec1f79f6b3ab"),
                            FileResourceId = Guid.Parse("7bf77641-6182-459f-aa06-7e081f8c20e3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ca7d32b6-8910-4719-9ebf-ec1f79f6b3ab"),
                            FileResourceId = Guid.Parse("49999268-5d22-48d1-bde0-2cde904c4821")
                        },
                        new
                        {
                            ClassId = Guid.Parse("88176c18-6d5e-4fef-9357-dcf5bb605044"),
                            FileResourceId = Guid.Parse("4473ad0f-5cf8-4b11-83f4-c4179a99fd84")
                        },
                        new
                        {
                            ClassId = Guid.Parse("88176c18-6d5e-4fef-9357-dcf5bb605044"),
                            FileResourceId = Guid.Parse("ea47bdf0-fff5-4be1-a832-307b7ddd6acb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("88176c18-6d5e-4fef-9357-dcf5bb605044"),
                            FileResourceId = Guid.Parse("744dc886-d2b2-4138-970b-46ed880e1c69")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f5839a47-28a6-4335-a4d2-eecfce6a1478"),
                            FileResourceId = Guid.Parse("ab5adb07-1292-49d4-8fed-109fd46f15e5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6bda0668-b6d4-4773-b822-e58816df0ebe"),
                            FileResourceId = Guid.Parse("540f91e0-9c31-40d6-a7ba-a8efd0bb46cf")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6bda0668-b6d4-4773-b822-e58816df0ebe"),
                            FileResourceId = Guid.Parse("2424fb63-5288-4071-b551-0a338c17d9db")
                        },
                        new
                        {
                            ClassId = Guid.Parse("898a95d6-d2fb-4519-b6ee-fc4928a2831e"),
                            FileResourceId = Guid.Parse("04c762ff-386e-45b5-acef-672582a5fe03")
                        },
                        new
                        {
                            ClassId = Guid.Parse("898a95d6-d2fb-4519-b6ee-fc4928a2831e"),
                            FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
                        },
                        new
                        {
                            ClassId = Guid.Parse("898a95d6-d2fb-4519-b6ee-fc4928a2831e"),
                            FileResourceId = Guid.Parse("cc4c7d3b-b1ae-426a-be8c-8de816030acd")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4a1ae34b-57bd-4b2c-b25d-2e9c8c5ed4c6"),
                            FileResourceId = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4a1ae34b-57bd-4b2c-b25d-2e9c8c5ed4c6"),
                            FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4a1ae34b-57bd-4b2c-b25d-2e9c8c5ed4c6"),
                            FileResourceId = Guid.Parse("94d95f4f-12f2-4f66-8898-4528d622a131")
                        },
                        new
                        {
                            ClassId = Guid.Parse("3a686937-654b-4085-a4cb-91c7e0e79dc9"),
                            FileResourceId = Guid.Parse("484dbaec-d078-48b2-8b59-2a2255dc9c8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("3a686937-654b-4085-a4cb-91c7e0e79dc9"),
                            FileResourceId = Guid.Parse("bb6f0516-516b-4290-9b90-2c0b1843df11")
                        },
                        new
                        {
                            ClassId = Guid.Parse("25fafe89-827a-4e61-8256-47f7be392839"),
                            FileResourceId = Guid.Parse("9b23217d-dc5b-47f9-a5a1-bc290a926dea")
                        },
                        new
                        {
                            ClassId = Guid.Parse("25fafe89-827a-4e61-8256-47f7be392839"),
                            FileResourceId = Guid.Parse("530c76c7-3499-4317-ab8e-bd6c8064069e")
                        },
                        new
                        {
                            ClassId = Guid.Parse("25fafe89-827a-4e61-8256-47f7be392839"),
                            FileResourceId = Guid.Parse("b9d6120d-0266-45c3-8a76-dc0fc1a740d6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("55d76dff-5ca6-4d7b-a80d-9a773b574406"),
                            FileResourceId = Guid.Parse("cf4d553c-e286-4267-9639-d5b02fad9c61")
                        },
                        new
                        {
                            ClassId = Guid.Parse("40e85018-7490-48b0-8eab-5368d5f73e22"),
                            FileResourceId = Guid.Parse("060deee0-d8c3-415d-8d87-77c7d98a62b6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("40e85018-7490-48b0-8eab-5368d5f73e22"),
                            FileResourceId = Guid.Parse("2c706c0c-53d2-423a-b571-6de36c6551ed")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8dad9090-9e0f-4629-86d8-b1295bf09b5f"),
                            FileResourceId = Guid.Parse("47fbd7e1-c3ed-4d59-93c9-4aaa1e4813fb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8dad9090-9e0f-4629-86d8-b1295bf09b5f"),
                            FileResourceId = Guid.Parse("4499d56c-1bcf-4a00-967f-f2c1499e3bb8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8dad9090-9e0f-4629-86d8-b1295bf09b5f"),
                            FileResourceId = Guid.Parse("060deee0-d8c3-415d-8d87-77c7d98a62b6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bfbd200d-398b-4789-a002-32ea570134eb"),
                            FileResourceId = Guid.Parse("3245277f-e208-4d6c-8716-d7347500dfa6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2e10ef79-df92-4442-879f-f8369864bb7c"),
                            FileResourceId = Guid.Parse("540f91e0-9c31-40d6-a7ba-a8efd0bb46cf")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2e10ef79-df92-4442-879f-f8369864bb7c"),
                            FileResourceId = Guid.Parse("36851905-2710-4f01-b910-e4a1ffb65298")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2e10ef79-df92-4442-879f-f8369864bb7c"),
                            FileResourceId = Guid.Parse("c5f4e126-2c33-4112-8767-43b4ccdddbd2")
                        },
                        new
                        {
                            ClassId = Guid.Parse("a4298748-5898-4089-9a00-cb6ca340f62a"),
                            FileResourceId = Guid.Parse("30b2d6e7-77b1-42bf-9df4-f01f4e256d70")
                        },
                        new
                        {
                            ClassId = Guid.Parse("a4298748-5898-4089-9a00-cb6ca340f62a"),
                            FileResourceId = Guid.Parse("5797af1d-cc70-43f1-af68-4e84b4b40ce8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("dfac9b08-8ef5-4476-a59c-735b2d58f3bd"),
                            FileResourceId = Guid.Parse("110c1e3e-35c3-4520-b78d-f6d7ec2b709b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8b58f091-a67b-417d-a972-3e3d95549a2f"),
                            FileResourceId = Guid.Parse("f850d2a0-401a-42d0-b7d6-3b48f3d521e6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("55070d2d-5a26-4455-99a6-024fc3a33352"),
                            FileResourceId = Guid.Parse("a16a463b-1f50-48fb-ba00-a8d9ce382d37")
                        },
                        new
                        {
                            ClassId = Guid.Parse("55070d2d-5a26-4455-99a6-024fc3a33352"),
                            FileResourceId = Guid.Parse("f3b859b2-6d5f-4454-af38-be31d3136a2b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("55070d2d-5a26-4455-99a6-024fc3a33352"),
                            FileResourceId = Guid.Parse("2c706c0c-53d2-423a-b571-6de36c6551ed")
                        },
                        new
                        {
                            ClassId = Guid.Parse("809377e4-4e50-4f00-92e2-fae20a9ce4d4"),
                            FileResourceId = Guid.Parse("b9d6120d-0266-45c3-8a76-dc0fc1a740d6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("809377e4-4e50-4f00-92e2-fae20a9ce4d4"),
                            FileResourceId = Guid.Parse("6dbf32d4-00a9-4505-8204-17845bcddc6f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("809377e4-4e50-4f00-92e2-fae20a9ce4d4"),
                            FileResourceId = Guid.Parse("a029be01-642e-4c80-bb26-07602802a4b3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("dc3db657-3dba-42da-af80-e9f2195e781a"),
                            FileResourceId = Guid.Parse("b8f85bb4-1be7-437c-80a5-4963a13f81a3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("dc3db657-3dba-42da-af80-e9f2195e781a"),
                            FileResourceId = Guid.Parse("4f95d674-b2e2-479a-98ae-bfdf3913870a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("dc3db657-3dba-42da-af80-e9f2195e781a"),
                            FileResourceId = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2a9cc83b-cb2c-4b30-a149-9886736ae4ce"),
                            FileResourceId = Guid.Parse("1c4237a0-6a5f-4820-a25e-b8a287b7e816")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2a9cc83b-cb2c-4b30-a149-9886736ae4ce"),
                            FileResourceId = Guid.Parse("36a3fcd5-fda9-491a-8d5e-b00275c10abf")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4d93311e-5e96-41e3-8b56-7035de6b7000"),
                            FileResourceId = Guid.Parse("a16a463b-1f50-48fb-ba00-a8d9ce382d37")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9f5ff908-4a04-446a-860c-320e81cc4984"),
                            FileResourceId = Guid.Parse("ea47bdf0-fff5-4be1-a832-307b7ddd6acb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("430ff2e4-5dc8-4ea2-a8f7-fa2724ae2abc"),
                            FileResourceId = Guid.Parse("d6e95855-f2c6-4c20-81d5-46a556f66cb1")
                        },
                        new
                        {
                            ClassId = Guid.Parse("430ff2e4-5dc8-4ea2-a8f7-fa2724ae2abc"),
                            FileResourceId = Guid.Parse("16fb3af3-610f-47a5-b09f-9eddf20fc423")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ddd176d0-9f6d-427a-9bf5-ad77affdcde8"),
                            FileResourceId = Guid.Parse("e5a65f43-d917-4574-b6a1-0178cfb02fc7")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ddd176d0-9f6d-427a-9bf5-ad77affdcde8"),
                            FileResourceId = Guid.Parse("c482e273-bbc2-4bdd-8381-0cdb25f5062a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4ba510cc-fc36-4893-90fd-487ee685f2f2"),
                            FileResourceId = Guid.Parse("681c0181-9d7a-4ec5-b179-ee9eb40ec018")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4ba510cc-fc36-4893-90fd-487ee685f2f2"),
                            FileResourceId = Guid.Parse("66e0c73e-3843-48b7-be0b-12618da0255e")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c292103f-31ff-44cc-9eb6-3e43e97b1dfd"),
                            FileResourceId = Guid.Parse("97cbfdd7-79a5-4da0-86ae-931aac5edf12")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c292103f-31ff-44cc-9eb6-3e43e97b1dfd"),
                            FileResourceId = Guid.Parse("64c2e6df-136b-441a-8eb0-f3c17d1be806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bd5f6e6d-b411-4ffc-a4fd-5bd3cc52109c"),
                            FileResourceId = Guid.Parse("e90c029c-e120-486e-bbf2-1d3ab3b83874")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bd5f6e6d-b411-4ffc-a4fd-5bd3cc52109c"),
                            FileResourceId = Guid.Parse("dbdacd45-525f-4d12-a880-4c96f635b251")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bd5f6e6d-b411-4ffc-a4fd-5bd3cc52109c"),
                            FileResourceId = Guid.Parse("026a55db-e502-4db9-aacb-3cab00a41d66")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bc146c66-85f0-4d8e-94bc-d9bdaeb6f1c4"),
                            FileResourceId = Guid.Parse("1281f10c-fdff-4222-85b2-a3ac6474c876")
                        },
                        new
                        {
                            ClassId = Guid.Parse("19818eae-8429-4cf2-9a82-2adc088b736c"),
                            FileResourceId = Guid.Parse("47fbd7e1-c3ed-4d59-93c9-4aaa1e4813fb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("19818eae-8429-4cf2-9a82-2adc088b736c"),
                            FileResourceId = Guid.Parse("ccce5036-dd77-4fe9-9cfc-dac5f2159a0b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("19818eae-8429-4cf2-9a82-2adc088b736c"),
                            FileResourceId = Guid.Parse("d6e95855-f2c6-4c20-81d5-46a556f66cb1")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c486d965-2093-4e4a-a2ae-c3f9fb0a7b8c"),
                            FileResourceId = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c486d965-2093-4e4a-a2ae-c3f9fb0a7b8c"),
                            FileResourceId = Guid.Parse("a5f6f521-3389-4fc4-a67b-ed833bd5fe2d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c486d965-2093-4e4a-a2ae-c3f9fb0a7b8c"),
                            FileResourceId = Guid.Parse("49999268-5d22-48d1-bde0-2cde904c4821")
                        },
                        new
                        {
                            ClassId = Guid.Parse("92eca9bb-eee1-46c1-8b0b-d65dcb5cda87"),
                            FileResourceId = Guid.Parse("184d4224-07b8-4045-b8d1-08c6055aa480")
                        },
                        new
                        {
                            ClassId = Guid.Parse("92eca9bb-eee1-46c1-8b0b-d65dcb5cda87"),
                            FileResourceId = Guid.Parse("4c6f3dc2-336c-4821-9063-05ba8e884165")
                        },
                        new
                        {
                            ClassId = Guid.Parse("92eca9bb-eee1-46c1-8b0b-d65dcb5cda87"),
                            FileResourceId = Guid.Parse("f3b859b2-6d5f-4454-af38-be31d3136a2b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d"),
                            FileResourceId = Guid.Parse("0a5b774d-611d-4f60-bdbd-2b8d2f44b080")
                        },
                        new
                        {
                            ClassId = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d"),
                            FileResourceId = Guid.Parse("b18f76c8-214a-45c2-9080-ffc03d0312ea")
                        },
                        new
                        {
                            ClassId = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d"),
                            FileResourceId = Guid.Parse("929994c8-e86b-4a6b-afa2-3fbf1a63662b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f8190291-dccf-4321-8e66-a13e616df8de"),
                            FileResourceId = Guid.Parse("14762566-eca5-4870-a740-1328557c7885")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f8190291-dccf-4321-8e66-a13e616df8de"),
                            FileResourceId = Guid.Parse("ceb337a0-55b3-4ceb-8870-8d5796a09aa2")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bf18c4d2-fcc3-429c-9ed1-afaffc613185"),
                            FileResourceId = Guid.Parse("9efea894-ffa2-4d5c-b8e7-f555982d489a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bf18c4d2-fcc3-429c-9ed1-afaffc613185"),
                            FileResourceId = Guid.Parse("a8919856-a312-4664-a2e9-8119fb88e341")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bf18c4d2-fcc3-429c-9ed1-afaffc613185"),
                            FileResourceId = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5483e82e-1dab-4d1e-8142-f6f7a4b61be0"),
                            FileResourceId = Guid.Parse("8852eafa-6067-43de-899d-693358679187")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2988615a-e919-4555-94fc-1dad57bb1897"),
                            FileResourceId = Guid.Parse("5e52947e-af54-49ba-8d3e-9137f27c9765")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2988615a-e919-4555-94fc-1dad57bb1897"),
                            FileResourceId = Guid.Parse("e77f6a08-bd8d-44a7-9595-857f90f01b84")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8443a682-f3f4-4670-90af-3d636655ad12"),
                            FileResourceId = Guid.Parse("7368bb0f-aa3b-4571-8e9d-c332a484996b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8443a682-f3f4-4670-90af-3d636655ad12"),
                            FileResourceId = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9572378c-e4a2-4d05-85de-d02b8238fd2b"),
                            FileResourceId = Guid.Parse("ca184750-f40a-4d14-ba06-e6eda721a30b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e85e13df-ffd8-40c8-866c-8a3d5b62c968"),
                            FileResourceId = Guid.Parse("7383a95b-961e-4b88-9a3a-7edb9c2b5bff")
                        },
                        new
                        {
                            ClassId = Guid.Parse("590d47c9-8af0-4c54-8156-16ce670b8670"),
                            FileResourceId = Guid.Parse("2c706c0c-53d2-423a-b571-6de36c6551ed")
                        },
                        new
                        {
                            ClassId = Guid.Parse("590d47c9-8af0-4c54-8156-16ce670b8670"),
                            FileResourceId = Guid.Parse("71c4d5ea-6a02-41c9-9ca4-0f4adee5cda1")
                        },
                        new
                        {
                            ClassId = Guid.Parse("db6f11c4-101b-4fde-bec0-defd8b52319f"),
                            FileResourceId = Guid.Parse("94d95f4f-12f2-4f66-8898-4528d622a131")
                        },
                        new
                        {
                            ClassId = Guid.Parse("db6f11c4-101b-4fde-bec0-defd8b52319f"),
                            FileResourceId = Guid.Parse("54f4a8ef-54c2-4303-ac48-373d726523d6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("db6f11c4-101b-4fde-bec0-defd8b52319f"),
                            FileResourceId = Guid.Parse("0347335e-7c9a-4320-8b27-925074d62d61")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6346be9b-73c4-4746-86a5-435fc4eaad56"),
                            FileResourceId = Guid.Parse("84788e82-62d6-4aaa-9477-249140609d11")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6346be9b-73c4-4746-86a5-435fc4eaad56"),
                            FileResourceId = Guid.Parse("d1b97ed5-fb8e-43fd-9dd6-7a5410d5a48b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("6346be9b-73c4-4746-86a5-435fc4eaad56"),
                            FileResourceId = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4")
                        },
                        new
                        {
                            ClassId = Guid.Parse("da1c74b4-8217-4eb6-b266-ef7f047821e5"),
                            FileResourceId = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516")
                        },
                        new
                        {
                            ClassId = Guid.Parse("da1c74b4-8217-4eb6-b266-ef7f047821e5"),
                            FileResourceId = Guid.Parse("16fb3af3-610f-47a5-b09f-9eddf20fc423")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8053903f-146d-4795-931c-f802e8628cbd"),
                            FileResourceId = Guid.Parse("dee85c51-24b8-4786-97d7-a844d4267769")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8053903f-146d-4795-931c-f802e8628cbd"),
                            FileResourceId = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8053903f-146d-4795-931c-f802e8628cbd"),
                            FileResourceId = Guid.Parse("92f1e4c0-caca-48b6-91fc-edb3feb3e4bb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("36cb7cd3-dd52-437e-8848-d86cb4b77067"),
                            FileResourceId = Guid.Parse("c65ca690-52b0-49de-8629-cc6c497e5806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("36cb7cd3-dd52-437e-8848-d86cb4b77067"),
                            FileResourceId = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("36cb7cd3-dd52-437e-8848-d86cb4b77067"),
                            FileResourceId = Guid.Parse("a61749d9-1dc8-4a86-a2f1-6721f0dbe5b3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e57a98d4-f256-4893-a19d-3e3b2aedbcaf"),
                            FileResourceId = Guid.Parse("f3b859b2-6d5f-4454-af38-be31d3136a2b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e57a98d4-f256-4893-a19d-3e3b2aedbcaf"),
                            FileResourceId = Guid.Parse("cb73e98e-b15c-468c-8b54-e6f30520d913")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e57a98d4-f256-4893-a19d-3e3b2aedbcaf"),
                            FileResourceId = Guid.Parse("e8e90cfb-2873-4e1e-822d-57e54ec383a5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9c8b9a86-bc44-47ae-a5d6-bcbd930b9eb8"),
                            FileResourceId = Guid.Parse("cf5129ad-f33a-44ff-9658-45e0b54aae8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8cf5c033-1abf-4a96-8249-ad591b102dfc"),
                            FileResourceId = Guid.Parse("49d1f450-280d-436e-9dee-36f6b8d0d816")
                        },
                        new
                        {
                            ClassId = Guid.Parse("73334b7a-28cc-425e-acc0-5aa301426eed"),
                            FileResourceId = Guid.Parse("9e5bd71e-4631-4a69-9a92-4e66c372fcf7")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c0091f46-622e-4e4d-a05a-12dcaf05c263"),
                            FileResourceId = Guid.Parse("49d1f450-280d-436e-9dee-36f6b8d0d816")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c0091f46-622e-4e4d-a05a-12dcaf05c263"),
                            FileResourceId = Guid.Parse("79400d29-f724-4ea3-b8b0-ac4630240bec")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c0091f46-622e-4e4d-a05a-12dcaf05c263"),
                            FileResourceId = Guid.Parse("c65ca690-52b0-49de-8629-cc6c497e5806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("cab65f21-eb52-4d41-8d04-6da23bc5a20b"),
                            FileResourceId = Guid.Parse("b0b03297-21da-4301-bb97-c8531ef8f3b1")
                        },
                        new
                        {
                            ClassId = Guid.Parse("cab65f21-eb52-4d41-8d04-6da23bc5a20b"),
                            FileResourceId = Guid.Parse("c65ca690-52b0-49de-8629-cc6c497e5806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("cab65f21-eb52-4d41-8d04-6da23bc5a20b"),
                            FileResourceId = Guid.Parse("f8444b9b-13d7-4aaa-abda-3cb4420f4dab")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f4ada7e9-9036-4e3b-86a1-1cffcd78ee72"),
                            FileResourceId = Guid.Parse("ab5adb07-1292-49d4-8fed-109fd46f15e5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f4ada7e9-9036-4e3b-86a1-1cffcd78ee72"),
                            FileResourceId = Guid.Parse("64c2e6df-136b-441a-8eb0-f3c17d1be806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("98cea40f-9cce-4266-b678-1d47ed1c7f1b"),
                            FileResourceId = Guid.Parse("06c9743e-19f4-492e-98fb-17508611b246")
                        },
                        new
                        {
                            ClassId = Guid.Parse("98cea40f-9cce-4266-b678-1d47ed1c7f1b"),
                            FileResourceId = Guid.Parse("8ae9bba1-7234-44dc-9990-43e92623a8a6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("98cea40f-9cce-4266-b678-1d47ed1c7f1b"),
                            FileResourceId = Guid.Parse("06692afa-8e02-4074-81e7-232d9c7c3beb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("72df1f95-9af5-49c0-97f3-50f4bffee160"),
                            FileResourceId = Guid.Parse("725b54c9-aae3-4d26-b817-3c1945861172")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f4fda6f5-96b8-4195-bc5b-944b34523e56"),
                            FileResourceId = Guid.Parse("0dc6494d-6d95-445d-b15b-0699ce78f9f9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f4fda6f5-96b8-4195-bc5b-944b34523e56"),
                            FileResourceId = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee")
                        },
                        new
                        {
                            ClassId = Guid.Parse("41668901-3476-4573-8230-7ba6cad7ad61"),
                            FileResourceId = Guid.Parse("40c12560-c27e-483c-80ed-78423683ed57")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ccdbf889-4c34-48dc-8abf-f5701bc03a9e"),
                            FileResourceId = Guid.Parse("a8919856-a312-4664-a2e9-8119fb88e341")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ccdbf889-4c34-48dc-8abf-f5701bc03a9e"),
                            FileResourceId = Guid.Parse("70dcd2b3-bc6b-4e74-b467-a8fa3b5bf571")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ce2d8ca1-6f3c-44ac-9207-529f19ace3d7"),
                            FileResourceId = Guid.Parse("530c76c7-3499-4317-ab8e-bd6c8064069e")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5075c7e1-5257-4b40-82b4-b974952aa15f"),
                            FileResourceId = Guid.Parse("067f61fa-dccb-4b9a-a195-07757e788a35")
                        },
                        new
                        {
                            ClassId = Guid.Parse("23acbb91-af14-4f83-961f-80051c1f2a43"),
                            FileResourceId = Guid.Parse("c65ca690-52b0-49de-8629-cc6c497e5806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("23acbb91-af14-4f83-961f-80051c1f2a43"),
                            FileResourceId = Guid.Parse("7e845b9d-c2a9-4c59-97de-892a4ac387d9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("eb09b8ac-f801-44ff-85dd-6f63f6213603"),
                            FileResourceId = Guid.Parse("e842fa3a-c572-48c0-9dda-3810b45ff133")
                        },
                        new
                        {
                            ClassId = Guid.Parse("3b1efa1b-cb60-4230-9085-7cde01984986"),
                            FileResourceId = Guid.Parse("0dc6494d-6d95-445d-b15b-0699ce78f9f9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("febe3e4e-84d9-429b-aedf-bf2b9d9a9533"),
                            FileResourceId = Guid.Parse("b9c3f4ca-3b5a-4a7a-82ee-69d1214728af")
                        },
                        new
                        {
                            ClassId = Guid.Parse("febe3e4e-84d9-429b-aedf-bf2b9d9a9533"),
                            FileResourceId = Guid.Parse("5e52947e-af54-49ba-8d3e-9137f27c9765")
                        },
                        new
                        {
                            ClassId = Guid.Parse("febe3e4e-84d9-429b-aedf-bf2b9d9a9533"),
                            FileResourceId = Guid.Parse("e840b62f-594f-4bb1-9b1b-fa2ace24dde3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4e1f6047-c688-4ef9-bf9f-89ac6e082c55"),
                            FileResourceId = Guid.Parse("e842fa3a-c572-48c0-9dda-3810b45ff133")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4e1f6047-c688-4ef9-bf9f-89ac6e082c55"),
                            FileResourceId = Guid.Parse("628a0d1e-7ac0-4016-b614-568e0b12f2af")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4e1f6047-c688-4ef9-bf9f-89ac6e082c55"),
                            FileResourceId = Guid.Parse("727b404c-e11a-4084-90f1-d09b1132d754")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d27a0610-ad56-4f71-9615-45567d68ab36"),
                            FileResourceId = Guid.Parse("06f8e2ec-37ff-447a-8e1b-0a6d0ef685e1")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d27a0610-ad56-4f71-9615-45567d68ab36"),
                            FileResourceId = Guid.Parse("c4048268-ef74-4d34-a28a-59949e5c6d6f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("376af187-37fb-4da2-bc48-3ab25c514214"),
                            FileResourceId = Guid.Parse("6e8c6a6b-a053-446a-91d9-fa2919962da6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("376af187-37fb-4da2-bc48-3ab25c514214"),
                            FileResourceId = Guid.Parse("e8482fb8-6886-42ac-9ccf-993a15327f9b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("376af187-37fb-4da2-bc48-3ab25c514214"),
                            FileResourceId = Guid.Parse("4f95d674-b2e2-479a-98ae-bfdf3913870a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8c811295-5397-4967-acb2-09cdd24140ec"),
                            FileResourceId = Guid.Parse("d1b97ed5-fb8e-43fd-9dd6-7a5410d5a48b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8c811295-5397-4967-acb2-09cdd24140ec"),
                            FileResourceId = Guid.Parse("02ec10f6-92ef-4095-96b6-244db10924e0")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8c811295-5397-4967-acb2-09cdd24140ec"),
                            FileResourceId = Guid.Parse("a9b16505-c50a-4d7b-99d6-c581785478aa")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bb271e47-7532-4488-8c9b-84856e35de10"),
                            FileResourceId = Guid.Parse("f4ed5454-3d22-476c-b8ec-7316e1d228f4")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bb271e47-7532-4488-8c9b-84856e35de10"),
                            FileResourceId = Guid.Parse("7bf77641-6182-459f-aa06-7e081f8c20e3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bb271e47-7532-4488-8c9b-84856e35de10"),
                            FileResourceId = Guid.Parse("30b2d6e7-77b1-42bf-9df4-f01f4e256d70")
                        },
                        new
                        {
                            ClassId = Guid.Parse("92b32a02-4244-4271-a8b0-177813151695"),
                            FileResourceId = Guid.Parse("4c6f3dc2-336c-4821-9063-05ba8e884165")
                        },
                        new
                        {
                            ClassId = Guid.Parse("92b32a02-4244-4271-a8b0-177813151695"),
                            FileResourceId = Guid.Parse("b9d6120d-0266-45c3-8a76-dc0fc1a740d6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("92b32a02-4244-4271-a8b0-177813151695"),
                            FileResourceId = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4b42d48d-2112-4ec8-a55f-b074c6fce4d4"),
                            FileResourceId = Guid.Parse("0daa2725-4723-4d23-a2b7-a0cc78beb358")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4b42d48d-2112-4ec8-a55f-b074c6fce4d4"),
                            FileResourceId = Guid.Parse("6652728a-f322-43fe-869d-61c59aaf2cbf")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4b42d48d-2112-4ec8-a55f-b074c6fce4d4"),
                            FileResourceId = Guid.Parse("70dcd2b3-bc6b-4e74-b467-a8fa3b5bf571")
                        },
                        new
                        {
                            ClassId = Guid.Parse("110af0ea-b9be-470b-aef4-4fbb93176612"),
                            FileResourceId = Guid.Parse("4057a05d-0938-40d4-ae58-e0e6238ad69d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("110af0ea-b9be-470b-aef4-4fbb93176612"),
                            FileResourceId = Guid.Parse("70f94315-d6c1-415d-b327-57430ee490c6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9462cb25-3418-4fa0-9a84-b440cdcadab1"),
                            FileResourceId = Guid.Parse("6e8c6a6b-a053-446a-91d9-fa2919962da6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9462cb25-3418-4fa0-9a84-b440cdcadab1"),
                            FileResourceId = Guid.Parse("2e2c759b-2bb5-4393-baf5-1f02f964262a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9462cb25-3418-4fa0-9a84-b440cdcadab1"),
                            FileResourceId = Guid.Parse("b9d6120d-0266-45c3-8a76-dc0fc1a740d6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("56e6affb-1bf8-4953-b14e-0899824125ac"),
                            FileResourceId = Guid.Parse("a7fcaf67-c839-42f3-b0b4-e7f691c63a26")
                        },
                        new
                        {
                            ClassId = Guid.Parse("28c7b1bb-7581-4a84-9b75-3cf3b3e27065"),
                            FileResourceId = Guid.Parse("e704d8e8-8ec0-46a4-b8c3-4311817edb07")
                        },
                        new
                        {
                            ClassId = Guid.Parse("28c7b1bb-7581-4a84-9b75-3cf3b3e27065"),
                            FileResourceId = Guid.Parse("7368bb0f-aa3b-4571-8e9d-c332a484996b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("28c7b1bb-7581-4a84-9b75-3cf3b3e27065"),
                            FileResourceId = Guid.Parse("66d08c8d-2c0d-46d8-9e5d-64da20c354b4")
                        },
                        new
                        {
                            ClassId = Guid.Parse("8bcbc7f6-1582-43ea-bcdb-939af645e696"),
                            FileResourceId = Guid.Parse("3d942a6f-0766-486e-a245-8d9afd3c678f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("37b1a441-f32a-4b9c-a5f4-88cfbc29def1"),
                            FileResourceId = Guid.Parse("2efadb1c-bd85-4b08-81c5-e4082a3d07b8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("37b1a441-f32a-4b9c-a5f4-88cfbc29def1"),
                            FileResourceId = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4")
                        },
                        new
                        {
                            ClassId = Guid.Parse("37b1a441-f32a-4b9c-a5f4-88cfbc29def1"),
                            FileResourceId = Guid.Parse("72d4898c-30fd-4b9f-bc05-8d672275ef2a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("22010015-d84b-42f4-86ce-b543d315d4cc"),
                            FileResourceId = Guid.Parse("2aab82f6-bc60-483f-93cd-18c3c4670d28")
                        },
                        new
                        {
                            ClassId = Guid.Parse("22010015-d84b-42f4-86ce-b543d315d4cc"),
                            FileResourceId = Guid.Parse("3245277f-e208-4d6c-8716-d7347500dfa6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a96d050-90f7-41b3-bc8d-ad8ac2213455"),
                            FileResourceId = Guid.Parse("04c6f110-55aa-489e-9afa-738380165169")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a96d050-90f7-41b3-bc8d-ad8ac2213455"),
                            FileResourceId = Guid.Parse("a751c0b2-f59a-4d23-8040-ccb6877eff73")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a96d050-90f7-41b3-bc8d-ad8ac2213455"),
                            FileResourceId = Guid.Parse("70f1a5f0-2ab3-4990-929a-d53ee0ecc6a9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2381c734-4ebd-4c73-84a1-205bec548788"),
                            FileResourceId = Guid.Parse("74a60fa1-6186-4e04-a164-838081d0c7e8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2381c734-4ebd-4c73-84a1-205bec548788"),
                            FileResourceId = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2381c734-4ebd-4c73-84a1-205bec548788"),
                            FileResourceId = Guid.Parse("03a8b6f1-9ed8-4a77-b9d0-9827301b2408")
                        },
                        new
                        {
                            ClassId = Guid.Parse("21deedff-73f7-44b9-af4e-faf877677023"),
                            FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("fa6be8be-f2dd-4f5c-a700-5ef9af7cf28a"),
                            FileResourceId = Guid.Parse("7122a8dc-cbbf-4009-b205-c93a1f6beffa")
                        },
                        new
                        {
                            ClassId = Guid.Parse("fa6be8be-f2dd-4f5c-a700-5ef9af7cf28a"),
                            FileResourceId = Guid.Parse("7cff958f-e3a0-4707-86a6-99c168f251b5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bae6f4fa-502b-482c-94c4-a10a025b0600"),
                            FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bae6f4fa-502b-482c-94c4-a10a025b0600"),
                            FileResourceId = Guid.Parse("84788e82-62d6-4aaa-9477-249140609d11")
                        },
                        new
                        {
                            ClassId = Guid.Parse("cd4e5bf4-8bee-48fb-91f3-8a544024c90c"),
                            FileResourceId = Guid.Parse("229fbf70-010a-4114-a41e-7e523e960e95")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1fd4ce1c-ffcf-4046-b2e4-16dfcb025dd6"),
                            FileResourceId = Guid.Parse("45459f48-29b6-4db9-86fa-4c5d5ad74959")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1fd4ce1c-ffcf-4046-b2e4-16dfcb025dd6"),
                            FileResourceId = Guid.Parse("391c17ab-dd63-43dd-bd10-42280c0ab796")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1fd4ce1c-ffcf-4046-b2e4-16dfcb025dd6"),
                            FileResourceId = Guid.Parse("cce23af1-d4cc-40ad-a309-6c224abd6fff")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2980c5de-ed0b-4115-9610-0688ab9ec4b5"),
                            FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1d8eedb2-9518-49b3-b484-a9e11af14b43"),
                            FileResourceId = Guid.Parse("dbdacd45-525f-4d12-a880-4c96f635b251")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ef743714-1f09-4c80-a295-9c112e0c2cd6"),
                            FileResourceId = Guid.Parse("5a3892b1-8d2b-48bf-81ad-085eeed7f4cc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("ef743714-1f09-4c80-a295-9c112e0c2cd6"),
                            FileResourceId = Guid.Parse("e90c029c-e120-486e-bbf2-1d3ab3b83874")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f91cba7a-e43f-4233-8b1d-a8085eca1720"),
                            FileResourceId = Guid.Parse("47fbd7e1-c3ed-4d59-93c9-4aaa1e4813fb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f91cba7a-e43f-4233-8b1d-a8085eca1720"),
                            FileResourceId = Guid.Parse("ceb337a0-55b3-4ceb-8870-8d5796a09aa2")
                        },
                        new
                        {
                            ClassId = Guid.Parse("71a3d40e-7bb8-4a3f-b89c-9a465e1dd56a"),
                            FileResourceId = Guid.Parse("9b45a713-c241-44bb-bdef-0d2c0c7ce063")
                        },
                        new
                        {
                            ClassId = Guid.Parse("74680039-27eb-4e40-b55e-23edf4c60328"),
                            FileResourceId = Guid.Parse("7eda8c18-1ca4-40d6-a320-4e7316c4b0fd")
                        },
                        new
                        {
                            ClassId = Guid.Parse("74680039-27eb-4e40-b55e-23edf4c60328"),
                            FileResourceId = Guid.Parse("68f8991f-4cdc-4938-aaa2-fde985f0de9b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("74680039-27eb-4e40-b55e-23edf4c60328"),
                            FileResourceId = Guid.Parse("9efea894-ffa2-4d5c-b8e7-f555982d489a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("64de3b52-e261-4152-81fd-f1d74e3f7046"),
                            FileResourceId = Guid.Parse("ca184750-f40a-4d14-ba06-e6eda721a30b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("64de3b52-e261-4152-81fd-f1d74e3f7046"),
                            FileResourceId = Guid.Parse("c5848d65-4342-4b8a-83a9-40e2d782288a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("52506048-8fcd-4346-96b6-214f370e6b53"),
                            FileResourceId = Guid.Parse("2ad1247f-c66f-4f8c-ae0a-b9b0f11335fb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4b57edca-127b-4497-875f-114bad7c3856"),
                            FileResourceId = Guid.Parse("b4d3ada4-d980-44e5-aa8d-eec88a20754b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4b57edca-127b-4497-875f-114bad7c3856"),
                            FileResourceId = Guid.Parse("96f3bf47-ef2e-4247-bd5f-f2168cfe1449")
                        },
                        new
                        {
                            ClassId = Guid.Parse("b825d6bd-c958-4126-8d0d-c90f3e23786d"),
                            FileResourceId = Guid.Parse("4a127efa-edcf-48bd-875a-fb238afbbd3f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("b825d6bd-c958-4126-8d0d-c90f3e23786d"),
                            FileResourceId = Guid.Parse("5955ab75-c9a2-4d2e-89f3-cdf0c9c4df36")
                        },
                        new
                        {
                            ClassId = Guid.Parse("b825d6bd-c958-4126-8d0d-c90f3e23786d"),
                            FileResourceId = Guid.Parse("628a0d1e-7ac0-4016-b614-568e0b12f2af")
                        },
                        new
                        {
                            ClassId = Guid.Parse("21eb18a4-4262-481b-8cf2-bf16dec017a8"),
                            FileResourceId = Guid.Parse("b4ece921-f15f-4f32-827a-85c4a898af7b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("21eb18a4-4262-481b-8cf2-bf16dec017a8"),
                            FileResourceId = Guid.Parse("cce23af1-d4cc-40ad-a309-6c224abd6fff")
                        },
                        new
                        {
                            ClassId = Guid.Parse("71a66cfa-1fa5-4bd1-affa-dd48e489f3d4"),
                            FileResourceId = Guid.Parse("e09f27fa-224e-46f8-8f7d-b1cd43398ee6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("71a66cfa-1fa5-4bd1-affa-dd48e489f3d4"),
                            FileResourceId = Guid.Parse("6ab6f54f-540b-4781-bf7d-335503538852")
                        },
                        new
                        {
                            ClassId = Guid.Parse("71a66cfa-1fa5-4bd1-affa-dd48e489f3d4"),
                            FileResourceId = Guid.Parse("97cbfdd7-79a5-4da0-86ae-931aac5edf12")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63"),
                            FileResourceId = Guid.Parse("0470fa1e-b365-49cb-9516-8949ca60be85")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63"),
                            FileResourceId = Guid.Parse("cce23af1-d4cc-40ad-a309-6c224abd6fff")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4d1b3a95-0362-47c1-a014-9bcbac6a4d94"),
                            FileResourceId = Guid.Parse("3d942a6f-0766-486e-a245-8d9afd3c678f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4d1b3a95-0362-47c1-a014-9bcbac6a4d94"),
                            FileResourceId = Guid.Parse("09ceba9f-1e38-4f3d-ad99-13f9dd962c47")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4d1b3a95-0362-47c1-a014-9bcbac6a4d94"),
                            FileResourceId = Guid.Parse("a830f453-ac0b-4158-b599-4a2bec66a09f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5d0fa399-05ed-46e4-ae17-6d4733c80660"),
                            FileResourceId = Guid.Parse("b18f76c8-214a-45c2-9080-ffc03d0312ea")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5d0fa399-05ed-46e4-ae17-6d4733c80660"),
                            FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5d0fa399-05ed-46e4-ae17-6d4733c80660"),
                            FileResourceId = Guid.Parse("30b2d6e7-77b1-42bf-9df4-f01f4e256d70")
                        },
                        new
                        {
                            ClassId = Guid.Parse("37157991-98d4-4813-a465-1fdfc14c4223"),
                            FileResourceId = Guid.Parse("dfedd8a8-6e3b-406f-b0d2-868429098ef8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("37157991-98d4-4813-a465-1fdfc14c4223"),
                            FileResourceId = Guid.Parse("060deee0-d8c3-415d-8d87-77c7d98a62b6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("37157991-98d4-4813-a465-1fdfc14c4223"),
                            FileResourceId = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("fdbdf55c-83d4-487c-b076-2fc0f5d43dc5"),
                            FileResourceId = Guid.Parse("ae351af9-cd99-4df6-b747-d43356f6c98f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("940a3b5b-df1e-42c6-a6d3-f5245b7cb906"),
                            FileResourceId = Guid.Parse("c482e273-bbc2-4bdd-8381-0cdb25f5062a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("af2e3f3b-7d87-4834-8375-e2cbb87fac0c"),
                            FileResourceId = Guid.Parse("7cff958f-e3a0-4707-86a6-99c168f251b5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("af2e3f3b-7d87-4834-8375-e2cbb87fac0c"),
                            FileResourceId = Guid.Parse("84c3aede-faea-4546-a93e-8c8d95d8b289")
                        },
                        new
                        {
                            ClassId = Guid.Parse("4120596a-c73f-4bfc-800e-2c5af16d7358"),
                            FileResourceId = Guid.Parse("4df48f8c-4731-4c97-8535-436a0a063b69")
                        },
                        new
                        {
                            ClassId = Guid.Parse("98f91a97-26ff-43c2-a43a-710484d60456"),
                            FileResourceId = Guid.Parse("c65ca690-52b0-49de-8629-cc6c497e5806")
                        },
                        new
                        {
                            ClassId = Guid.Parse("98f91a97-26ff-43c2-a43a-710484d60456"),
                            FileResourceId = Guid.Parse("2aab82f6-bc60-483f-93cd-18c3c4670d28")
                        },
                        new
                        {
                            ClassId = Guid.Parse("98f91a97-26ff-43c2-a43a-710484d60456"),
                            FileResourceId = Guid.Parse("530c76c7-3499-4317-ab8e-bd6c8064069e")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e6c52897-0214-4739-8f04-b35f62f07350"),
                            FileResourceId = Guid.Parse("93318896-c586-402b-a540-79760e0adb6f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e6c52897-0214-4739-8f04-b35f62f07350"),
                            FileResourceId = Guid.Parse("600d584f-431c-4769-837d-8f2e228bb747")
                        },
                        new
                        {
                            ClassId = Guid.Parse("e6c52897-0214-4739-8f04-b35f62f07350"),
                            FileResourceId = Guid.Parse("70f94315-d6c1-415d-b327-57430ee490c6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("3a6325f4-3044-4544-98e8-d6c9600d2d8b"),
                            FileResourceId = Guid.Parse("a16a463b-1f50-48fb-ba00-a8d9ce382d37")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c010c4d1-28aa-41fb-bfc6-8680cf5ebdfe"),
                            FileResourceId = Guid.Parse("391c17ab-dd63-43dd-bd10-42280c0ab796")
                        },
                        new
                        {
                            ClassId = Guid.Parse("c010c4d1-28aa-41fb-bfc6-8680cf5ebdfe"),
                            FileResourceId = Guid.Parse("4f076a46-ab8a-4022-80bb-12d7243caab3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5c106a9c-8949-481b-adca-52395821e400"),
                            FileResourceId = Guid.Parse("a9b16505-c50a-4d7b-99d6-c581785478aa")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5c106a9c-8949-481b-adca-52395821e400"),
                            FileResourceId = Guid.Parse("6ff3899e-6fea-45fe-9879-262fa2137e60")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5c106a9c-8949-481b-adca-52395821e400"),
                            FileResourceId = Guid.Parse("3ead8784-22c2-4951-9793-7a92dab8a1f6")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9d186474-9046-4b72-b1e5-2b727d6bbcaf"),
                            FileResourceId = Guid.Parse("5b84ceba-3936-4c1e-9c61-0c95bb6ab2ad")
                        },
                        new
                        {
                            ClassId = Guid.Parse("9d186474-9046-4b72-b1e5-2b727d6bbcaf"),
                            FileResourceId = Guid.Parse("484dbaec-d078-48b2-8b59-2a2255dc9c8d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1f274284-fee3-4120-a556-7e21e7269216"),
                            FileResourceId = Guid.Parse("dee85c51-24b8-4786-97d7-a844d4267769")
                        },
                        new
                        {
                            ClassId = Guid.Parse("1f274284-fee3-4120-a556-7e21e7269216"),
                            FileResourceId = Guid.Parse("ae7d09d3-df0f-44bf-85a7-6d4a55338c49")
                        },
                        new
                        {
                            ClassId = Guid.Parse("264bb48f-1a05-4013-9f67-b89478dc22b0"),
                            FileResourceId = Guid.Parse("eb91ff59-e5d6-4a83-8928-85d2f94bfc0f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d769195a-da0a-439c-9d21-60354e16cee2"),
                            FileResourceId = Guid.Parse("506736bf-1e54-43bf-b889-803770af3634")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d769195a-da0a-439c-9d21-60354e16cee2"),
                            FileResourceId = Guid.Parse("6ab6f54f-540b-4781-bf7d-335503538852")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d769195a-da0a-439c-9d21-60354e16cee2"),
                            FileResourceId = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de"),
                            FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de"),
                            FileResourceId = Guid.Parse("7383a95b-961e-4b88-9a3a-7edb9c2b5bff")
                        },
                        new
                        {
                            ClassId = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de"),
                            FileResourceId = Guid.Parse("a5f6f521-3389-4fc4-a67b-ed833bd5fe2d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("037a8b17-7aa8-47b4-860c-5632aff0af18"),
                            FileResourceId = Guid.Parse("40c12560-c27e-483c-80ed-78423683ed57")
                        },
                        new
                        {
                            ClassId = Guid.Parse("037a8b17-7aa8-47b4-860c-5632aff0af18"),
                            FileResourceId = Guid.Parse("06c9743e-19f4-492e-98fb-17508611b246")
                        },
                        new
                        {
                            ClassId = Guid.Parse("037a8b17-7aa8-47b4-860c-5632aff0af18"),
                            FileResourceId = Guid.Parse("b4a8d4ce-85bc-4369-9b09-6f56ad52bbc9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("b24ad846-5f18-452a-be71-8700f9dbb4aa"),
                            FileResourceId = Guid.Parse("aa0b1060-5efc-411a-9dcb-7d078a88a6bb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f7cfc20c-93a3-475d-86a2-b8e85b8c67fe"),
                            FileResourceId = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f7cfc20c-93a3-475d-86a2-b8e85b8c67fe"),
                            FileResourceId = Guid.Parse("3442e566-e83e-4d14-9df6-1c954c828b7a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("83ef5ead-64c6-474f-b5fb-8be4f8dfa6bd"),
                            FileResourceId = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("83ef5ead-64c6-474f-b5fb-8be4f8dfa6bd"),
                            FileResourceId = Guid.Parse("3d942a6f-0766-486e-a245-8d9afd3c678f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a155f6c-d51e-47ad-a85b-ee822b4cda07"),
                            FileResourceId = Guid.Parse("a85a21fd-8eb5-45e0-b33e-30cf35c82d9a")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5a155f6c-d51e-47ad-a85b-ee822b4cda07"),
                            FileResourceId = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc")
                        },
                        new
                        {
                            ClassId = Guid.Parse("bd98eeae-5a92-40c1-b541-8c736ff0f6fe"),
                            FileResourceId = Guid.Parse("4df48f8c-4731-4c97-8535-436a0a063b69")
                        },
                        new
                        {
                            ClassId = Guid.Parse("d5665dc7-79cd-4752-94a5-655fb2bca54d"),
                            FileResourceId = Guid.Parse("6dbf32d4-00a9-4505-8204-17845bcddc6f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("7578f973-8b58-4df2-9372-8b9a2e6bd2ca"),
                            FileResourceId = Guid.Parse("5797af1d-cc70-43f1-af68-4e84b4b40ce8")
                        },
                        new
                        {
                            ClassId = Guid.Parse("7578f973-8b58-4df2-9372-8b9a2e6bd2ca"),
                            FileResourceId = Guid.Parse("1281f10c-fdff-4222-85b2-a3ac6474c876")
                        },
                        new
                        {
                            ClassId = Guid.Parse("7578f973-8b58-4df2-9372-8b9a2e6bd2ca"),
                            FileResourceId = Guid.Parse("3d942a6f-0766-486e-a245-8d9afd3c678f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("74950363-d223-486b-9f33-cc0460b24371"),
                            FileResourceId = Guid.Parse("b4ece921-f15f-4f32-827a-85c4a898af7b")
                        },
                        new
                        {
                            ClassId = Guid.Parse("74950363-d223-486b-9f33-cc0460b24371"),
                            FileResourceId = Guid.Parse("f47ddb7a-9e13-4cad-999b-022a902b98a5")
                        },
                        new
                        {
                            ClassId = Guid.Parse("96115b32-35bb-4795-8acb-ef64c8351075"),
                            FileResourceId = Guid.Parse("a830f453-ac0b-4158-b599-4a2bec66a09f")
                        },
                        new
                        {
                            ClassId = Guid.Parse("96115b32-35bb-4795-8acb-ef64c8351075"),
                            FileResourceId = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3")
                        },
                        new
                        {
                            ClassId = Guid.Parse("96115b32-35bb-4795-8acb-ef64c8351075"),
                            FileResourceId = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0")
                        },
                        new
                        {
                            ClassId = Guid.Parse("13227742-f9f5-497d-8e38-09f5321dd5ec"),
                            FileResourceId = Guid.Parse("06692afa-8e02-4074-81e7-232d9c7c3beb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("13227742-f9f5-497d-8e38-09f5321dd5ec"),
                            FileResourceId = Guid.Parse("fcdf48c1-0c10-4fe0-b124-9d002cf877ef")
                        },
                        new
                        {
                            ClassId = Guid.Parse("13227742-f9f5-497d-8e38-09f5321dd5ec"),
                            FileResourceId = Guid.Parse("08a2d00e-f098-4819-9b63-2601a2bfb797")
                        },
                        new
                        {
                            ClassId = Guid.Parse("755881d1-fa2a-42e5-9139-175a8d75592b"),
                            FileResourceId = Guid.Parse("a5f6f521-3389-4fc4-a67b-ed833bd5fe2d")
                        },
                        new
                        {
                            ClassId = Guid.Parse("755881d1-fa2a-42e5-9139-175a8d75592b"),
                            FileResourceId = Guid.Parse("92f1e4c0-caca-48b6-91fc-edb3feb3e4bb")
                        },
                        new
                        {
                            ClassId = Guid.Parse("755881d1-fa2a-42e5-9139-175a8d75592b"),
                            FileResourceId = Guid.Parse("70f1a5f0-2ab3-4990-929a-d53ee0ecc6a9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f9e2f25f-384d-4c9f-9b85-f390d825a9cf"),
                            FileResourceId = Guid.Parse("af7b709e-c04f-43bc-a73a-438c82180924")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f9e2f25f-384d-4c9f-9b85-f390d825a9cf"),
                            FileResourceId = Guid.Parse("70f1a5f0-2ab3-4990-929a-d53ee0ecc6a9")
                        },
                        new
                        {
                            ClassId = Guid.Parse("f9e2f25f-384d-4c9f-9b85-f390d825a9cf"),
                            FileResourceId = Guid.Parse("24dac690-6e8b-492e-8e17-9d3e537fb31e")
                        });
                });

        builder.HasMany(c => c.Links)
            .WithOne(l => l.Class)
            .HasForeignKey(l => l.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        var now = new DateTime(2025, 10, 2, 12, 0, 0, DateTimeKind.Utc);
        var classId = Guid.Parse("43333333-3333-3333-3333-333333333333");
        var statusScheduledId = Guid.Parse("41111111-1111-1111-1111-111111111111");
        var student1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");

        builder.HasData(
            new
            {
                Id = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668"),
                StartTime = new DateTime(2025, 12, 6, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/a9666cb3",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("3b436cdc-53ea-4c80-a947-ca1a7ccc350b"),
                StartTime = new DateTime(2026, 1, 27, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/cbfa65d0",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("04806df7-dc2d-481a-ab6a-fcf2be9cc16c"),
                StartTime = new DateTime(2025, 12, 2, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/a054d37f",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("dd03fc90-7914-4c41-901f-feeae24142df"),
                StartTime = new DateTime(2026, 2, 23, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/00c7a653",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("5e232654-e629-49e3-98c2-4559505165c6"),
                StartTime = new DateTime(2025, 10, 18, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/ff9a47e5",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("10761475-fd6f-452f-9817-0f5b11e907a9"),
                StartTime = new DateTime(2026, 3, 6, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/98ac26d0",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("a3c2b920-a1b2-4cd2-8db4-4945b467ce2f"),
                StartTime = new DateTime(2025, 12, 29, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/a14bf451",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("9005a051-a079-4dc2-82b9-f7b3ab128b2f"),
                StartTime = new DateTime(2026, 2, 26, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/1670ac1e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("d0df950c-ad65-4fc0-8e10-64788b75781a"),
                StartTime = new DateTime(2026, 1, 4, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/2e7bca49",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("d3fd515d-c9a8-4a12-ae4b-045d2baaa725"),
                StartTime = new DateTime(2025, 12, 22, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/5c6e203f",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("a9b47a16-dd1a-4d4c-aab5-a2f2156dc72d"),
                StartTime = new DateTime(2026, 1, 21, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/9e8247cb",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("653977fd-d020-4c27-90e4-2232412ef2f5"),
                StartTime = new DateTime(2025, 10, 7, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/105b8671",
                ClassStatusId = Guid.Parse("42222222-2222-2222-2222-222222222222"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8"),
                StartTime = new DateTime(2026, 3, 13, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/bd976747",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("c5374e7c-5922-4208-820c-83b7bef81ea8"),
                StartTime = new DateTime(2025, 11, 22, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/1ac62717",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("2c7ddd20-534a-4f7f-a722-909ab0a67aad"),
                StartTime = new DateTime(2025, 10, 11, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/85c8d54f",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("79c9212c-dc94-4f45-aca9-b35eecacc8d2"),
                StartTime = new DateTime(2025, 12, 19, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/95bd18d9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("d539b5bd-da7d-4d50-9f6d-bcee91ef88fb"),
                StartTime = new DateTime(2026, 1, 13, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/18281db6",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("eaf96048-a284-43eb-a1df-c18ab9c0c2c1"),
                StartTime = new DateTime(2026, 3, 20, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/9c1bf982",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("6a505e6f-15c5-45b0-973c-b2ad02388314"),
                StartTime = new DateTime(2026, 3, 8, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/cf149cc0",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("597b6fe3-57e6-4831-a07c-991de998bfe2"),
                StartTime = new DateTime(2026, 1, 24, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/c636a25b",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("5a6b2eb1-25fe-465b-b2ea-56d584528c87"),
                StartTime = new DateTime(2025, 11, 27, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/242c7bfa",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("5f50d51c-ba7f-4bb7-bf3f-88b1c10cbcf0"),
                StartTime = new DateTime(2025, 12, 21, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/8d78c1a9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("1619b967-7450-472f-9ced-a9c4ab701318"),
                StartTime = new DateTime(2025, 12, 27, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/f39e0e2c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("9dc8306e-d10a-473f-8d8c-24b8f04083a8"),
                StartTime = new DateTime(2026, 3, 13, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/8118269e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("166b7349-a733-48e5-bb04-e9f0f5f1eeaf"),
                StartTime = new DateTime(2026, 1, 12, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/87fc2a93",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("fe37a1fd-f344-4940-ade7-bede9b784c78"),
                StartTime = new DateTime(2025, 12, 12, 19, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/fa104442",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("1c617641-f474-4b97-b528-f1e0c2d31ced"),
                StartTime = new DateTime(2025, 11, 20, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/2d7e07fd",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("54231f0d-9be4-4b19-ac3c-307411c36d84"),
                StartTime = new DateTime(2026, 2, 28, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/0f1a6fe0",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("ca7d32b6-8910-4719-9ebf-ec1f79f6b3ab"),
                StartTime = new DateTime(2026, 2, 15, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/ef2895f7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("88176c18-6d5e-4fef-9357-dcf5bb605044"),
                StartTime = new DateTime(2025, 10, 5, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/2b180b96",
                ClassStatusId = Guid.Parse("42222222-2222-2222-2222-222222222222"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("f5839a47-28a6-4335-a4d2-eecfce6a1478"),
                StartTime = new DateTime(2025, 10, 29, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/78968696",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2")
            },
            new
            {
                Id = Guid.Parse("6bda0668-b6d4-4773-b822-e58816df0ebe"),
                StartTime = new DateTime(2026, 1, 13, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/0d9aefb4",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("898a95d6-d2fb-4519-b6ee-fc4928a2831e"),
                StartTime = new DateTime(2026, 1, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/bcf0c5ef",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("4a1ae34b-57bd-4b2c-b25d-2e9c8c5ed4c6"),
                StartTime = new DateTime(2026, 1, 7, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/f856448e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("3a686937-654b-4085-a4cb-91c7e0e79dc9"),
                StartTime = new DateTime(2026, 1, 4, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/3707f5ae",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("25fafe89-827a-4e61-8256-47f7be392839"),
                StartTime = new DateTime(2026, 1, 3, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/7f35fe50",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("55d76dff-5ca6-4d7b-a80d-9a773b574406"),
                StartTime = new DateTime(2025, 12, 5, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/3f7d2aa5",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("40e85018-7490-48b0-8eab-5368d5f73e22"),
                StartTime = new DateTime(2026, 2, 26, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/678b7248",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("8dad9090-9e0f-4629-86d8-b1295bf09b5f"),
                StartTime = new DateTime(2025, 11, 2, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/8a606b9c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("bfbd200d-398b-4789-a002-32ea570134eb"),
                StartTime = new DateTime(2025, 12, 10, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/1ea87f39",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("2e10ef79-df92-4442-879f-f8369864bb7c"),
                StartTime = new DateTime(2025, 10, 23, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/fb2f5dbb",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("a4298748-5898-4089-9a00-cb6ca340f62a"),
                StartTime = new DateTime(2025, 12, 25, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/c0bc42e4",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("dfac9b08-8ef5-4476-a59c-735b2d58f3bd"),
                StartTime = new DateTime(2026, 3, 28, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/c8a3cac8",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("8b58f091-a67b-417d-a972-3e3d95549a2f"),
                StartTime = new DateTime(2026, 1, 2, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/29ca5b42",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("55070d2d-5a26-4455-99a6-024fc3a33352"),
                StartTime = new DateTime(2025, 10, 24, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/3ba7c22d",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("809377e4-4e50-4f00-92e2-fae20a9ce4d4"),
                StartTime = new DateTime(2025, 12, 14, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/7b436c63",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("dc3db657-3dba-42da-af80-e9f2195e781a"),
                StartTime = new DateTime(2026, 1, 8, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/bebeea43",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("2a9cc83b-cb2c-4b30-a149-9886736ae4ce"),
                StartTime = new DateTime(2025, 10, 27, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/162a96c2",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("4d93311e-5e96-41e3-8b56-7035de6b7000"),
                StartTime = new DateTime(2025, 12, 13, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/2cb6822d",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("9f5ff908-4a04-446a-860c-320e81cc4984"),
                StartTime = new DateTime(2025, 12, 31, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/b39950b1",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("430ff2e4-5dc8-4ea2-a8f7-fa2724ae2abc"),
                StartTime = new DateTime(2026, 3, 3, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/f6c3e123",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("ddd176d0-9f6d-427a-9bf5-ad77affdcde8"),
                StartTime = new DateTime(2025, 12, 18, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/63e1faea",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("4ba510cc-fc36-4893-90fd-487ee685f2f2"),
                StartTime = new DateTime(2026, 1, 30, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/5db93847",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("c292103f-31ff-44cc-9eb6-3e43e97b1dfd"),
                StartTime = new DateTime(2025, 11, 5, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/730d49b1",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("bd5f6e6d-b411-4ffc-a4fd-5bd3cc52109c"),
                StartTime = new DateTime(2025, 12, 4, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/b70659d6",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("bc146c66-85f0-4d8e-94bc-d9bdaeb6f1c4"),
                StartTime = new DateTime(2026, 2, 13, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/236eb9c0",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("19818eae-8429-4cf2-9a82-2adc088b736c"),
                StartTime = new DateTime(2026, 1, 23, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/50910c9b",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("c486d965-2093-4e4a-a2ae-c3f9fb0a7b8c"),
                StartTime = new DateTime(2026, 2, 16, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/c85ed656",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("92eca9bb-eee1-46c1-8b0b-d65dcb5cda87"),
                StartTime = new DateTime(2026, 1, 22, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/07b372f5",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d"),
                StartTime = new DateTime(2026, 1, 23, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/4076a3d7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("f8190291-dccf-4321-8e66-a13e616df8de"),
                StartTime = new DateTime(2026, 1, 17, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/670f9787",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("bf18c4d2-fcc3-429c-9ed1-afaffc613185"),
                StartTime = new DateTime(2025, 11, 11, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/e1cb7dd7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("5483e82e-1dab-4d1e-8142-f6f7a4b61be0"),
                StartTime = new DateTime(2026, 1, 29, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/2162dcc9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("2988615a-e919-4555-94fc-1dad57bb1897"),
                StartTime = new DateTime(2026, 2, 7, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/630e3cbb",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("8443a682-f3f4-4670-90af-3d636655ad12"),
                StartTime = new DateTime(2025, 11, 14, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/905cac16",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("9572378c-e4a2-4d05-85de-d02b8238fd2b"),
                StartTime = new DateTime(2025, 10, 11, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/7b2b8c33",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("e85e13df-ffd8-40c8-866c-8a3d5b62c968"),
                StartTime = new DateTime(2026, 3, 9, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/59ef06f9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
            },
            new
            {
                Id = Guid.Parse("590d47c9-8af0-4c54-8156-16ce670b8670"),
                StartTime = new DateTime(2025, 10, 20, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/24791226",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("db6f11c4-101b-4fde-bec0-defd8b52319f"),
                StartTime = new DateTime(2026, 3, 20, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/0d62be16",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("6346be9b-73c4-4746-86a5-435fc4eaad56"),
                StartTime = new DateTime(2026, 2, 7, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/fb8032de",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("da1c74b4-8217-4eb6-b266-ef7f047821e5"),
                StartTime = new DateTime(2025, 12, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/77b1c858",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("8053903f-146d-4795-931c-f802e8628cbd"),
                StartTime = new DateTime(2026, 1, 29, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/bf7cf7af",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("36cb7cd3-dd52-437e-8848-d86cb4b77067"),
                StartTime = new DateTime(2026, 2, 17, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/6a861127",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("e57a98d4-f256-4893-a19d-3e3b2aedbcaf"),
                StartTime = new DateTime(2025, 12, 13, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/66c1cefd",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("9c8b9a86-bc44-47ae-a5d6-bcbd930b9eb8"),
                StartTime = new DateTime(2025, 11, 4, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/b04e01e7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("8cf5c033-1abf-4a96-8249-ad591b102dfc"),
                StartTime = new DateTime(2026, 1, 30, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/9721f6ca",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("73334b7a-28cc-425e-acc0-5aa301426eed"),
                StartTime = new DateTime(2025, 10, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/fa0ebeca",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("c0091f46-622e-4e4d-a05a-12dcaf05c263"),
                StartTime = new DateTime(2026, 2, 10, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/c864fa15",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("cab65f21-eb52-4d41-8d04-6da23bc5a20b"),
                StartTime = new DateTime(2025, 11, 25, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/47db2e8d",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("f4ada7e9-9036-4e3b-86a1-1cffcd78ee72"),
                StartTime = new DateTime(2025, 12, 17, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/2cfa0081",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("98cea40f-9cce-4266-b678-1d47ed1c7f1b"),
                StartTime = new DateTime(2025, 11, 6, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/b00e0b15",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("72df1f95-9af5-49c0-97f3-50f4bffee160"),
                StartTime = new DateTime(2026, 3, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/db2a3731",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2")
            },
            new
            {
                Id = Guid.Parse("f4fda6f5-96b8-4195-bc5b-944b34523e56"),
                StartTime = new DateTime(2025, 10, 21, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/2f623547",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("41668901-3476-4573-8230-7ba6cad7ad61"),
                StartTime = new DateTime(2025, 12, 14, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/5533ead9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
            },
            new
            {
                Id = Guid.Parse("ccdbf889-4c34-48dc-8abf-f5701bc03a9e"),
                StartTime = new DateTime(2026, 1, 15, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/0fc8b57e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("ce2d8ca1-6f3c-44ac-9207-529f19ace3d7"),
                StartTime = new DateTime(2026, 2, 15, 19, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/a9f12556",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("5075c7e1-5257-4b40-82b4-b974952aa15f"),
                StartTime = new DateTime(2025, 10, 26, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/a4c0902a",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("23acbb91-af14-4f83-961f-80051c1f2a43"),
                StartTime = new DateTime(2025, 11, 12, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/42d1a1df",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("eb09b8ac-f801-44ff-85dd-6f63f6213603"),
                StartTime = new DateTime(2026, 1, 18, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/ded06c9f",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("3b1efa1b-cb60-4230-9085-7cde01984986"),
                StartTime = new DateTime(2026, 1, 3, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/b6655450",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("febe3e4e-84d9-429b-aedf-bf2b9d9a9533"),
                StartTime = new DateTime(2026, 2, 14, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/b3441c04",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("4e1f6047-c688-4ef9-bf9f-89ac6e082c55"),
                StartTime = new DateTime(2026, 3, 31, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/71859e9d",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("d27a0610-ad56-4f71-9615-45567d68ab36"),
                StartTime = new DateTime(2025, 12, 13, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/755651d7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("376af187-37fb-4da2-bc48-3ab25c514214"),
                StartTime = new DateTime(2025, 10, 26, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/0c30af04",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
            },
            new
            {
                Id = Guid.Parse("8c811295-5397-4967-acb2-09cdd24140ec"),
                StartTime = new DateTime(2026, 3, 7, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/cd36a53d",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("bb271e47-7532-4488-8c9b-84856e35de10"),
                StartTime = new DateTime(2025, 12, 25, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/b3c7ab84",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("92b32a02-4244-4271-a8b0-177813151695"),
                StartTime = new DateTime(2025, 11, 2, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/2fb751fa",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("4b42d48d-2112-4ec8-a55f-b074c6fce4d4"),
                StartTime = new DateTime(2025, 10, 24, 19, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/b05e6bb3",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("110af0ea-b9be-470b-aef4-4fbb93176612"),
                StartTime = new DateTime(2026, 1, 21, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/27b87acd",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("9462cb25-3418-4fa0-9a84-b440cdcadab1"),
                StartTime = new DateTime(2026, 2, 9, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/f53e2570",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("56e6affb-1bf8-4953-b14e-0899824125ac"),
                StartTime = new DateTime(2025, 11, 11, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/c92c60d4",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("28c7b1bb-7581-4a84-9b75-3cf3b3e27065"),
                StartTime = new DateTime(2025, 12, 14, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/d71a7b73",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
            },
            new
            {
                Id = Guid.Parse("8bcbc7f6-1582-43ea-bcdb-939af645e696"),
                StartTime = new DateTime(2026, 2, 24, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/75ca8c99",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("37b1a441-f32a-4b9c-a5f4-88cfbc29def1"),
                StartTime = new DateTime(2026, 2, 5, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/f264fbd9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("22010015-d84b-42f4-86ce-b543d315d4cc"),
                StartTime = new DateTime(2025, 12, 14, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/5ae86199",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("5a96d050-90f7-41b3-bc8d-ad8ac2213455"),
                StartTime = new DateTime(2026, 1, 26, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/515753f9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("2381c734-4ebd-4c73-84a1-205bec548788"),
                StartTime = new DateTime(2026, 2, 7, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/befe5d53",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("21deedff-73f7-44b9-af4e-faf877677023"),
                StartTime = new DateTime(2025, 10, 17, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/ecd10ec7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("fa6be8be-f2dd-4f5c-a700-5ef9af7cf28a"),
                StartTime = new DateTime(2025, 10, 8, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/22fe52f6",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("bae6f4fa-502b-482c-94c4-a10a025b0600"),
                StartTime = new DateTime(2025, 12, 9, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/33528b3c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("cd4e5bf4-8bee-48fb-91f3-8a544024c90c"),
                StartTime = new DateTime(2025, 10, 24, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/73f6e31e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("1fd4ce1c-ffcf-4046-b2e4-16dfcb025dd6"),
                StartTime = new DateTime(2025, 11, 18, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/1bd81078",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
            },
            new
            {
                Id = Guid.Parse("2980c5de-ed0b-4115-9610-0688ab9ec4b5"),
                StartTime = new DateTime(2025, 11, 15, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/92f8e808",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("1d8eedb2-9518-49b3-b484-a9e11af14b43"),
                StartTime = new DateTime(2025, 12, 4, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/65a3bf23",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("ef743714-1f09-4c80-a295-9c112e0c2cd6"),
                StartTime = new DateTime(2026, 1, 20, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/dac9f27b",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
            },
            new
            {
                Id = Guid.Parse("f91cba7a-e43f-4233-8b1d-a8085eca1720"),
                StartTime = new DateTime(2026, 1, 14, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/e2079979",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
            },
            new
            {
                Id = Guid.Parse("71a3d40e-7bb8-4a3f-b89c-9a465e1dd56a"),
                StartTime = new DateTime(2026, 2, 6, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/bf95142c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("74680039-27eb-4e40-b55e-23edf4c60328"),
                StartTime = new DateTime(2026, 3, 26, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/a1a36e9c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
            },
            new
            {
                Id = Guid.Parse("64de3b52-e261-4152-81fd-f1d74e3f7046"),
                StartTime = new DateTime(2026, 1, 15, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/5c7da5e7",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
            },
            new
            {
                Id = Guid.Parse("52506048-8fcd-4346-96b6-214f370e6b53"),
                StartTime = new DateTime(2025, 12, 28, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/f56a386d",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("4b57edca-127b-4497-875f-114bad7c3856"),
                StartTime = new DateTime(2026, 1, 8, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/384d5e55",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("b825d6bd-c958-4126-8d0d-c90f3e23786d"),
                StartTime = new DateTime(2026, 3, 8, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/4271b32e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("21eb18a4-4262-481b-8cf2-bf16dec017a8"),
                StartTime = new DateTime(2026, 2, 18, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/381eb402",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("71a66cfa-1fa5-4bd1-affa-dd48e489f3d4"),
                StartTime = new DateTime(2026, 2, 15, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/a60636a9",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63"),
                StartTime = new DateTime(2025, 11, 23, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/fd79bae8",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("4d1b3a95-0362-47c1-a014-9bcbac6a4d94"),
                StartTime = new DateTime(2025, 12, 24, 16, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/3c08b968",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("5d0fa399-05ed-46e4-ae17-6d4733c80660"),
                StartTime = new DateTime(2026, 2, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/1c2242ce",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
            },
            new
            {
                Id = Guid.Parse("37157991-98d4-4813-a465-1fdfc14c4223"),
                StartTime = new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/c70ba7f4",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("fdbdf55c-83d4-487c-b076-2fc0f5d43dc5"),
                StartTime = new DateTime(2026, 2, 2, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Deep dive into key concepts",
                LinkToMeeting = "https://example.com/meeting/f2c48858",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("940a3b5b-df1e-42c6-a6d3-f5245b7cb906"),
                StartTime = new DateTime(2025, 11, 19, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Concept reinforcement",
                LinkToMeeting = "https://example.com/meeting/8668096a",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("af2e3f3b-7d87-4834-8375-e2cbb87fac0c"),
                StartTime = new DateTime(2026, 2, 14, 14, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/67e9ccc3",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("4120596a-c73f-4bfc-800e-2c5af16d7358"),
                StartTime = new DateTime(2026, 3, 9, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/264bc52c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("98f91a97-26ff-43c2-a43a-710484d60456"),
                StartTime = new DateTime(2026, 1, 17, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/e5c3f780",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("e6c52897-0214-4739-8f04-b35f62f07350"),
                StartTime = new DateTime(2026, 3, 28, 13, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/aad383f5",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("3a6325f4-3044-4544-98e8-d6c9600d2d8b"),
                StartTime = new DateTime(2026, 1, 10, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/604bc72e",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("c010c4d1-28aa-41fb-bfc6-8680cf5ebdfe"),
                StartTime = new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/a719b848",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
            },
            new
            {
                Id = Guid.Parse("5c106a9c-8949-481b-adca-52395821e400"),
                StartTime = new DateTime(2026, 1, 10, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Practice problems",
                LinkToMeeting = "https://example.com/meeting/64d9eb32",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("9d186474-9046-4b72-b1e5-2b727d6bbcaf"),
                StartTime = new DateTime(2025, 10, 25, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Homework review",
                LinkToMeeting = "https://example.com/meeting/b52c95fe",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("1f274284-fee3-4120-a556-7e21e7269216"),
                StartTime = new DateTime(2025, 11, 2, 20, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/772e8415",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("264bb48f-1a05-4013-9f67-b89478dc22b0"),
                StartTime = new DateTime(2026, 3, 5, 19, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/edee693f",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("d769195a-da0a-439c-9d21-60354e16cee2"),
                StartTime = new DateTime(2025, 12, 19, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Exam prep session",
                LinkToMeeting = "https://example.com/meeting/3981b1aa",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
            },
            new
            {
                Id = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de"),
                StartTime = new DateTime(2026, 2, 22, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Continue topic",
                LinkToMeeting = "https://example.com/meeting/1fc8aad1",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("037a8b17-7aa8-47b4-860c-5632aff0af18"),
                StartTime = new DateTime(2025, 10, 23, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/4429e33c",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
            },
            new
            {
                Id = Guid.Parse("b24ad846-5f18-452a-be71-8700f9dbb4aa"),
                StartTime = new DateTime(2025, 12, 20, 17, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Wrap-up & next steps",
                LinkToMeeting = "https://example.com/meeting/5d2b72fd",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("f7cfc20c-93a3-475d-86a2-b8e85b8c67fe"),
                StartTime = new DateTime(2026, 2, 17, 15, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Project progress check",
                LinkToMeeting = "https://example.com/meeting/b2141971",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
            },
            new
            {
                Id = Guid.Parse("83ef5ead-64c6-474f-b5fb-8be4f8dfa6bd"),
                StartTime = new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/8be82956",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("5a155f6c-d51e-47ad-a85b-ee822b4cda07"),
                StartTime = new DateTime(2025, 12, 23, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Revision and Q&A",
                LinkToMeeting = "https://example.com/meeting/bbf96d99",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
            },
            new
            {
                Id = Guid.Parse("bd98eeae-5a92-40c1-b541-8c736ff0f6fe"),
                StartTime = new DateTime(2025, 11, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/e9f6b81a",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("d5665dc7-79cd-4752-94a5-655fb2bca54d"),
                StartTime = new DateTime(2026, 1, 12, 8, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/f4540c46",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
            },
            new
            {
                Id = Guid.Parse("7578f973-8b58-4df2-9372-8b9a2e6bd2ca"),
                StartTime = new DateTime(2025, 12, 10, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/9238a4f8",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
            },
            new
            {
                Id = Guid.Parse("74950363-d223-486b-9f33-cc0460b24371"),
                StartTime = new DateTime(2025, 11, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/e9f6b8ab",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("96115b32-35bb-4795-8acb-ef64c8351075"),
                StartTime = new DateTime(2026, 1, 12, 18, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/f4540cab",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
            },
            new
            {
                Id = Guid.Parse("13227742-f9f5-497d-8e38-09f5321dd5ec"),
                StartTime = new DateTime(2025, 12, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/9238a4ab",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("755881d1-fa2a-42e5-9139-175a8d75592b"),
                StartTime = new DateTime(2025, 10, 12, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/9238a4ab",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            },
            new
            {
                Id = Guid.Parse("f9e2f25f-384d-4c9f-9b85-f390d825a9cf"),
                StartTime = new DateTime(2025, 10, 10, 11, 0, 0, 0, DateTimeKind.Utc),
                Comment = "Follow-up tasks",
                LinkToMeeting = "https://example.com/meeting/9238a4ab",
                ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
            }
        );
    }
}