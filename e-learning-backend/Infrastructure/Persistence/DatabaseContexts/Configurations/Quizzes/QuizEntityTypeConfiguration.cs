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

            // Biology (teacher 555e5555-...)
            new
            {
                Id = Guid.Parse("8eb55468-07b8-4fb5-b752-e31ba6486530"),
                Title = "Biology Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("166b7349-a733-48e5-bb04-e9f0f5f1eeaf")
            },
            new
            {
                Id = Guid.Parse("91221544-942a-4b51-8ace-6f3dc6a0acea"),
                Title = "Biology Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("21deedff-73f7-44b9-af4e-faf877677023")
            },
            new
            {
                Id = Guid.Parse("adcfe5fa-fac8-4e7a-9d4b-df65b59f8d5a"),
                Title = "Biology Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("22010015-d84b-42f4-86ce-b543d315d4cc")
            },
            new
            {
                Id = Guid.Parse("b1dcc07d-2d26-433d-a82d-62a7e5eb8b42"),
                Title = "Biology Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("23acbb91-af14-4f83-961f-80051c1f2a43")
            },

            // Chemistry (teacher 11111111-...)
            new
            {
                Id = Guid.Parse("cb9e52e6-6de7-4319-b25f-8ae594881a62"),
                Title = "Chemistry Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d")
            },
            new
            {
                Id = Guid.Parse("6a39f1ca-a628-4a41-afea-96b23851008d"),
                Title = "Chemistry Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("10761475-fd6f-452f-9817-0f5b11e907a9")
            },
            new
            {
                Id = Guid.Parse("a294da0d-d97a-4281-b7c3-b13081bea81e"),
                Title = "Chemistry Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("1619b967-7450-472f-9ced-a9c4ab701318")
            },
            new
            {
                Id = Guid.Parse("a25607ff-3a3c-43ad-81f6-8f84e9002a12"),
                Title = "Chemistry Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63")
            },

            // History (teacher 555e5555-...)
            new
            {
                Id = Guid.Parse("3b651eb3-ccb2-4524-bbbf-8f0ec7c38491"),
                Title = "History Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("264bb48f-1a05-4013-9f67-b89478dc22b0")
            },
            new
            {
                Id = Guid.Parse("f79a044b-fab3-4a5e-af50-708e19e00fb0"),
                Title = "History Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("2a9cc83b-cb2c-4b30-a149-9886736ae4ce")
            },
            new
            {
                Id = Guid.Parse("af3b9d28-f371-448e-8b64-b868b1ea4ed2"),
                Title = "History Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("3b436cdc-53ea-4c80-a947-ca1a7ccc350b")
            },

            // Math (teacher 11111111-...)
            new
            {
                Id = Guid.Parse("31971797-cf4f-4049-81a7-24f4bf4008db"),
                Title = "Math Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("1c617641-f474-4b97-b528-f1e0c2d31ced")
            },
            new
            {
                Id = Guid.Parse("20dc07ca-3dff-40d1-9ee7-5c49dbf682d2"),
                Title = "Math Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("1d8eedb2-9518-49b3-b484-a9e11af14b43")
            },
            new
            {
                Id = Guid.Parse("45ae1eba-cae5-4a9f-bea3-7d165f2e3bc1"),
                Title = "Math Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("1f274284-fee3-4120-a556-7e21e7269216")
            },
            new
            {
                Id = Guid.Parse("3b89119a-1a72-405e-80aa-925776621d5c"),
                Title = "Math Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("1fd4ce1c-ffcf-4046-b2e4-16dfcb025dd6")
            },
            new
            {
                Id = Guid.Parse("43633ac5-b76e-4378-9221-3b8a16f5dad0"),
                Title = "Math Quiz 5",
                MultipleChoice = false,
                ClassId = Guid.Parse("21eb18a4-4262-481b-8cf2-bf16dec017a8")
            },
            new
            {
                Id = Guid.Parse("17bcf32c-8c26-412c-8175-079cc2efcaaa"),
                Title = "Math Quiz 6",
                MultipleChoice = false,
                ClassId = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de")
            },
            new
            {
                Id = Guid.Parse("c1e4dc01-4647-4736-86c8-7393fe95c463"),
                Title = "Math Quiz 7",
                MultipleChoice = false,
                ClassId = Guid.Parse("2988615a-e919-4555-94fc-1dad57bb1897")
            },

            // Physics (teacher 11111111-...)
            new
            {
                Id = Guid.Parse("4fe7c3b1-3872-460c-8580-ed7feed0f32b"),
                Title = "Physics Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("2e10ef79-df92-4442-879f-f8369864bb7c")
            },
            new
            {
                Id = Guid.Parse("e58131a5-d14d-43be-adcb-106d6d7cc1c5"),
                Title = "Physics Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("37157991-98d4-4813-a465-1fdfc14c4223")
            },
            new
            {
                Id = Guid.Parse("4d20d213-d174-4d9b-8edd-4b47cdf86a90"),
                Title = "Physics Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("376af187-37fb-4da2-bc48-3ab25c514214")
            },
            new
            {
                Id = Guid.Parse("6868990a-d52b-473f-a593-98ad4b286dd9"),
                Title = "Physics Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("3a686937-654b-4085-a4cb-91c7e0e79dc9")
            },
            new
            {
                Id = Guid.Parse("945a0fb0-4181-469e-be89-15432b725bef"),
                Title = "Physics Quiz 5",
                MultipleChoice = false,
                ClassId = Guid.Parse("41668901-3476-4573-8230-7ba6cad7ad61")
            },

            // Programming (teacher 11111111-...)
            new
            {
                Id = Guid.Parse("e6f07c36-5234-479e-be53-7d456f9ed9b9"),
                Title = "Programming Quiz 1",
                MultipleChoice = false,
                ClassId = Guid.Parse("430ff2e4-5dc8-4ea2-a8f7-fa2724ae2abc")
            },
            new
            {
                Id = Guid.Parse("dfc64c9d-2100-4991-92fe-dc518c20c313"),
                Title = "Programming Quiz 2",
                MultipleChoice = false,
                ClassId = Guid.Parse("4b57edca-127b-4497-875f-114bad7c3856")
            },
            new
            {
                Id = Guid.Parse("2315f99d-5b5c-4371-a22d-1645f723872f"),
                Title = "Programming Quiz 3",
                MultipleChoice = false,
                ClassId = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8")
            },
            new
            {
                Id = Guid.Parse("b1625a9f-fad5-43c6-a85f-ac80b93eac84"),
                Title = "Programming Quiz 4",
                MultipleChoice = false,
                ClassId = Guid.Parse("56e6affb-1bf8-4953-b14e-0899824125ac")
            },
            new
            {
                Id = Guid.Parse("09cd7d4d-607d-40f4-bb5e-95672409583d"),
                Title = "Programming Quiz 5",
                MultipleChoice = false,
                ClassId = Guid.Parse("5c106a9c-8949-481b-adca-52395821e400")
            }
        );
    }
}
