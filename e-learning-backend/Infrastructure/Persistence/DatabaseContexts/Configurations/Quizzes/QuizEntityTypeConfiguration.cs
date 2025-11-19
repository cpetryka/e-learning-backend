using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class QuizEntityTypeConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Class)
            .WithMany(c => c.Quizzes)
            .HasForeignKey(q => q.ClassId);

        builder.HasData(

            new
            {
                Id = Guid.Parse("8eb55468-07b8-4fb5-b752-e31ba6486530"),
                Title = "Biology Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("91221544-942a-4b51-8ace-6f3dc6a0acea"),
                Title = "Biology Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("adcfe5fa-fac8-4e7a-9d4b-df65b59f8d5a"),
                Title = "Biology Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("b1dcc07d-2d26-433d-a82d-62a7e5eb8b42"),
                Title = "Biology Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("cb9e52e6-6de7-4319-b25f-8ae594881a62"),
                Title = "Chemistry Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("6a39f1ca-a628-4a41-afea-96b23851008d"),
                Title = "Chemistry Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("a294da0d-d97a-4281-b7c3-b13081bea81e"),
                Title = "Chemistry Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("a25607ff-3a3c-43ad-81f6-8f84e9002a12"),
                Title = "Chemistry Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("3b651eb3-ccb2-4524-bbbf-8f0ec7c38491"),
                Title = "History Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("f79a044b-fab3-4a5e-af50-708e19e00fb0"),
                Title = "History Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("af3b9d28-f371-448e-8b64-b868b1ea4ed2"),
                Title = "History Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("31971797-cf4f-4049-81a7-24f4bf4008db"),
                Title = "Math Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("20dc07ca-3dff-40d1-9ee7-5c49dbf682d2"),
                Title = "Math Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("45ae1eba-cae5-4a9f-bea3-7d165f2e3bc1"),
                Title = "Math Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("3b89119a-1a72-405e-80aa-925776621d5c"),
                Title = "Math Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("43633ac5-b76e-4378-9221-3b8a16f5dad0"),
                Title = "Math Quiz 5",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("17bcf32c-8c26-412c-8175-079cc2efcaaa"),
                Title = "Math Quiz 6",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("c1e4dc01-4647-4736-86c8-7393fe95c463"),
                Title = "Math Quiz 7",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("4fe7c3b1-3872-460c-8580-ed7feed0f32b"),
                Title = "Physics Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("e58131a5-d14d-43be-adcb-106d6d7cc1c5"),
                Title = "Physics Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("4d20d213-d174-4d9b-8edd-4b47cdf86a90"),
                Title = "Physics Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("6868990a-d52b-473f-a593-98ad4b286dd9"),
                Title = "Physics Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("945a0fb0-4181-469e-be89-15432b725bef"),
                Title = "Physics Quiz 5",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("e6f07c36-5234-479e-be53-7d456f9ed9b9"),
                Title = "Programming Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("dfc64c9d-2100-4991-92fe-dc518c20c313"),
                Title = "Programming Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("2315f99d-5b5c-4371-a22d-1645f723872f"),
                Title = "Programming Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("b1625a9f-fad5-43c6-a85f-ac80b93eac84"),
                Title = "Programming Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            },
            new
            {
                Id = Guid.Parse("09cd7d4d-607d-40f4-bb5e-95672409583d"),
                Title = "Programming Quiz 5",
                MultipleChoice = false,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            }
);

    }
}