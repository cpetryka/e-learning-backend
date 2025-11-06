using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExerciseEntityTypeConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Instruction)
            .HasMaxLength(1000); // Optional limit

        builder.Property(e => e.Grade)
            .HasPrecision(3, 2); // For example: allow grades like 4.50

        builder.Property(e => e.Comment)
            .HasMaxLength(1000);

        builder.Property(e => e.Status)
            .HasConversion<string>() // Store enum as string, or use int if preferred
            .IsRequired();

        builder.HasOne(e => e.Class)
            .WithMany(c => c.Exercises)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Cascade); // Optional

        builder.HasMany(e => e.ExerciseResources)
            .WithOne(er => er.Exercise)
            .HasForeignKey(er => er.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Sample seed (optional)
       builder.HasData(
        new
        {
            Id = Guid.Parse("9e74adcc-18ac-447d-8e8b-560cdf62974d"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("5e232654-e629-49e3-98c2-4559505165c6")
        },
        new
        {
            Id = Guid.Parse("f9ebe167-f8eb-4ddd-b240-30ca9636849b"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("d3fd515d-c9a8-4a12-ae4b-045d2baaa725")
        },
        new
        {
            Id = Guid.Parse("616c22ba-dce5-4a31-abbf-be4d41b61165"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("2c7ddd20-534a-4f7f-a722-909ab0a67aad")
        },
        new
        {
            Id = Guid.Parse("284eba96-871c-46d8-a3f8-f06a27da2616"),
            Instruction = "Prepare a short presentation on today’s topic.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("597b6fe3-57e6-4831-a07c-991de998bfe2")
        },
        new
        {
            Id = Guid.Parse("63ffe7b8-4872-43d2-be04-2bd4c311b30e"),
            Instruction = "Solve a set of applied problems.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("166b7349-a733-48e5-bb04-e9f0f5f1eeaf")
        },
        new
        {
            Id = Guid.Parse("3636eec7-4c71-4842-9197-3cecabdc622a"),
            Instruction = "Complete practice tasks for the current module.",
            Grade = 3.50,
            Comment = "Nice progress and clear understanding.",
            Status = ExerciseStatus.Graded,
            ClassId = Guid.Parse("88176c18-6d5e-4fef-9357-dcf5bb605044")
        },
        new
        {
            Id = Guid.Parse("82061a75-b539-49e9-a5df-2ad6102e0732"),
            Instruction = "Complete practice tasks for the current module.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("3a686937-654b-4085-a4cb-91c7e0e79dc9")
        },
        new
        {
            Id = Guid.Parse("88762d5b-eb66-406f-805c-184acffedc5f"),
            Instruction = "Summarize key concepts and provide examples.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("bfbd200d-398b-4789-a002-32ea570134eb")
        },
        new
        {
            Id = Guid.Parse("c67d4f64-9080-49b6-8b87-6d4572f38d5f"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("55070d2d-5a26-4455-99a6-024fc3a33352")
        },
        new
        {
            Id = Guid.Parse("30ffea22-43f4-469f-a505-9c6749e84ab7"),
            Instruction = "Complete practice tasks for the current module.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("9f5ff908-4a04-446a-860c-320e81cc4984")
        },
        new
        {
            Id = Guid.Parse("689cfc13-37a4-4458-91be-71b42768b255"),
            Instruction = "Summarize key concepts and provide examples.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("bd5f6e6d-b411-4ffc-a4fd-5bd3cc52109c")
        },
        new
        {
            Id = Guid.Parse("05c2069e-05f6-4be8-8339-84c67a957c66"),
            Instruction = "Prepare a short presentation on today’s topic.",
            Status = ExerciseStatus.Submitted,
            ClassId = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d")
        },
        new
        {
            Id = Guid.Parse("8c764cd7-1cbf-4653-9da6-75fa7e01cd59"),
            Instruction = "Solve a set of05c2069e-05f6-4be8-8339-84c67a957c66 applied problems.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("8443a682-f3f4-4670-90af-3d636655ad12")
        },
        new
        {
            Id = Guid.Parse("3ed35daa-8282-480d-99e4-6e3d3b804193"),
            Instruction = "Solve a set of applied problems.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("6346be9b-73c4-4746-86a5-435fc4eaad56")
        },
        new
        {
            Id = Guid.Parse("695b123c-dadc-436f-8c1f-6aacf1206fa0"),
            Instruction = "Complete practice tasks for the current module.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("9c8b9a86-bc44-47ae-a5d6-bcbd930b9eb8")
        },
        new
        {
            Id = Guid.Parse("a59fe400-4223-4044-bc5d-b4848a44256c"),
            Instruction = "Complete practice tasks for the current module.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("f4ada7e9-9036-4e3b-86a1-1cffcd78ee72")
        },
        new
        {
            Id = Guid.Parse("d4b25db1-b9fe-4309-a95b-09aeed38fb7a"),
            Instruction = "Solve a set of applied problems.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("ccdbf889-4c34-48dc-8abf-f5701bc03a9e")
        },
        new
        {
            Id = Guid.Parse("4cfd55f8-3b5a-4e6f-9ce9-5d6dfb139139"),
            Instruction = "Complete practice tasks for the current module.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("3b1efa1b-cb60-4230-9085-7cde01984986")
        },
        new
        {
            Id = Guid.Parse("f56327f5-b6fe-487c-b3f2-e00c5db35b54"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("8c811295-5397-4967-acb2-09cdd24140ec")
        },
        new
        {
            Id = Guid.Parse("75be425d-7642-4a44-95f5-72275fab3d88"),
            Instruction = "Prepare a short presentation on today’s topic.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("9462cb25-3418-4fa0-9a84-b440cdcadab1")
        },
        new
        {
            Id = Guid.Parse("38f3a9f4-034f-4cf1-a5b6-cb220d06f1e1"),
            Instruction = "Prepare a short presentation on today’s topic.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("22010015-d84b-42f4-86ce-b543d315d4cc")
        },
        new
        {
            Id = Guid.Parse("4151d3e2-42e8-4bee-87c0-326f08aa636f"),
            Instruction = "Solve a set of applied problems.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("bae6f4fa-502b-482c-94c4-a10a025b0600")
        },
        new
        {
            Id = Guid.Parse("4ec94698-ba2d-4eb4-a079-dff2612edeea"),
            Instruction = "Summarize key concepts and provide examples.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("ef743714-1f09-4c80-a295-9c112e0c2cd6")
        },
        new
        {
            Id = Guid.Parse("b76d9a0a-8b49-43e5-a39d-bbd7221e81e0"),
            Instruction = "Summarize key concepts and provide examples.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("52506048-8fcd-4346-96b6-214f370e6b53")
        },
        new
        {
            Id = Guid.Parse("b2d86cd5-d0ba-426f-972a-d422a85bcc5a"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63")
        },
        new
        {
            Id = Guid.Parse("2fca8f74-8a0b-4fab-94d9-ab1ad27e2f10"),
            Instruction = "Review notes and submit a reflection.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("940a3b5b-df1e-42c6-a6d3-f5245b7cb906")
        },
        new
        {
            Id = Guid.Parse("78870638-40d8-4c1b-9fd7-98da571307e8"),
            Instruction = "Summarize key concepts and provide examples.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("3a6325f4-3044-4544-98e8-d6c9600d2d8b")
        },
        new
        {
            Id = Guid.Parse("fd378824-374b-43f4-b11c-1228eea3632f"),
            Instruction = "Summarize key concepts and provide examples.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("264bb48f-1a05-4013-9f67-b89478dc22b0")
        },
        new
        {
            Id = Guid.Parse("8b4ef5ee-83fa-464f-a1be-cae5180db6ff"),
            Instruction = "Complete practice tasks for the current module.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("f7cfc20c-93a3-475d-86a2-b8e85b8c67fe")
        },
        new
        {
            Id = Guid.Parse("ed679f30-0363-4a30-8a97-8e2edc75de12"),
            Instruction = "Prepare a short presentation on today’s topic.",
            Status = ExerciseStatus.Unsolved,
            ClassId = Guid.Parse("7578f973-8b58-4df2-9372-8b9a2e6bd2ca")
        }
);
    }
}