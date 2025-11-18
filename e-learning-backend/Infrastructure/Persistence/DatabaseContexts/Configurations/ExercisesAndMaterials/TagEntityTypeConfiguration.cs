namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        // Relacja 1..* z User (Teacher)
        builder.HasOne(t => t.User)
            .WithMany(u => u.Tags)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacja wiele-do-wielu z FileResource
        builder.HasMany(t => t.Files)
            .WithMany(f => f.Tags)
            .UsingEntity<Dictionary<string, object>>(
                "TagFile",
                j => j
                    .HasOne<FileResource>()
                    .WithMany()
                    .HasForeignKey("FileResourceId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("TagId", "FileResourceId");
                    j.ToTable("TagFiles");

                    j.HasData(

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555553555555")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("70f94315-d6c1-415d-b327-57430ee490c6")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("70f94315-d6c1-415d-b327-57430ee490c6")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("4c6f3dc2-336c-4821-9063-05ba8e884165")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("4c6f3dc2-336c-4821-9063-05ba8e884165")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("7383a95b-961e-4b88-9a3a-7edb9c2b5bff")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("7383a95b-961e-4b88-9a3a-7edb9c2b5bff")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("681c0181-9d7a-4ec5-b179-ee9eb40ec018")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("681c0181-9d7a-4ec5-b179-ee9eb40ec018")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("681c0181-9d7a-4ec5-b179-ee9eb40ec018")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("70dcd2b3-bc6b-4e74-b467-a8fa3b5bf571")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("02ec10f6-92ef-4095-96b6-244db10924e0")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("66d08c8d-2c0d-46d8-9e5d-64da20c354b4")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("ee7a2d96-8cf4-49f9-b92a-f729c525e6c4")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("ee7a2d96-8cf4-49f9-b92a-f729c525e6c4")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("1806c3a4-10b3-4710-8101-c8bee54c5260")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("1806c3a4-10b3-4710-8101-c8bee54c5260")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("484dbaec-d078-48b2-8b59-2a2255dc9c8d")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("484dbaec-d078-48b2-8b59-2a2255dc9c8d")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("484dbaec-d078-48b2-8b59-2a2255dc9c8d")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("09ceba9f-1e38-4f3d-ad99-13f9dd962c47")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("09ceba9f-1e38-4f3d-ad99-13f9dd962c47")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("09ceba9f-1e38-4f3d-ad99-13f9dd962c47")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("08db0c26-12a8-4820-ad0f-f202b3975808")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("08db0c26-12a8-4820-ad0f-f202b3975808")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("530c76c7-3499-4317-ab8e-bd6c8064069e")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("cb73e98e-b15c-468c-8b54-e6f30520d913")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("efa2962d-00f7-4ad7-a876-48580001842a")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("9773566f-d117-4aa8-914f-206f03bf8bbc")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("f850d2a0-401a-42d0-b7d6-3b48f3d521e6")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("f850d2a0-401a-42d0-b7d6-3b48f3d521e6")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("3508750f-9aa2-451b-a904-195d2d7b865d")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("71886ca9-0934-4366-b024-05b09eb1786f")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("71886ca9-0934-4366-b024-05b09eb1786f")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("71886ca9-0934-4366-b024-05b09eb1786f")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("f3b859b2-6d5f-4454-af38-be31d3136a2b")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("bcd14879-7cea-428a-b05f-27937fad0227")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("bcd14879-7cea-428a-b05f-27937fad0227")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("bcd14879-7cea-428a-b05f-27937fad0227")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("9b23217d-dc5b-47f9-a5a1-bc290a926dea")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("b6956ae6-a1e5-46e4-b9c7-c1809bf8af6d")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("b6956ae6-a1e5-46e4-b9c7-c1809bf8af6d")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("5be6383f-b726-427e-85a6-66f5365e66d2")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("744dc886-d2b2-4138-970b-46ed880e1c69")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("744dc886-d2b2-4138-970b-46ed880e1c69")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("744dc886-d2b2-4138-970b-46ed880e1c69")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("a85a21fd-8eb5-45e0-b33e-30cf35c82d9a")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("a85a21fd-8eb5-45e0-b33e-30cf35c82d9a")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("a85a21fd-8eb5-45e0-b33e-30cf35c82d9a")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("0daa2725-4723-4d23-a2b7-a0cc78beb358")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("ab5adb07-1292-49d4-8fed-109fd46f15e5")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("b4a8d4ce-85bc-4369-9b09-6f56ad52bbc9")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("68f8991f-4cdc-4938-aaa2-fde985f0de9b")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("68f8991f-4cdc-4938-aaa2-fde985f0de9b")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("68f8991f-4cdc-4938-aaa2-fde985f0de9b")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("4057a05d-0938-40d4-ae58-e0e6238ad69d")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("4057a05d-0938-40d4-ae58-e0e6238ad69d")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("b2300c20-45fd-4b0f-87e0-d5dd1cbd799e")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("b2300c20-45fd-4b0f-87e0-d5dd1cbd799e")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("b2300c20-45fd-4b0f-87e0-d5dd1cbd799e")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("c7ffea05-32ee-4400-a903-86118dcde893")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("c7ffea05-32ee-4400-a903-86118dcde893")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("c7ffea05-32ee-4400-a903-86118dcde893")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("6d159251-a804-466f-9899-15ade9209901")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("6d159251-a804-466f-9899-15ade9209901")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("6d159251-a804-466f-9899-15ade9209901")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("e09f27fa-224e-46f8-8f7d-b1cd43398ee6")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("e09f27fa-224e-46f8-8f7d-b1cd43398ee6")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("f00f0a0d-3f48-42eb-a213-cedca2a4a8b5")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("f00f0a0d-3f48-42eb-a213-cedca2a4a8b5")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("d6e95855-f2c6-4c20-81d5-46a556f66cb1")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("d6e95855-f2c6-4c20-81d5-46a556f66cb1")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("d6e95855-f2c6-4c20-81d5-46a556f66cb1")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("c482e273-bbc2-4bdd-8381-0cdb25f5062a")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("c482e273-bbc2-4bdd-8381-0cdb25f5062a")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("efd36d02-1d97-4fbe-a857-7aa4bc2e2efb")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("efd36d02-1d97-4fbe-a857-7aa4bc2e2efb")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("7eda8c18-1ca4-40d6-a320-4e7316c4b0fd")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("7eda8c18-1ca4-40d6-a320-4e7316c4b0fd")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("7eda8c18-1ca4-40d6-a320-4e7316c4b0fd")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("727b404c-e11a-4084-90f1-d09b1132d754")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("3245277f-e208-4d6c-8716-d7347500dfa6")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("3245277f-e208-4d6c-8716-d7347500dfa6")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("ed2e0d67-0ed8-4851-8fde-c918a495eec0")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("ed2e0d67-0ed8-4851-8fde-c918a495eec0")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("ed2e0d67-0ed8-4851-8fde-c918a495eec0")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("54f4a8ef-54c2-4303-ac48-373d726523d6")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("54f4a8ef-54c2-4303-ac48-373d726523d6")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("08a2d00e-f098-4819-9b63-2601a2bfb797")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("97cbfdd7-79a5-4da0-86ae-931aac5edf12")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("97cbfdd7-79a5-4da0-86ae-931aac5edf12")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("97cbfdd7-79a5-4da0-86ae-931aac5edf12")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("e5a65f43-d917-4574-b6a1-0178cfb02fc7")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("e5a65f43-d917-4574-b6a1-0178cfb02fc7")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("638ea5a8-2b5f-4a98-b762-e1039d261212")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("dfedd8a8-6e3b-406f-b0d2-868429098ef8")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("dfedd8a8-6e3b-406f-b0d2-868429098ef8")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("e885e572-465a-40bb-907f-6b36d713cc8d")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("e885e572-465a-40bb-907f-6b36d713cc8d")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("f47ddb7a-9e13-4cad-999b-022a902b98a5")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("2d19abfd-6294-4374-80c1-113bb3df4082")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("c5f4e126-2c33-4112-8767-43b4ccdddbd2")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("49999268-5d22-48d1-bde0-2cde904c4821")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("49999268-5d22-48d1-bde0-2cde904c4821")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("49999268-5d22-48d1-bde0-2cde904c4821")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("79400d29-f724-4ea3-b8b0-ac4630240bec")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("79400d29-f724-4ea3-b8b0-ac4630240bec")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("79400d29-f724-4ea3-b8b0-ac4630240bec")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("d1b97ed5-fb8e-43fd-9dd6-7a5410d5a48b")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("cf4d553c-e286-4267-9639-d5b02fad9c61")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("cf4d553c-e286-4267-9639-d5b02fad9c61")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("cf4d553c-e286-4267-9639-d5b02fad9c61")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("e77f6a08-bd8d-44a7-9595-857f90f01b84")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("e77f6a08-bd8d-44a7-9595-857f90f01b84")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("e77f6a08-bd8d-44a7-9595-857f90f01b84")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("92f1e4c0-caca-48b6-91fc-edb3feb3e4bb")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("229fbf70-010a-4114-a41e-7e523e960e95")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("060deee0-d8c3-415d-8d87-77c7d98a62b6")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("600d584f-431c-4769-837d-8f2e228bb747")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("d3f264f9-e251-48c4-8bb8-ad6c4d4b9ea5")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("d3f264f9-e251-48c4-8bb8-ad6c4d4b9ea5")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("e8e90cfb-2873-4e1e-822d-57e54ec383a5")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("e8e90cfb-2873-4e1e-822d-57e54ec383a5")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("e8e90cfb-2873-4e1e-822d-57e54ec383a5")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("e8a57581-57d3-4923-afbf-ee2a7164801c")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("68483230-4fe6-4877-badf-f01001cd06eb")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("68483230-4fe6-4877-badf-f01001cd06eb")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("4ecf5f24-e7d6-4ab3-ba61-2d797e08b1e2")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("4ecf5f24-e7d6-4ab3-ba61-2d797e08b1e2")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("4ecf5f24-e7d6-4ab3-ba61-2d797e08b1e2")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("f9ff7ebb-6a69-41af-96cb-9e4e29beb4af")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("357c6f37-12e8-4799-8e3d-46a8677ce8af")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("1f5a05cb-46ef-4b2b-b9b2-588633a77330")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("1f5a05cb-46ef-4b2b-b9b2-588633a77330")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("71c4d5ea-6a02-41c9-9ca4-0f4adee5cda1")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("c9e02bbb-f963-4891-b89d-69922410446f")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("c9e02bbb-f963-4891-b89d-69922410446f")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("75ac7c65-a602-4c9a-b73f-8efdfb172d16")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("75ac7c65-a602-4c9a-b73f-8efdfb172d16")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("75ac7c65-a602-4c9a-b73f-8efdfb172d16")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("2027b871-f60a-4d89-86fe-29d4d0b026db")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("ea47bdf0-fff5-4be1-a832-307b7ddd6acb")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("30b2d6e7-77b1-42bf-9df4-f01f4e256d70")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("30b2d6e7-77b1-42bf-9df4-f01f4e256d70")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("edb3c2db-481f-4ddc-bd52-243c5b67d8fa")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("edb3c2db-481f-4ddc-bd52-243c5b67d8fa")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("84788e82-62d6-4aaa-9477-249140609d11")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("b3f82ce4-e70f-4f5c-bd81-7a25190010cb")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("0ea7a9ed-cc12-407f-b3b9-06403b725011")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("0347335e-7c9a-4320-8b27-925074d62d61")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("0347335e-7c9a-4320-8b27-925074d62d61")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("3ead8784-22c2-4951-9793-7a92dab8a1f6")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("2c2fc722-f8bb-45d2-9eb0-963b77e2544e")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("2c2fc722-f8bb-45d2-9eb0-963b77e2544e")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("c5848d65-4342-4b8a-83a9-40e2d782288a")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("c5848d65-4342-4b8a-83a9-40e2d782288a")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("c5848d65-4342-4b8a-83a9-40e2d782288a")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("aa0b1060-5efc-411a-9dcb-7d078a88a6bb")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("0dc6494d-6d95-445d-b15b-0699ce78f9f9")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("5e52947e-af54-49ba-8d3e-9137f27c9765")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("5e52947e-af54-49ba-8d3e-9137f27c9765")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("5e52947e-af54-49ba-8d3e-9137f27c9765")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("740dc3b7-7a86-4280-ba1d-69af6626aaaa")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("740dc3b7-7a86-4280-ba1d-69af6626aaaa")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("524bef74-df26-4f54-95e9-6eda63f5ec08")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("524bef74-df26-4f54-95e9-6eda63f5ec08")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("94d95f4f-12f2-4f66-8898-4528d622a131")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("94d95f4f-12f2-4f66-8898-4528d622a131")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("94d95f4f-12f2-4f66-8898-4528d622a131")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("ae351af9-cd99-4df6-b747-d43356f6c98f")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("ae351af9-cd99-4df6-b747-d43356f6c98f")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("72ef33dd-f372-4c90-bac0-aad8d8e943f1")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("72ef33dd-f372-4c90-bac0-aad8d8e943f1")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("72ef33dd-f372-4c90-bac0-aad8d8e943f1")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("1eb8005e-f99b-4a64-bce1-eb765c6a1a85")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("45459f48-29b6-4db9-86fa-4c5d5ad74959")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("7122a8dc-cbbf-4009-b205-c93a1f6beffa")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("7122a8dc-cbbf-4009-b205-c93a1f6beffa")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("725b54c9-aae3-4d26-b817-3c1945861172")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("1857aa9c-e9c6-4574-94b0-9564457ec555")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("a751c0b2-f59a-4d23-8040-ccb6877eff73")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("a751c0b2-f59a-4d23-8040-ccb6877eff73")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("a751c0b2-f59a-4d23-8040-ccb6877eff73")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("41555b22-0101-43a6-ab8b-398f5beeaa03")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("fa578ae1-c882-457f-8606-25a2599b81cf")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("fa578ae1-c882-457f-8606-25a2599b81cf")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("fa578ae1-c882-457f-8606-25a2599b81cf")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("0a5b774d-611d-4f60-bdbd-2b8d2f44b080")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("0a5b774d-611d-4f60-bdbd-2b8d2f44b080")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("4a9baa48-49be-4a05-a270-0ddabc9ddfea")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("6e8c6a6b-a053-446a-91d9-fa2919962da6")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("6e8c6a6b-a053-446a-91d9-fa2919962da6")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("eb91ff59-e5d6-4a83-8928-85d2f94bfc0f")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("eb91ff59-e5d6-4a83-8928-85d2f94bfc0f")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("eb91ff59-e5d6-4a83-8928-85d2f94bfc0f")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("0529481a-0ade-469b-b986-c6e7b19be7e7")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("0529481a-0ade-469b-b986-c6e7b19be7e7")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("0529481a-0ade-469b-b986-c6e7b19be7e7")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("f6916b97-d4ff-407e-b352-2caffe73df1b")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("109a9818-fbbc-45a5-bbf5-eb0d8917146d")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("109a9818-fbbc-45a5-bbf5-eb0d8917146d")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("109a9818-fbbc-45a5-bbf5-eb0d8917146d")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("110c1e3e-35c3-4520-b78d-f6d7ec2b709b")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("110c1e3e-35c3-4520-b78d-f6d7ec2b709b")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("110c1e3e-35c3-4520-b78d-f6d7ec2b709b")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("565eb799-cbbd-43d3-bb7a-7cd83cb29ec9")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("565eb799-cbbd-43d3-bb7a-7cd83cb29ec9")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("aa3887a6-fea8-4197-ab7c-d20004d7fce5")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("aa3887a6-fea8-4197-ab7c-d20004d7fce5")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("aa3887a6-fea8-4197-ab7c-d20004d7fce5")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("a8919856-a312-4664-a2e9-8119fb88e341")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("a8919856-a312-4664-a2e9-8119fb88e341")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("31ec03c1-e879-47c4-8d6f-a8df029e51bc")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("31ec03c1-e879-47c4-8d6f-a8df029e51bc")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("31ec03c1-e879-47c4-8d6f-a8df029e51bc")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("49d1f450-280d-436e-9dee-36f6b8d0d816")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("4e33cc01-9107-4ef6-a238-d203bdf2bc6e")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("30c74646-3d53-43d1-95b1-d1c35dc52d3e")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("30c74646-3d53-43d1-95b1-d1c35dc52d3e")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("72d4898c-30fd-4b9f-bc05-8d672275ef2a")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("72d4898c-30fd-4b9f-bc05-8d672275ef2a")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("72d4898c-30fd-4b9f-bc05-8d672275ef2a")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("e4d61189-0b01-4465-98bb-85ef6d23dbd8")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("e4d61189-0b01-4465-98bb-85ef6d23dbd8")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("80d90177-0b0b-45f5-bfd5-d1253b36bf53")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("80d90177-0b0b-45f5-bfd5-d1253b36bf53")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("2e2c759b-2bb5-4393-baf5-1f02f964262a")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("391c17ab-dd63-43dd-bd10-42280c0ab796")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("1bac7d2e-8ad9-40a3-b64e-288398831097")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("1bac7d2e-8ad9-40a3-b64e-288398831097")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("4f076a46-ab8a-4022-80bb-12d7243caab3")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("41ed3209-43b1-4b4e-bb6d-93e4aeec16a9")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("41ed3209-43b1-4b4e-bb6d-93e4aeec16a9")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("16fb3af3-610f-47a5-b09f-9eddf20fc423")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("16fb3af3-610f-47a5-b09f-9eddf20fc423")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("0d012bd7-072e-4c72-9019-8f52b9638453")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("fcdf48c1-0c10-4fe0-b124-9d002cf877ef")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("fcdf48c1-0c10-4fe0-b124-9d002cf877ef")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("fcdf48c1-0c10-4fe0-b124-9d002cf877ef")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("36851905-2710-4f01-b910-e4a1ffb65298")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("36851905-2710-4f01-b910-e4a1ffb65298")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("36851905-2710-4f01-b910-e4a1ffb65298")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("66e238fc-79d0-4900-a67a-8d534439a75a")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("66e238fc-79d0-4900-a67a-8d534439a75a")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("66e238fc-79d0-4900-a67a-8d534439a75a")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("0cf5a17d-8b34-4721-8ca3-e361df33d6c1")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("1e93f58d-d695-4d5b-b738-13f4727cfa9e")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("1e93f58d-d695-4d5b-b738-13f4727cfa9e")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("1e93f58d-d695-4d5b-b738-13f4727cfa9e")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("2ad1247f-c66f-4f8c-ae0a-b9b0f11335fb")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("2ad1247f-c66f-4f8c-ae0a-b9b0f11335fb")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("868904c4-c480-454e-8537-d6bf0f22b7c6")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("868904c4-c480-454e-8537-d6bf0f22b7c6")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("868904c4-c480-454e-8537-d6bf0f22b7c6")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("70cc378c-52a5-4be8-bb45-942e4721fb87")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("b18f76c8-214a-45c2-9080-ffc03d0312ea")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("b18f76c8-214a-45c2-9080-ffc03d0312ea")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("b18f76c8-214a-45c2-9080-ffc03d0312ea")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("b4ece921-f15f-4f32-827a-85c4a898af7b")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("b4ece921-f15f-4f32-827a-85c4a898af7b")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("b4ece921-f15f-4f32-827a-85c4a898af7b")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("a13acbde-ad9c-4f94-bb27-772b6284f0f2")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("a13acbde-ad9c-4f94-bb27-772b6284f0f2")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("a13acbde-ad9c-4f94-bb27-772b6284f0f2")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("a5eedee1-703a-4917-8046-e00aeae99efd")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("a5eedee1-703a-4917-8046-e00aeae99efd")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("a5eedee1-703a-4917-8046-e00aeae99efd")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("830769a2-b9cc-478a-abb1-d266cf63f8b1")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("830769a2-b9cc-478a-abb1-d266cf63f8b1")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("6ff3899e-6fea-45fe-9879-262fa2137e60")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("a029be01-642e-4c80-bb26-07602802a4b3")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("a029be01-642e-4c80-bb26-07602802a4b3")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("343dc503-d358-40e7-b18d-8713dc6b1fbb")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("343dc503-d358-40e7-b18d-8713dc6b1fbb")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("8a1ce3f4-f04c-4a21-a645-4b83434d39a4")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("b3313cd8-7b2b-4d7b-a2ac-8c47ecf95834")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("327fbb37-3a07-4b25-ade7-b2d4f2ed1bba")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("327fbb37-3a07-4b25-ade7-b2d4f2ed1bba")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("327fbb37-3a07-4b25-ade7-b2d4f2ed1bba")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("6ab6f54f-540b-4781-bf7d-335503538852")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("6ab6f54f-540b-4781-bf7d-335503538852")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("6ab6f54f-540b-4781-bf7d-335503538852")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("7368bb0f-aa3b-4571-8e9d-c332a484996b")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("067f61fa-dccb-4b9a-a195-07757e788a35")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("b84f6d62-38f8-4834-9185-63623e1f17b6")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("b84f6d62-38f8-4834-9185-63623e1f17b6")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("b84f6d62-38f8-4834-9185-63623e1f17b6")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("13493563-bfe2-42c2-9c7f-cc50256c6786")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("13493563-bfe2-42c2-9c7f-cc50256c6786")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("13493563-bfe2-42c2-9c7f-cc50256c6786")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("ceb337a0-55b3-4ceb-8870-8d5796a09aa2")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("ceb337a0-55b3-4ceb-8870-8d5796a09aa2")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("7cff958f-e3a0-4707-86a6-99c168f251b5")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("7cff958f-e3a0-4707-86a6-99c168f251b5")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("7cff958f-e3a0-4707-86a6-99c168f251b5")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("cce23af1-d4cc-40ad-a309-6c224abd6fff")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("be7ed2ed-394f-4427-ad73-8f72bb13f0a2")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("36a3fcd5-fda9-491a-8d5e-b00275c10abf")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("36a3fcd5-fda9-491a-8d5e-b00275c10abf")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("36a3fcd5-fda9-491a-8d5e-b00275c10abf")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("4473ad0f-5cf8-4b11-83f4-c4179a99fd84")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("4473ad0f-5cf8-4b11-83f4-c4179a99fd84")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("e8482fb8-6886-42ac-9ccf-993a15327f9b")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("e8482fb8-6886-42ac-9ccf-993a15327f9b")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("e8482fb8-6886-42ac-9ccf-993a15327f9b")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("2268583f-9730-4140-831e-490bfc8cca62")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("dfbfc2a3-345f-406a-b24c-09b5cdca57bb")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("8852eafa-6067-43de-899d-693358679187")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("ac91eb22-2228-4117-a84e-398d6e21c18e")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("6652728a-f322-43fe-869d-61c59aaf2cbf")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("6652728a-f322-43fe-869d-61c59aaf2cbf")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("6652728a-f322-43fe-869d-61c59aaf2cbf")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("23ca6cf8-986a-425b-bbd4-8e47f9740341")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("5fc6693c-6352-4a89-b674-6c2c520fd8dc")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("5fc6693c-6352-4a89-b674-6c2c520fd8dc")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("509b1073-9342-4af1-bdbe-eff798296e77")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("509b1073-9342-4af1-bdbe-eff798296e77")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("509b1073-9342-4af1-bdbe-eff798296e77")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("cf5129ad-f33a-44ff-9658-45e0b54aae8d")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("cf5129ad-f33a-44ff-9658-45e0b54aae8d")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("3442e566-e83e-4d14-9df6-1c954c828b7a")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("3442e566-e83e-4d14-9df6-1c954c828b7a")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("dd3e89ce-9013-463d-9925-2f4a106bd53d")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("8deefb73-5211-403d-a374-18e5dade2341")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("8deefb73-5211-403d-a374-18e5dade2341")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("ca184750-f40a-4d14-ba06-e6eda721a30b")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("ca184750-f40a-4d14-ba06-e6eda721a30b")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("c19636fe-cef7-4de0-ab3b-9d7fee4ef79b")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("c19636fe-cef7-4de0-ab3b-9d7fee4ef79b")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("06c9743e-19f4-492e-98fb-17508611b246")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("06c9743e-19f4-492e-98fb-17508611b246")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("9edc1592-f62b-46d1-8dd6-01f70e11a863")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("9edc1592-f62b-46d1-8dd6-01f70e11a863")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("9edc1592-f62b-46d1-8dd6-01f70e11a863")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("e132dd10-48af-4d5d-8107-d571286f3851")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("e132dd10-48af-4d5d-8107-d571286f3851")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("e132dd10-48af-4d5d-8107-d571286f3851")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("a7fcaf67-c839-42f3-b0b4-e7f691c63a26")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("e90c029c-e120-486e-bbf2-1d3ab3b83874")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("e90c029c-e120-486e-bbf2-1d3ab3b83874")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("e90c029c-e120-486e-bbf2-1d3ab3b83874")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("4df48f8c-4731-4c97-8535-436a0a063b69")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("4df48f8c-4731-4c97-8535-436a0a063b69")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("0b1d682b-4318-45e1-9c34-6cdb743ecb0a")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("a5f6f521-3389-4fc4-a67b-ed833bd5fe2d")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("026a55db-e502-4db9-aacb-3cab00a41d66")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("026a55db-e502-4db9-aacb-3cab00a41d66")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("026a55db-e502-4db9-aacb-3cab00a41d66")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("dbdacd45-525f-4d12-a880-4c96f635b251")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("dbdacd45-525f-4d12-a880-4c96f635b251")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("dbdacd45-525f-4d12-a880-4c96f635b251")
    },

    new
    {
        TagId = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
        FileResourceId = Guid.Parse("66e0c73e-3843-48b7-be0b-12618da0255e")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("66e0c73e-3843-48b7-be0b-12618da0255e")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("27e6344d-3edf-4f93-904f-3b1314bd5ea5")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("27e6344d-3edf-4f93-904f-3b1314bd5ea5")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("36253f18-096f-42d0-8aae-60cb3c88cd97")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("43ad10f7-13d7-43bb-a009-2b1e4c851868")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("43ad10f7-13d7-43bb-a009-2b1e4c851868")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("43ad10f7-13d7-43bb-a009-2b1e4c851868")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("1ea32fd4-c25f-4aaf-9120-1b089157c28a")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("1ea32fd4-c25f-4aaf-9120-1b089157c28a")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("2c706c0c-53d2-423a-b571-6de36c6551ed")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("2c706c0c-53d2-423a-b571-6de36c6551ed")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("70f1a5f0-2ab3-4990-929a-d53ee0ecc6a9")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("e842fa3a-c572-48c0-9dda-3810b45ff133")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("e842fa3a-c572-48c0-9dda-3810b45ff133")
    },

    new
    {
        TagId = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
        FileResourceId = Guid.Parse("e842fa3a-c572-48c0-9dda-3810b45ff133")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("5295b3fd-1a0c-4b83-a0a1-bb04dccf40df")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("84c3aede-faea-4546-a93e-8c8d95d8b289")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("84c3aede-faea-4546-a93e-8c8d95d8b289")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("9354fd6e-680f-47a1-a4db-a900ec33f7fb")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("9354fd6e-680f-47a1-a4db-a900ec33f7fb")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("9354fd6e-680f-47a1-a4db-a900ec33f7fb")
    },

    new
    {
        TagId = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
        FileResourceId = Guid.Parse("04c762ff-386e-45b5-acef-672582a5fe03")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("04c762ff-386e-45b5-acef-672582a5fe03")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("04c762ff-386e-45b5-acef-672582a5fe03")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("9e5bd71e-4631-4a69-9a92-4e66c372fcf7")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("f4ed5454-3d22-476c-b8ec-7316e1d228f4")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("f4ed5454-3d22-476c-b8ec-7316e1d228f4")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("4499d56c-1bcf-4a00-967f-f2c1499e3bb8")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("d0e0f4c1-82a6-443e-be89-3fb1b6f71322")
    },

    new
    {
        TagId = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
        FileResourceId = Guid.Parse("a61749d9-1dc8-4a86-a2f1-6721f0dbe5b3")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("a61749d9-1dc8-4a86-a2f1-6721f0dbe5b3")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc")
    },

    new
    {
        TagId = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
        FileResourceId = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc")
    },

    new
    {
        TagId = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
        FileResourceId = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc")
    },

    new
    {
        TagId = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
        FileResourceId = Guid.Parse("667b30a6-2167-4394-8346-d4d3f8b894f2")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("667b30a6-2167-4394-8346-d4d3f8b894f2")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("f8444b9b-13d7-4aaa-abda-3cb4420f4dab")
    },

    new
    {
        TagId = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
        FileResourceId = Guid.Parse("2efadb1c-bd85-4b08-81c5-e4082a3d07b8")
    },

    new
    {
        TagId = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
        FileResourceId = Guid.Parse("2efadb1c-bd85-4b08-81c5-e4082a3d07b8")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("2efadb1c-bd85-4b08-81c5-e4082a3d07b8")
    },

    new
    {
        TagId = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
        FileResourceId = Guid.Parse("929994c8-e86b-4a6b-afa2-3fbf1a63662b")
    },

    new
    {
        TagId = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
        FileResourceId = Guid.Parse("929994c8-e86b-4a6b-afa2-3fbf1a63662b")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("506d6bfc-25ad-468a-bf89-c2dc1ce7b654")
    },

    new
    {
        TagId = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
        FileResourceId = Guid.Parse("506d6bfc-25ad-468a-bf89-c2dc1ce7b654")
    },

    new
    {
        TagId = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
        FileResourceId = Guid.Parse("40c12560-c27e-483c-80ed-78423683ed57")
    },

    new
    {
        TagId = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
        FileResourceId = Guid.Parse("40c12560-c27e-483c-80ed-78423683ed57")
    },

    new
    {
        TagId = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
        FileResourceId = Guid.Parse("40c12560-c27e-483c-80ed-78423683ed57")
    }
);

                }
            );

        // Przykladowe dane
        var teacherId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        builder.HasData(
            new
            {
                Id = Guid.Parse("146a6a07-34c5-4672-8f56-fb1df6d88c49"),
                Name = "Archived",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("851e2a16-1ac9-47d9-abaa-5407824215e4"),
                Name = "Data Structures",
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("c2229a82-66e3-4c0d-b99f-0b712bd481ee"),
                Name = "Networking",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("dbdc9a3b-88d0-41dd-99ee-d856d93ff30c"),
                Name = "Cloud Computing",
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4db39c4e-94a9-4e0b-ba83-8665f9fe51b8"),
                Name = "Physics",
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("8cf89aff-b925-4f7d-8f51-ca5fec14fc32"),
                Name = "Worksheet",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("58b1027e-3889-494d-842b-aee770cb821a"),
                Name = "Algorithms",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("bcda4afb-2ea0-4507-93ee-6d95ef6b2e5c"),
                Name = "Homework",
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("38401440-100d-463c-a9b5-b6643a93f97a"),
                Name = "Visual",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("013aa8a3-8cd0-4c08-91c6-d0f76cb69806"),
                Name = "Machine Learning",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("1ec5854f-8341-44a2-af4b-44d3ba3adbce"),
                Name = "Geography",
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("09d3b35a-fa2c-48cc-adcf-6136cefceb1d"),
                Name = "Lab Work",
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("a04ea550-e032-4370-b3bd-f8e58de3b794"),
                Name = "Project",
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("96e0ab5d-3a68-4bba-92f3-4c4573bf23dc"),
                Name = "Communication Skills",
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("20ff72f2-1a54-4305-b281-112617bacc83"),
                Name = "Backup",
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            }
        );
    }
}