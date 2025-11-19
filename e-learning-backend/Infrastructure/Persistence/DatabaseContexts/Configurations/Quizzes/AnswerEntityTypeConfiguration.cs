using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Content)
            .IsRequired();

        builder.HasData(
            new
            {
                Id = Guid.Parse("522b7eb4-1a17-4ce0-8ea0-1c6e9c31313d"),
                Content = "Rise over run",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4bdb40cc-9997-439c-a6e3-be1bbbf676cb"),
                Content = "A number divisible only by 1 and itself",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5059087e-4e3f-44bb-af77-a93712470435"),
                Content = "A quantity with only magnitude",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("92c3b6ff-d882-4fde-b676-c65924441df8"),
                Content = "The instantaneous rate of change of a function",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("86af689e-e12e-4ab5-9bb4-4f76e87412b3"),
                Content = "An expression with variables and coefficients",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d7945830-2779-49f8-b7f7-d6fe1fa24a48"),
                Content = "A rectangular array of numbers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d580af30-408f-45bc-8d15-a23294703087"),
                Content = "Valid inputs of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("65fe6cbd-3a6b-465d-8b61-6ce3f7b7e898"),
                Content = "The area under a curve",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("64674459-365c-4a8c-b9ea-07a213e0716e"),
                Content = "Inverse of exponentiation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("121f0485-7d9c-4fef-82a1-6fbf3c7bc6ce"),
                Content = "The value a function approaches",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("39da648f-ecb0-4742-8a30-12a83ddfced6"),
                Content = "A quantity with magnitude and direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("28b5196c-0888-4027-b28c-dd7f9c5b7fa7"),
                Content = "A vector v satisfying Av = λv",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a354e397-30a5-4735-b052-ea8190688ef0"),
                Content = "Middle value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6758d9cf-48c5-4788-8ce2-bb17b5d4035c"),
                Content = "A rectangular array of numbers",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("988d6397-0602-49a5-808c-f0021e81c597"),
                Content = "An expression with variables and coefficients",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("24258820-892a-4001-8043-f514f1992296"),
                Content = "Line a curve approaches",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("246caeb7-bef4-40e2-b9b3-7991c7816b82"),
                Content = "A quantity with magnitude and direction",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("adc3400f-7c5e-4d7e-bb59-e28d5a39cfde"),
                Content = "Line a curve approaches",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ffc0ff4e-4500-48f9-81d1-138925ead028"),
                Content = "Sum of sequence terms",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c9bb8751-abbc-448c-b3b7-45b688482524"),
                Content = "The instantaneous rate of change of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7c287158-e397-4120-a6d4-93ec6d38a68f"),
                Content = "A vector v satisfying Av = λv",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a1a0a438-57a4-4b24-a780-5e084667bcbf"),
                Content = "Most common value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9724a714-6c0f-4919-b83c-f9c5e826321b"),
                Content = "A quantity with only magnitude",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("de60bbaf-a3df-4dde-9b9f-85765e981ee7"),
                Content = "The instantaneous rate of change of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("818ea6f9-b4af-4f6e-9bb7-ff87179d114c"),
                Content = "Average squared deviation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e25478a2-2e10-43bc-8334-1c03f4a76c5f"),
                Content = "A measure of likelihood",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2f040767-9c83-40e9-bbc3-5f8762ef5358"),
                Content = "A number divisible only by 1 and itself",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("abe74229-61ef-4313-bc79-99ee642d6c8e"),
                Content = "Unordered selection",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f1d4485b-43d1-4527-9178-8ad1781944b7"),
                Content = "The instantaneous rate of change of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9e351e8f-6cd4-45d4-a397-5fa303a70f34"),
                Content = "A number expressible as a fraction a/b",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c35ec458-d48c-4d76-8e30-36b3896a4820"),
                Content = "The value a function approaches",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("cdcfd291-bb1f-4d0d-be7b-3ed76abf6aab"),
                Content = "A scalar λ satisfying Av = λv",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7b5933df-dd89-45fe-a0d2-753612b902b0"),
                Content = "A number not expressible as a/b",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("6fe66776-d24f-4d95-885c-7a99bebd6253"),
                Content = "Number in form a+bi",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("cd3e34f0-9ffe-485f-94a5-6cca17b1a6c2"),
                Content = "Collection of elements",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3df4ce11-a675-49f8-9f2a-79dafda17cf7"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2b17f2c4-38ba-4084-88dd-78fb58c2a3c6"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3e2018c3-55d1-413c-b0d2-e44293425ef3"),
                Content = "Product of all integers up to n",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fc0306c2-62ba-464f-8b10-0649ff750e69"),
                Content = "Unordered selection",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("07027600-d0f0-4186-979b-7f6e584319b2"),
                Content = "An expression with variables and coefficients",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("6d6c0762-9d2f-4d66-8f1b-935df43b0ad8"),
                Content = "Middle value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("28e88628-5629-4e38-8f51-ce3722a1e36c"),
                Content = "Line a curve approaches",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a81c272a-e6b4-4e05-9884-e067c8f354d3"),
                Content = "A measure of likelihood",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5829b69b-9e12-4273-935b-928ecf5258be"),
                Content = "(-b±√(b²−4ac))/2a",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e222594e-1ba3-4cb8-867d-4251a1ac0021"),
                Content = "Most common value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e419cf41-b507-44d1-8853-f3951beac315"),
                Content = "The area under a curve",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f1d81357-df9e-428c-b2c0-405f1d0c6937"),
                Content = "A measure of spread",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("753ba360-d89f-45f5-a288-0b9ccb35d508"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9ec8aeb4-1024-4a17-a3b6-9e365868dc96"),
                Content = "A number not expressible as a/b",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d28a113a-1214-448f-b8e3-fa62353c5a38"),
                Content = "A quantity with only magnitude",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fb8e204b-f75d-424b-9fd3-fa6ebedc7207"),
                Content = "A quantity with magnitude and direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b8d29b2e-3b26-45a4-918c-229f0b82b316"),
                Content = "Average value",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d197b8e8-b6ec-42d2-b5aa-b71f639b9b36"),
                Content = "Ordered arrangement",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f371c8ed-3a7c-48ac-87dd-1e829032ce29"),
                Content = "The instantaneous rate of change of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9c8d1072-8a75-41c4-b7df-003dfe00c5ad"),
                Content = "Middle value",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("afd669dd-1dfa-4836-bee9-227231f3fed2"),
                Content = "A number expressible as a fraction a/b",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("09c6b8b7-7283-40d8-b337-cbe79655b22b"),
                Content = "Most common value",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("a42717bf-25ce-4951-bc32-562c354bd2bd"),
                Content = "A quantity with magnitude and direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("79cfa818-a316-4b01-aff0-1591a54938bc"),
                Content = "Scalar describing matrix transformation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("089fc99b-d795-413c-bdde-2a5f0dbacd95"),
                Content = "Sum of sequence terms",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e38db27e-6f3e-460f-8262-dd0f870a0d05"),
                Content = "A number not expressible as a/b",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("29dca7fc-10a4-44dc-917e-94327bb6e7c4"),
                Content = "Product of all integers up to n",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("71e1757b-5f3c-497a-be43-38fefecf06bf"),
                Content = "A quantity with only magnitude",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7c35a78c-279e-4664-a8ea-6a6ac0e665f5"),
                Content = "Inverse of exponentiation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4701f2db-1cfb-4fe8-b5c1-82da5e217939"),
                Content = "Line a curve approaches",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1fad069f-7835-4dae-ae7c-580ed3b8c0dd"),
                Content = "Vector of partial derivatives",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d6438e0f-1168-46ff-a7d8-1e8956c21622"),
                Content = "A number expressible as a fraction a/b",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a716df99-6965-48fd-9ef5-e2baea36ad7d"),
                Content = "Average value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6cc2e373-4660-41a4-925b-d04991506abb"),
                Content = "A scalar λ satisfying Av = λv",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("fa3fa8a9-ccfa-477f-ad0e-d63f6914ffd7"),
                Content = "A number divisible only by 1 and itself",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6f7e1644-5123-43ba-998d-465c4f65e3bd"),
                Content = "A measure of likelihood",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("84319e62-bf62-4482-9120-cd270e4d6eb5"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8909cdb8-c330-421d-aed1-4edbd01e2c0e"),
                Content = "Inverse of exponentiation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("65feb913-1c7f-4cc3-a207-05810fe3e24f"),
                Content = "A quantity with magnitude and direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2687ca6e-89d9-4a1c-9852-b81206c3d008"),
                Content = "A vector v satisfying Av = λv",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("a8338183-1b67-4c05-a5a5-b416648f8725"),
                Content = "A function involving e^x",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4cf24611-9aab-45c7-bb48-0499ddd8a1d6"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e0ea3ea8-2c91-4d9a-9e24-2f680cf4b567"),
                Content = "Average squared deviation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("170dccd4-e0e3-475a-a768-3c7a0409dd9c"),
                Content = "The instantaneous rate of change of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f6b72aca-a747-47b3-9114-5191f039d643"),
                Content = "Scalar describing matrix transformation",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5caea40e-2396-48b2-863f-c694e9f750b9"),
                Content = "Scalar describing matrix transformation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("17521b23-46fc-47f2-9fe4-fe0efd0a732c"),
                Content = "A quantity with only magnitude",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e4b7e255-4154-43c5-837f-0469a26168a6"),
                Content = "Middle value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("69898652-1a8a-4fcd-89c4-e50fe06f8c2f"),
                Content = "Inverse of exponentiation",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("33e84643-974c-4ffb-9d23-d945b7dbc584"),
                Content = "An expression with variables and coefficients",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1962934d-93dd-4802-a463-7f0a8e28b1d9"),
                Content = "Middle value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e61abe64-91c0-451d-aace-e85e98129237"),
                Content = "Ordered list of numbers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d7105ef8-1bc3-4698-ab70-5f023aa2a27c"),
                Content = "A function involving e^x",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("fa288fe0-e422-42ed-bb60-fadb751759db"),
                Content = "Number in form a+bi",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("55b3f1fb-5ed3-4089-b9c5-d0f8d8807560"),
                Content = "(-b±√(b²−4ac))/2a",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8870fb6f-3163-45ef-aa1d-a39bb16ed29e"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("287c63fb-56fb-43aa-a291-e33562c3e60d"),
                Content = "A number not expressible as a/b",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4f0a8d8e-6e4b-437d-8b66-8c9732c8715d"),
                Content = "A function involving e^x",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("31a05fc7-ed13-4875-990c-665088c58014"),
                Content = "Line a curve approaches",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("87711727-de40-4bc9-8b78-9266f375ec1e"),
                Content = "Scalar describing matrix transformation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("75a1387f-9345-4202-aa4e-19990ca5ff39"),
                Content = "(-b±√(b²−4ac))/2a",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fab92b1d-88be-4297-a84c-87e00249cd09"),
                Content = "Ordered list of numbers",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("cee332b8-3adb-4770-b3b1-1b89d855829c"),
                Content = "Product of all integers up to n",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0950f4be-8e0c-44c2-9a0a-4c8c24c5ff4d"),
                Content = "(-b±√(b²−4ac))/2a",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("81c9ee81-fc47-4928-ac76-f71c7cda5f96"),
                Content = "The area under a curve",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f3c4b508-ea95-4b45-bca1-9973ef536901"),
                Content = "Vector of partial derivatives",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5d6652f0-c9fd-479b-97e7-ecd8ef192be3"),
                Content = "Sum of sequence terms",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("51455aeb-5422-48d7-88eb-11195a79dc58"),
                Content = "Valid inputs of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("82a5d396-d7d9-4db8-a25e-bb10ed3312a8"),
                Content = "Inverse of exponentiation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("68cc1292-65db-4a30-8895-bd1d335e5ffc"),
                Content = "Number in form a+bi",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0898b7b1-5b37-4139-8caa-d93bd565df38"),
                Content = "Ordered arrangement",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("aaa5e22a-bcf9-40b5-b23f-865c87b1f4e3"),
                Content = "A measure of spread",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1f754a14-4562-4655-bdaa-85219c90fa20"),
                Content = "The value a function approaches",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7340bb61-3d1a-442b-96e0-65b73afa51c7"),
                Content = "A number divisible only by 1 and itself",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9108685f-28bf-45c3-970a-baa67d89bc7e"),
                Content = "Unordered selection",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("79902777-1bac-4d86-988a-12a22b61d080"),
                Content = "A rectangular array of numbers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("409da3f6-884c-4195-acf8-1a45b38b0e09"),
                Content = "Most common value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f5c41025-8d6f-45c5-8385-0633b62d679e"),
                Content = "Inverse of exponentiation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f39ba987-95f2-4c51-b692-9447fe88fb06"),
                Content = "A measure of likelihood",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5ea7fd94-8f19-45ab-b1bf-08ff8f908348"),
                Content = "Collection of elements",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5a77999d-aa60-47dd-a101-3b78179274f2"),
                Content = "Possible outputs of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("69c70033-14f6-4ae1-88f6-d6a0c42b769e"),
                Content = "A scalar λ satisfying Av = λv",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("32c86ac4-f2b2-4b01-a18c-7dd47859818f"),
                Content = "Valid inputs of a function",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("da5cbd3d-0d80-4d03-904b-c2d9b54cf05c"),
                Content = "Vector of partial derivatives",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7430aa4c-f9e3-4e8a-921b-8aa1bdee5765"),
                Content = "The number i = √(-1)",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9ef27728-74f5-40d5-b747-d2b30776d245"),
                Content = "A measure of likelihood",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4438d0ca-bca4-4223-afc8-40628762db6d"),
                Content = "Possible outputs of a function",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("a59a6c87-0af9-452c-861e-874388f1495b"),
                Content = "A quantity with only magnitude",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d2a9973f-0f59-4ac1-891c-5e8c30a76d31"),
                Content = "Ordered list of numbers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5878db00-5e9f-4661-89c8-8fec91326728"),
                Content = "Rise over run",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("6f71abe7-b89d-4ca3-a530-197b1ff9e9c1"),
                Content = "The number i = √(-1)",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7fd3996f-bce7-4af7-aa41-f6bbef54d1a6"),
                Content = "Unordered selection",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("19d370d6-886e-4391-805a-449347f76c24"),
                Content = "Scalar describing matrix transformation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("738d8af8-b7c8-41ef-b1da-ca29977c67b6"),
                Content = "A measure of spread",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bd0dee23-64e3-4ba9-97c5-f46f72d89c6d"),
                Content = "Number in form a+bi",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d2504be5-bc18-4569-ba31-8eedb4855bcc"),
                Content = "Valid inputs of a function",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f2c11c91-c429-409b-b2c3-08c1fd39f866"),
                Content = "Ordered list of numbers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5753498b-9136-4d8a-b88a-27106efdf598"),
                Content = "Sum of sequence terms",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7ed2ed41-6ca3-489f-b696-bde88ea3694d"),
                Content = "Average value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2b7672af-c331-4aa8-9c62-32120b457af3"),
                Content = "A quantity with magnitude and direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("18525a53-985e-4ef9-9958-7aa72d310c74"),
                Content = "The number i = √(-1)",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("751796dc-29f7-492e-8f11-e9917b74b555"),
                Content = "Collection of elements",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e01273ee-ea38-407d-9888-51468628b08c"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("119ed704-387d-4212-aa6f-4d60fed80fae"),
                Content = "(-b±√(b²−4ac))/2a",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("0edba893-1c3d-44bb-860f-9317e5459fdb"),
                Content = "Product of all integers up to n",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6992a9f4-4cca-4ac5-b3ed-daa25d1e8ef3"),
                Content = "Average squared deviation",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("881c4f9e-3e54-40b2-85c0-33c4d8edd88d"),
                Content = "Scalar describing matrix transformation",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("aa628fa6-c570-4b50-9248-394dac88969d"),
                Content = "A vector v satisfying Av = λv",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b8ca2d09-be47-436d-a195-ced1be7ed9a2"),
                Content = "A mapping from inputs to outputs",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("21246020-e4d6-441c-9944-b1e106e10615"),
                Content = "Stored energy",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("594487e2-cd63-4b7d-af13-a0de1a9d0690"),
                Content = "Mass per volume",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f05522c9-3c53-4bfd-8e0c-11cc7f1083f3"),
                Content = "Speed with direction",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("8d9bcb3b-9f30-49fd-9c55-92e440a9e010"),
                Content = "Mass × velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b2dd5125-33b4-4fd8-ab88-7ff244eb2c69"),
                Content = "A push or pull",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("680a6df6-5055-4f6b-b3ea-f22d29960efc"),
                Content = "Rate of change of velocity",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d5ff97d5-1601-4078-9204-b71b1ebea2d9"),
                Content = "Rate of doing work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7c350d20-c195-43e7-8f9b-8d5c8c836f2d"),
                Content = "Particle of light",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a9d7c210-8704-4fbf-a36a-03b9d0a1d1f5"),
                Content = "A push or pull",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5bb0558b-bbc7-42a2-a0fc-96f79ae8bff7"),
                Content = "Rate of change of velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a424e1f2-39c1-4e1e-8f29-8e5e94f5efd0"),
                Content = "Force per area",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("51d779ef-f703-4ac1-99a5-ee8b265d5616"),
                Content = "Resistance to change in motion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f3090273-7350-4136-89f6-2c3fcd766788"),
                Content = "Mass × velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("77e7c486-9c09-48a3-b65d-1c01e1007934"),
                Content = "Force of gravity on mass",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0e2cd551-b753-4f84-b35a-7a79cea33321"),
                Content = "Ability to do work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fe306de3-d47b-42dd-9a60-16e3884fee61"),
                Content = "Amount of matter",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("8cfee747-fcef-4fe3-82e6-659eaf64e5b7"),
                Content = "Amount of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d617a650-3d19-482a-90fc-3b347e592393"),
                Content = "Negative subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b8dd0f67-6100-454c-b5a5-62399d793a93"),
                Content = "Opposition to current",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("80a44c60-ece5-41b5-b3b7-136119511953"),
                Content = "Force of gravity on mass",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("27c875c3-7d88-44fd-90f4-d2b883744806"),
                Content = "Mass × velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6b3de8cf-e92f-4085-87e4-b45816d05db7"),
                Content = "Rate of doing work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d8e8e775-94c3-42d5-a8f6-ed832bac285c"),
                Content = "Ability to do work",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f52cb318-bfaf-443c-a2a3-15739c323ad4"),
                Content = "Attractive force between masses",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1d1941d2-2b47-473d-b64e-fb7716000dec"),
                Content = "Mass per volume",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("08438ae8-4426-4f5a-9237-4c97f1f12782"),
                Content = "Opposition to current",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b02c7184-1cde-4f6a-89a8-bdeecd98249d"),
                Content = "Energy of motion",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c6552c8f-380c-43d5-9d72-63649a7e9934"),
                Content = "Change in momentum",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("58307925-6809-41b7-9385-847f69a8b4ce"),
                Content = "Stored energy",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("80a9efd1-0955-499f-8fa8-1d12fab15139"),
                Content = "Positive subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4e369f15-0224-4282-af35-1df1d82ee460"),
                Content = "Rate of doing work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f61d63fb-2aa2-446e-8403-74d7b82ff459"),
                Content = "Change in momentum",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("eecdf5a9-c0c1-4d33-b19c-4cbf3ae50c77"),
                Content = "Rate of doing work",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c27c5f58-4260-46bd-8377-5ac8e184483a"),
                Content = "Change in momentum",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("66f1fe6e-b7aa-40ef-a30c-3dc5fdb82780"),
                Content = "Speed with direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7cb668dd-47bb-44c5-8f53-358758d180c6"),
                Content = "Amount of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f63e2603-ef1d-4967-b9a4-f487f7811d14"),
                Content = "Amount of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1ac68ebe-48b5-4b6f-9baf-88574e0a5664"),
                Content = "Light bouncing back",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("60a88bd2-1dba-4f7b-b42d-7ce7b9801c3c"),
                Content = "Mass × velocity",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("abce9464-051e-403b-9845-c7500bf3f516"),
                Content = "Opposition to current",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("13352994-7667-42b6-be9b-cb5e2a6b465f"),
                Content = "Electric potential difference",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fad3698f-a27a-4deb-ae39-000ac4f3e421"),
                Content = "Change in momentum",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("dd6c768b-729f-469b-a8a2-29b7c5927c15"),
                Content = "Bending of light",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4ae7642b-f105-4969-bfd5-93bd65f508dc"),
                Content = "Resistance to change in motion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d938b6a0-0734-4d6c-986c-a9c2d0c6ac1c"),
                Content = "Opposition to current",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a7764a83-f1f9-43b2-8903-13e18d6a780a"),
                Content = "Rate of doing work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("daacca98-b573-4771-8fc1-bdd1f2154293"),
                Content = "Electric potential difference",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("172c5c66-56dc-4d90-9e43-d47f1b52d066"),
                Content = "Force resisting motion",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("7cc5a8d5-4e75-48b7-96cb-f948b199270f"),
                Content = "Attractive force between masses",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4d224da0-e0f3-41fd-8fc2-e3a5201bc19b"),
                Content = "Stored energy",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c84e2f9d-3137-41a9-9b0b-0790ba684897"),
                Content = "Change in momentum",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fbabef6a-79c5-48e4-ac35-9a3c4d61899d"),
                Content = "Flow of charge",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3593d61b-17e8-4978-bc33-b88307fe1ccb"),
                Content = "Force per area",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("3aa9c095-6638-40db-b7da-b2447aa52c93"),
                Content = "Mass × velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7504ec59-d2e0-4497-a827-8070e25ffbf7"),
                Content = "Mass per volume",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f11b87c1-c94a-4b2f-824e-dcd65315f3c0"),
                Content = "Neutral subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4de16e82-35f5-4111-9e3b-fe3cebab78d9"),
                Content = "Rate of change of velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("479e9629-7ef8-4b1f-8cc6-7a882dd702a4"),
                Content = "Mass per volume",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c35a3b3c-6fb0-481e-9a2b-85bc7f0ca9a7"),
                Content = "Negative subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("05e8cbfb-30b8-41aa-9670-ecd27b918879"),
                Content = "Light bouncing back",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("eb049dcf-5cac-4852-87e3-01bf69482289"),
                Content = "A push or pull",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ef02a11c-2b37-4a9b-83f6-06221c5f7dac"),
                Content = "Flow of charge",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("a3f531b1-f03b-4cad-9bc9-2fe1f8b232cc"),
                Content = "Force resisting motion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2e688d73-207a-424b-be30-a0566cb85ee6"),
                Content = "Particle of light",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("772c7b39-1709-460a-9266-219cec3c5ef7"),
                Content = "Speed with direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1d6f1236-6c36-4ac8-bb0b-f530644aa0c1"),
                Content = "Neutral subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e7f85d56-03bc-4dd3-a645-3cc561ac31cf"),
                Content = "Mass per volume",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8eeb2a12-8eac-4064-9747-91d7a7194a97"),
                Content = "Electric potential difference",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("526fb8c9-0db3-496b-a788-ed50f3926d0a"),
                Content = "Opposition to current",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("60f68150-9f54-4e96-a637-ad6d7ad3a06f"),
                Content = "Speed with direction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("cc5e1839-b761-4a23-8169-d4c8f61de763"),
                Content = "Flow of charge",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("77995030-7df0-41a6-ab82-3d24fe52bf95"),
                Content = "Force per area",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fae4839f-3ecb-4c07-b5cf-ff31e58cf257"),
                Content = "Positive subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("69d8ad1f-c8f1-42ff-8a05-55922105b72d"),
                Content = "Light bouncing back",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c4e3d59c-f6a1-4290-8fc5-594112053498"),
                Content = "Particle of light",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("3e119085-1016-40c0-8961-58118fb93cf6"),
                Content = "Bending of light",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("abfe2d38-33ab-406a-a3e2-1659a073ced9"),
                Content = "Neutral subatomic particle",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("61dae676-46c3-41ef-9830-797655408764"),
                Content = "Electric potential difference",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2394600e-2abe-47e5-83b7-656373bbda60"),
                Content = "Stored energy",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("84ab2f87-5b66-4f9c-bbcf-f2608d3161ac"),
                Content = "Force per area",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("dbf8285d-842f-49ca-aaed-fe8a9a653530"),
                Content = "Flow of charge",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("98250d40-b845-43d1-8726-c3ab2d61ab9d"),
                Content = "Ability to do work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4935cccd-0aad-4355-8de7-e8163f575cd8"),
                Content = "Electric potential difference",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fd2abd19-1e8c-4756-a705-d26f409eb34f"),
                Content = "Negative subatomic particle",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c81815ea-2020-4901-bdcd-ecc61dee5dcb"),
                Content = "Positive subatomic particle",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f7af6230-2661-436e-a4df-ae11d4dfbc90"),
                Content = "Measure of disorder",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("56af8260-49a3-4ebd-823b-385f198b7d4c"),
                Content = "Attractive force between masses",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4eadee43-417f-4d38-959d-7ac7604c25eb"),
                Content = "Rate of doing work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("60d9122a-590c-4abe-bc8d-ef48f4e69a37"),
                Content = "Mass per volume",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0600c86e-10c7-47ac-8d9f-379b10dc622d"),
                Content = "Opposition to current",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("808d12e9-d180-4583-97ce-a079aa62c5f8"),
                Content = "Rate of change of velocity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2bc57e98-d09a-495a-b64f-84be0050d183"),
                Content = "Bending of light",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f8ce81a0-f5f9-455c-963c-2751d4d560fb"),
                Content = "Attractive force between masses",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e385c212-aa9f-4c59-9825-7373cce6edb6"),
                Content = "Force of gravity on mass",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8ba34320-d7ee-487e-bee4-c6f4e7a49908"),
                Content = "Light bouncing back",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("e56936ca-0893-43f5-ab66-6cb8c76386b7"),
                Content = "Energy of motion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("afbb602e-d823-45b0-b23a-1e1b310e4a4f"),
                Content = "Amount of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4958345c-f660-49c4-a3c9-cc7bea857f16"),
                Content = "Measure of disorder",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("de3ef722-4b2d-43ed-aecb-c51570f921e7"),
                Content = "Opposition to current",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1ddc7cce-1715-41b6-b8fc-3f1ce44ad89a"),
                Content = "Resistance to change in motion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d9d68b5d-832c-4b94-bc3d-089d7058186e"),
                Content = "Neutral subatomic particle",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d6c82a3a-fcaa-4124-979f-8102c4b10db3"),
                Content = "Resistance to change in motion",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("eb280afa-5c35-4c9f-a714-a9b35bf0c68a"),
                Content = "Stored energy",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3127587a-f351-4942-a3e1-39f1b41d7d5b"),
                Content = "Ability to do work",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("82408fc6-2ab2-4cd3-8c48-dab1cc87173a"),
                Content = "DNA package",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("22644d15-d88f-42cf-99d3-31ca77500e51"),
                Content = "Change in species over time",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ddd0657f-4504-43f1-bb9d-f9e5ee165344"),
                Content = "Basic unit of life",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("64bc6078-6a13-4508-af06-ad05665ed27c"),
                Content = "DNA/RNA building block",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2c3b454c-001c-4f94-9423-0d1c405c453b"),
                Content = "Structure that contains DNA",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9dcf4c69-bb4d-4060-98d7-c918771b0ddc"),
                Content = "Nerve cell",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e15fcb91-67a5-4709-9124-b74321b09747"),
                Content = "Site of photosynthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6fff50cf-c62c-47bf-929f-a698365fea4e"),
                Content = "Biological catalyst",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("740b14ec-556a-4917-bd9d-d74e28c9ee28"),
                Content = "Genetic material",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9ef06441-2f70-4c31-8df4-698bd25808f0"),
                Content = "Unit of heredity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0fa5ba1c-4d82-4842-99b7-bcba18666ff5"),
                Content = "Molecule for protein synthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f438efad-e118-4c90-86fd-53826a4dbabf"),
                Content = "Conversion of sunlight to glucose",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("50740d95-7e23-403d-a531-8db17481f6a6"),
                Content = "Molecule for protein synthesis",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f7f532d8-4216-4269-b582-cb3840ed77fe"),
                Content = "Sugar molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("46150ada-2c0a-4c8d-b0d5-b20038f8b11d"),
                Content = "DNA package",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("78d21491-4ffc-4868-8d07-aa10d9711037"),
                Content = "Nerve cell",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7215a227-c5ee-4218-9b00-4bba92bb6a7c"),
                Content = "DNA/RNA building block",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2ab03705-4b48-4b1d-b9b0-902a896722cb"),
                Content = "Fat molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bd80a595-e114-4e57-a5dd-230157b15d1c"),
                Content = "Protein factory",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("477628b8-0f50-4388-bde1-a923f013aca0"),
                Content = "Molecule for protein synthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1ee8d84c-26f3-4262-bcea-908281e68ed3"),
                Content = "Genetic material",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9a87f172-394a-4e3f-b0e2-805d294a74f4"),
                Content = "Fat molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b5e67170-a90c-4522-862a-85ad8b78da4e"),
                Content = "Protein factory",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bf5016c7-867b-4434-9acb-b99c93552a02"),
                Content = "Produces ATP",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c8352a78-05dd-453a-a45e-af12dac5df3a"),
                Content = "Site of photosynthesis",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("3a054a96-f59b-4629-bef9-ee7e62414ffd"),
                Content = "Chain of amino acids",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("89f2af63-4b72-4064-861d-c43400c6d204"),
                Content = "Change in species over time",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ed572bd4-b408-4f1a-850a-8feea22d77ac"),
                Content = "Nerve cell",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c93f43e7-084e-4425-86a2-f526aaccec0c"),
                Content = "Conversion of sunlight to glucose",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9fbeba85-d69c-4579-a067-b36f155b7d9b"),
                Content = "Stable internal conditions",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("35306998-855a-481b-8286-18e8d9176e2a"),
                Content = "Sugar molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6f53f830-d426-4ed9-994d-7c5a79445934"),
                Content = "Genetic material",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2bcca169-5248-44da-a84c-1dfb21af9f72"),
                Content = "Sugar molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("868f3fd0-4dfb-40ac-a6a3-51fac0df4a26"),
                Content = "Fat molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a29b4107-9f39-4a51-b385-a60ba6e44e76"),
                Content = "ATP generation from glucose",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d83574ce-59d1-451b-995a-fbd99956dff3"),
                Content = "Chain of amino acids",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b0d5b635-a2ac-4c35-a227-655c622bd924"),
                Content = "Basic unit of life",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d8a6b229-5713-478a-bf11-668ce63d72f2"),
                Content = "Biological catalyst",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("354615a9-f86c-419a-af2e-2e66ba90b466"),
                Content = "Chain of amino acids",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("43779f86-9682-4184-93e5-8bb1186b9a38"),
                Content = "Molecule for protein synthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2bee6e8a-369e-4229-bbe5-20bfeb73f8c7"),
                Content = "Chain of amino acids",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4afe95f2-5b68-4c59-bca3-b4f7283f3da7"),
                Content = "Gap between neurons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("97631942-c39a-4970-9bbf-beca636fccf2"),
                Content = "Structure that contains DNA",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2e7c1a5d-360d-418a-a2da-8c7726f42e7a"),
                Content = "Basic unit of life",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d8256e05-dd44-463c-9ae5-329e23e7e3b8"),
                Content = "Genetic material",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8c4284fe-bd9a-4d55-aaee-48811b66fc8c"),
                Content = "DNA/RNA building block",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9f21235d-994e-4e0e-9388-da010524d0c2"),
                Content = "Gap between neurons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2625f224-69f0-45af-afd3-95161046252e"),
                Content = "Sugar molecule",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9d03d033-8a54-48fc-9dd5-8296d5fdff59"),
                Content = "Fat molecule",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("b662d6e4-83e6-4794-a821-a376ea4fa215"),
                Content = "Biological catalyst",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("26e8bd66-e2a3-4581-9251-bc2710889f4d"),
                Content = "Site of photosynthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a614e52d-97ab-4b46-9bb6-17d82aa13f79"),
                Content = "ATP generation from glucose",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fec9b118-9d11-498a-a53f-3ce458f0436d"),
                Content = "Protein factory",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0b318f64-e5fc-4c1a-9b1f-bf34e9cf07b5"),
                Content = "DNA/RNA building block",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("3e8b2e89-dce6-4fb6-a0ec-c5828325e27f"),
                Content = "Sugar molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("28779226-97e8-460c-b282-bcaab1343b1e"),
                Content = "Molecule for protein synthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1a77720c-f58f-46f5-95af-48e98439d359"),
                Content = "Fat molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a0ec4070-1ea7-4f17-ac8d-d4afa9143e9d"),
                Content = "Sugar molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8ab8fd6b-8e37-49e7-badc-f9ade960b4ca"),
                Content = "Conversion of sunlight to glucose",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7e074378-84c5-40bf-951f-67530b0a96e2"),
                Content = "Unit of heredity",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("e172ba09-08b3-4cd0-aa8b-99b59d84e3ef"),
                Content = "Nerve cell",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d431f641-f214-4ee0-8436-66b16506563b"),
                Content = "Conversion of sunlight to glucose",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a2b2c735-1213-4501-9e2f-864a66b7842c"),
                Content = "DNA package",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("e7d790e5-f656-4c0f-ae79-a62f772d9a3a"),
                Content = "Site of photosynthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("76a4272d-618c-4879-b08d-0ddf97abc31e"),
                Content = "DNA/RNA building block",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d45e8249-f56d-4f88-bb4e-151a089d3b3b"),
                Content = "Site of photosynthesis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9fc38963-f787-4a13-8cb9-698d99f64ba0"),
                Content = "Structure that contains DNA",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e414195b-48f3-43f8-a9e3-f9708a984cfa"),
                Content = "Change in species over time",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("92a7ec17-f9df-438e-b18f-54c476f6dbdf"),
                Content = "Stable internal conditions",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("6ba6b50e-b539-49b4-b333-8d0c240548ad"),
                Content = "Fat molecule",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1507a7b1-5715-4230-9e0a-804a04295b43"),
                Content = "DNA package",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1f4441c7-f2fc-4645-bcc7-8150acf5bd89"),
                Content = "Unit of heredity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0c3aeb9e-e5d6-4770-8a41-af69d5717462"),
                Content = "Basic unit of life",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("61750d5f-93bc-4b46-bd8f-8f1f1c7326e5"),
                Content = "Change in species over time",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f22613b3-1a42-49e9-9788-34de94c14c13"),
                Content = "Nerve cell",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("2e424274-190b-4186-becb-b015bde8822b"),
                Content = "DNA/RNA building block",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("04ec7920-9c9a-4abd-a3ca-401c5b8a0c5e"),
                Content = "Unit of heredity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("503d5d3f-4ae0-42a4-a693-0a1d779faaa3"),
                Content = "Gap between neurons",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5eabac1b-665c-469e-857c-db3706197357"),
                Content = "Produces ATP",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2d07ff15-8b8e-4a1f-92ac-0229f380f1c7"),
                Content = "Nerve cell",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3d302e3c-5056-4e6c-ad86-bafc729aebfb"),
                Content = "Bonded atoms",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2383ac67-8566-43cb-907c-598fc936d4c7"),
                Content = "Smallest unit of matter",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("59567227-eee2-4a09-8546-4e9e688f9f4a"),
                Content = "Dissolving agent",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f6331202-7d3b-411c-bb75-9d5116d62335"),
                Content = "Dissolved substance",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("299b3c8c-22be-45c3-9fe4-67179a4844a7"),
                Content = "Loss of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e8c0ae44-bae4-418b-9735-05f82b7dd9b3"),
                Content = "Atoms with different neutrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3dd3c6b2-8f41-4b67-91ba-2a711a3d8e9b"),
                Content = "Gain of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("86ff7391-74f3-4126-9ce7-b538a1696366"),
                Content = "Bonded atoms",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("ffd89100-cf7d-4804-a525-fa1ec5495f3c"),
                Content = "Electron transfer",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f71ceb6d-a62b-4a5f-8e6f-474f9b58a3e6"),
                Content = "Charged atom",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("367c5f83-da0e-4d45-a5d9-b9ca46bf2b93"),
                Content = "Product of acid + base",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a7944991-d557-4505-a905-b945d697b180"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7fb7ff30-162d-43d7-8d70-440fcc71b5e9"),
                Content = "Electron sharing",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0af0b364-08c3-4c4b-abd0-7d9409bf784c"),
                Content = "Dissolved substance",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ce88c8b7-6c57-4d62-8087-7b2137c702c5"),
                Content = "Positively charged ion",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("07f1b300-c818-43a8-9de8-ba6af7fc3e82"),
                Content = "Compound of hydrogen & carbon",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4d4b39ce-7216-488e-8f31-cc2a306da793"),
                Content = "Negatively charged ion",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("44c3ad84-1578-4278-bdb2-4fbc82d7288f"),
                Content = "Dissolving agent",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ed1119ae-e7f6-4f09-bd6f-234500bccbf1"),
                Content = "Dissolved substance",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("330ea186-0208-4ed1-aced-48073218f3e2"),
                Content = "Loss of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3ff67ec3-ea45-4b2c-b70a-a2797b89643d"),
                Content = "Homogeneous mixture",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("76fcfa6b-8b2b-4d95-874b-7da19f2e8d06"),
                Content = "Loss of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9b4dcbcb-a29b-4a6c-91ef-708b2802c63c"),
                Content = "Electron sharing",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("ed74f16d-af77-4f82-8406-508c80ae99d7"),
                Content = "Smallest unit of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5a056c35-2334-441b-bc32-79b28aa05af4"),
                Content = "Positively charged ion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("145a4ca8-74a9-4591-adb4-457188971b6c"),
                Content = "Chain of monomers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1bc839c4-944a-45b9-a5b4-8ecccf8125b8"),
                Content = "Electron transfer",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4425853f-eddf-462e-b42f-8b95dfbfbe01"),
                Content = "Negatively charged ion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f0733848-6ac3-49a0-a3cd-94b9e506169b"),
                Content = "Proton donor",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("cc2aa7e2-b05a-4b14-8fb1-ce03e5d21d4d"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("79687b57-4c1b-4dcc-a891-611a84e4fe64"),
                Content = "Loss of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9945da76-c91c-4b01-bc77-8bd0e7a08597"),
                Content = "Moles per liter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8d1446f0-096a-487c-8576-0187ccdcf9d3"),
                Content = "Product of acid + base",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("04016916-bf54-4e66-95bf-019977a90c47"),
                Content = "Proton donor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c4463487-1174-47b1-a358-1de99860604c"),
                Content = "Proton acceptor",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c6a34e15-9e75-455f-947e-2ec7d35185c4"),
                Content = "Gain of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b84f2b45-0372-457a-8c2d-7f5e2f6d1786"),
                Content = "Speeds reaction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0148f365-ae2f-41ce-abd7-c62104afcf77"),
                Content = "Smallest unit of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4435a0ae-572b-4c96-9f05-2fd9e122fc9a"),
                Content = "Negatively charged ion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("401ec0ef-4ec8-438c-901a-abdcb64797e8"),
                Content = "Product of acid + base",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("8c77a02d-ce22-4639-a52a-79ab7f2c5cd2"),
                Content = "Proton donor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("007dbd58-7bc7-4017-89e1-47db5306f3cb"),
                Content = "Dissolving agent",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f5e8bca7-1a42-41ee-b5d5-afb216de2bb5"),
                Content = "Loss of electrons",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("401c8941-44cb-45f6-b1dc-51160cbdcb52"),
                Content = "Negatively charged ion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("63f396d9-4828-460d-87cd-59714bf229b8"),
                Content = "Gain of electrons",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("de07c11c-0ffb-4c05-b74a-ce16276fd985"),
                Content = "Dissolved substance",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("735c9619-b915-43a5-904c-9e0327d92dea"),
                Content = "Smallest unit of matter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a1b93bab-539d-4f0d-b993-284527e6bdc9"),
                Content = "Decomposition by electricity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("cff101f0-80f8-4752-a90d-40f5265c7180"),
                Content = "Compound of hydrogen & carbon",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4f50fd95-bbad-4768-990e-02dd354e8392"),
                Content = "Dissolving agent",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d6a55211-49b2-4430-a25c-94a01f0d0f08"),
                Content = "Atoms with different neutrons",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5ccfb775-902a-4152-bdcd-52ce9239f419"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a4f01ff7-6b16-4de9-a02d-750f0568d5c5"),
                Content = "Speeds reaction",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("0e337e62-f5aa-477f-9b4d-9f858c7c759e"),
                Content = "Decomposition by electricity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("642be73f-da3c-45c7-ab9c-e2208709f3d2"),
                Content = "Dissolving agent",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("50d517be-74f7-4555-ad92-ec5ec49c9f45"),
                Content = "Chain of monomers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a247cf70-c4c1-42f6-a3b6-5b573bf526c2"),
                Content = "Negatively charged ion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3482866e-e3ee-4151-843c-5a13121c7aea"),
                Content = "Homogeneous mixture",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("38e4dcf0-1477-4253-93ee-1c3d2305e13b"),
                Content = "Chain of monomers",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("556d3cbe-696b-474b-86c5-9bc3143a3793"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("10ce8141-1313-423b-9d19-c0de84d460ea"),
                Content = "Decomposition by electricity",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e9aee05d-68f3-41c4-bcad-8dd30e00c020"),
                Content = "Dissolving agent",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("0d70dd06-b087-44af-8318-976289a037a2"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f4d05295-8615-4a80-a2ad-3e16074ee08d"),
                Content = "Atoms with different neutrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b356bfc9-c943-486c-a6f4-b08b39e88d44"),
                Content = "Bonded atoms",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a89d8eef-af6a-4502-a188-532e199ca923"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e127a431-57ba-4eee-a10a-ac9823f07484"),
                Content = "Speeds reaction",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7a4905d8-a222-4b0e-8aa0-cacdbbfdb6e5"),
                Content = "Dissolved substance",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4b95f9cf-f480-4525-9c16-9f3b62283a56"),
                Content = "Moles per liter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5a446c0a-c2a6-45e1-a14c-ac98377cbfc1"),
                Content = "Homogeneous mixture",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("3df0f796-8416-4ab5-8976-d9d284fcd8de"),
                Content = "Proton donor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0f0851e9-f7fd-42b1-b75e-9a0d1133be39"),
                Content = "Atoms with different neutrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ebf1313b-19a8-4b9f-b0cb-d73ca3bc482d"),
                Content = "Gain of electrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1f50f1de-080f-482a-ad55-544e7227ebe6"),
                Content = "Moles per liter",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f1f1ea97-a5c3-4e63-9d0b-d71338eee049"),
                Content = "Proton acceptor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ecc2be3f-ef91-47c3-8eb5-318a8ed0d410"),
                Content = "Proton donor",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("940bacb2-d6e9-4649-b4f0-1cb02adf81e1"),
                Content = "Bonded atoms",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d9e2e601-12b7-4940-b1fd-bf89e18dad28"),
                Content = "Product of acid + base",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3953fd37-fec7-4f21-b923-62380d2469d7"),
                Content = "Decomposition by electricity",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d61a1c85-182f-4e4d-8ea3-7606c1c5ec6c"),
                Content = "Chain of monomers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1472492f-6fbb-417f-bb8b-e2e3624b7830"),
                Content = "Positively charged ion",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a6aa90cb-cd50-41e2-9df0-d9e449aa9254"),
                Content = "Compound of hydrogen & carbon",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("eff6e721-11f7-4194-8ea0-5580864bff8d"),
                Content = "Moles per liter",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fccda024-c94a-4a10-b6b9-b7cb7b7857b2"),
                Content = "Atoms with different neutrons",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0b99c9b6-6710-4321-b084-611c8f97f832"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c4af6a32-c5ea-477c-87b9-ee4baeb93deb"),
                Content = "Cultural revival period",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("16a7ad41-60fd-4fdb-9687-43d9744580a6"),
                Content = "1914–1918 global conflict",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("76ed2d23-d59e-46d5-a036-a5d4944a4542"),
                Content = "Worldwide economic crisis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c9a9eb5a-efd9-40c8-8d4a-c31f987413e1"),
                Content = "Earliest known civilization",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("544688f8-4130-4faa-811a-0dbb6f3557a9"),
                Content = "Eastern Roman Empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f555d3df-41e8-43bc-8d84-13158b6229c9"),
                Content = "1939–1945 global conflict",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9ab49353-a447-4b4d-b49d-571f0790ccf1"),
                Content = "US independence war",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c3c91d29-0d92-473a-932b-7186385284bc"),
                Content = "Ancient Mediterranean empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ef87d184-3d08-4758-9ecc-2596d4620ff7"),
                Content = "Medieval religious wars",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e863e2bb-4fa3-4055-94d9-a8d21f48e476"),
                Content = "US–USSR rivalry",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9b8cc3b7-8c89-4f30-bdbb-76da13f88852"),
                Content = "Nile-based ancient society",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b71e314a-452c-48cd-93b3-1de35cdd047c"),
                Content = "Eastern Roman Empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bafbfb9f-fb00-49ae-871c-043954a2e5ac"),
                Content = "Cultural revival period",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9149d53b-2f28-4dce-8629-e9f4f4d9d668"),
                Content = "1939–1945 global conflict",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1657e23a-014f-4600-bcf5-a204ffb50255"),
                Content = "Medieval religious wars",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8e8c70cf-5d12-4172-9fed-4607159255fb"),
                Content = "Chinese dynasty",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b0cecdd4-da23-41bc-bd2f-8980ca79258e"),
                Content = "Rise of machinery and factories",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("1cb78937-e68d-4300-925f-37159d5fd54b"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2e571636-3d2d-480a-8d5f-c44a3d372535"),
                Content = "Mesoamerican civilization",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6a4c5341-de09-43db-8263-21388905462f"),
                Content = "Medieval religious wars",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9008f9d4-13a7-48cc-98b9-998fe370ba62"),
                Content = "US independence war",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e4ddafb7-b26e-4a37-b4f8-df970a547d80"),
                Content = "1789 uprising",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fd4da661-1e97-4f9e-be33-ab37e8044ee9"),
                Content = "Ancient Mediterranean empire",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("12c6b118-b6cc-4421-a57f-91b34a1dd0ac"),
                Content = "US independence war",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2702df0e-1b93-41f5-9bf9-cae0279a4329"),
                Content = "Classic ancient culture",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("ed15d1cf-c3ea-445d-a7df-9319a441e41f"),
                Content = "Andean civilization",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("26d9bc6a-02d3-4c4a-ac2a-693b817b0ec5"),
                Content = "Rise of machinery and factories",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0adc3e41-74a6-49e9-8857-f4d821660ffd"),
                Content = "Nile-based ancient society",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("df0a10ec-2396-4b58-8168-476697614b98"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("17b1ebb6-0933-438a-84e4-ae35ea55587e"),
                Content = "Rise of machinery and factories",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("effd482a-5ad6-4d00-98a5-a8e75e3bce19"),
                Content = "14th‑century plague",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("655c5a53-2d3b-44f4-b37a-1f40b8182f2b"),
                Content = "1789 uprising",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bad5c395-1497-4e04-8450-1aaef158876b"),
                Content = "Earliest known civilization",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("79ce46d4-371c-4aa0-8920-cf3cd5a3b28d"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b9ff4c43-ff6d-4e61-ad09-228f7557a5d9"),
                Content = "1939–1945 global conflict",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8b2de4b4-74d2-4ce1-84ee-b85ff28c948a"),
                Content = "1789 uprising",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c89bc4ff-32bc-422f-935e-072034b1f693"),
                Content = "US–USSR rivalry",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("70db0fb6-f850-4c84-aeef-47b0d4f4f8cc"),
                Content = "1914–1918 global conflict",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d307a682-86c6-4fd8-814e-8b61c9761cfa"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9de2bb43-5696-4395-b3a0-aff56ff823b4"),
                Content = "Eastern Roman Empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3a55adb3-8dc8-4810-a4eb-03d4159b9d6e"),
                Content = "Cultural revival period",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("97333849-0e20-4dbb-95da-2c7e1bfb5e8d"),
                Content = "1789 uprising",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("476926fd-8824-4e22-8e9e-3fda46248057"),
                Content = "US independence war",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("0c61431f-ca4d-420e-b396-20dcef40080b"),
                Content = "Nile-based ancient society",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("095f77e8-a4b7-4e66-a51d-8613abc8aaaa"),
                Content = "Classic ancient culture",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("11653688-e3ff-4271-af6d-0c65bda916c2"),
                Content = "14th‑century plague",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4964f0ef-0a10-4a32-86a0-f8d925351bf9"),
                Content = "Eastern Roman Empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fa8e6727-d042-4693-9f73-13d74058fd24"),
                Content = "Worldwide economic crisis",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("78ef22ad-7de9-4ca1-ac2c-50232089803d"),
                Content = "Classic ancient culture",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7659532d-a3ac-4228-afad-0cf523359375"),
                Content = "Medieval religious wars",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("62317091-1ef4-44b3-9c3a-70013c092128"),
                Content = "Earliest known civilization",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a04a49a0-7dc6-4e35-977d-8a12959679c4"),
                Content = "Cultural revival period",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4a65b957-3558-4154-ab63-0861b0d71eb9"),
                Content = "Mesoamerican civilization",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f69408c2-f004-4afc-aab8-050bfd1e1d97"),
                Content = "Nile-based ancient society",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("28408242-4da8-46a8-a8da-4c0698268ff5"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1dc96afe-eb6e-4ba0-8ec4-22ecf4a792ab"),
                Content = "US–USSR rivalry",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1eaca297-1c3e-4eb1-867a-04784fe6e1f5"),
                Content = "Medieval religious wars",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("240fa739-d59f-4f5f-9e5d-a10f34a4b32c"),
                Content = "1789 uprising",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("640ee2f0-ead2-4a97-8ab9-62e4402741c0"),
                Content = "Andean civilization",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("e207ac97-dd95-4d3a-883b-1186ee7c0688"),
                Content = "Chinese dynasty",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("55845cd7-0b47-4d3a-ba60-68a05391a33c"),
                Content = "Largest empire in history",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f72317da-0d27-4753-b198-0320f21ee0e7"),
                Content = "1914–1918 global conflict",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("4de97d82-fe76-4dbe-bb13-99570676ff3a"),
                Content = "Cultural revival period",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("daabc3cb-e6bc-41b3-adb6-fd0e5392a6e6"),
                Content = "Nile-based ancient society",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6fac1242-21f6-4e66-8232-79d46aae24fa"),
                Content = "Eastern Roman Empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9705e218-ed49-4d5b-8446-ba07a316f00e"),
                Content = "Norse explorers",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("ef3d4529-104a-45bf-9992-937b1d0daeac"),
                Content = "US–USSR rivalry",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bb7317ec-cd80-4d52-a34e-8756ffb7090a"),
                Content = "Largest empire in history",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a0b0ec80-31ee-4b4c-8db0-db65ee319941"),
                Content = "Cultural revival period",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d1e6a2e2-8235-423a-a0ad-c42b8a90a23e"),
                Content = "Norse explorers",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f760efd6-65dd-422b-96e6-63e793a843da"),
                Content = "Eastern Roman Empire",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("28cf7bf8-5ec3-4592-9d62-d112c3041a27"),
                Content = "Classic ancient culture",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6942ab78-07e2-40c5-8d14-d796771f858a"),
                Content = "Earliest known civilization",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a21d6d6a-0957-4286-bc18-16484d02a659"),
                Content = "US–USSR rivalry",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("cf7e634d-8b58-4d4d-a55f-92805947bfc1"),
                Content = "Chinese dynasty",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("7aaa4599-f433-439d-a1eb-87b365287846"),
                Content = "Classic ancient culture",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("76bfa0cd-f16a-485d-8d8a-9dfb2bde6435"),
                Content = "Worldwide economic crisis",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("bbb909f7-32f4-41db-958c-e1d536832eba"),
                Content = "Eastern Roman Empire",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6d844f9a-7972-4be2-a006-c6219d32b0fb"),
                Content = "1789 uprising",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9a680e0b-d946-45d6-9425-0c1f7f29123f"),
                Content = "Different behavior under same interface",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("bcd0ec54-5df4-4082-a13c-4f2379a9db97"),
                Content = "Instance of a class",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9d1860b3-e737-42f3-9fb4-d507b3156e36"),
                Content = "Stored value",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("17eccf43-eb9d-4581-9db0-011e6b610d2d"),
                Content = "Function calling itself",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9f472623-6404-44c8-b383-5b465ddde269"),
                Content = "Modeling essential features",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1ac408df-6ebe-4932-80d7-19597b91a2b3"),
                Content = "Reusable block of code",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("2096b1d2-01f4-49de-9313-883cfd07ff98"),
                Content = "Interface for communication",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f5fa8f79-00f7-4a9e-beeb-7b10771879a6"),
                Content = "Hiding implementation details",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d4d3ea03-d13f-4ce8-94ca-00badcd17258"),
                Content = "FIFO structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("95fae985-e174-4c7d-9e22-269a416589ba"),
                Content = "Repeated execution",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("6e59a1e5-59ad-4c09-a18d-6a5de82e053b"),
                Content = "Modeling essential features",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("3a48af9d-fc0d-4230-9ff8-af94b8444fe8"),
                Content = "Stepwise procedure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9402c1df-21e5-41df-bb50-b116087f2838"),
                Content = "Indexed collection",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("fe73dafe-e06b-437b-8156-f34ebf0313bd"),
                Content = "FIFO structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("05654328-3437-4805-ad82-0aa2f9d53fda"),
                Content = "Dynamic array",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7b70a701-4d1e-4728-8bcf-f0e4e7403268"),
                Content = "Repeated execution",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("be446a32-917e-4e56-b13a-37f406b36d24"),
                Content = "Hierarchical structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("91a8e4c5-5250-4172-ad78-2c2a7c5e8286"),
                Content = "Dynamic array",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("38b68859-654c-41c7-a918-b0fb88a1a269"),
                Content = "Interface for communication",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("82899387-5425-469e-97dc-4e4628f9c5bb"),
                Content = "Reusable block of code",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("0a864c77-f0ff-4104-a7a4-bf88e3018341"),
                Content = "Reusing parent class traits",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ec84df54-5b02-4d2e-913a-44eb022b41e5"),
                Content = "Repeated execution",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8709f7f7-71cc-4a03-9ebf-772c76a90dbb"),
                Content = "Converts code to machine language",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fe3edd77-ef0b-413c-a72e-389119f73b0c"),
                Content = "Key‑value store",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("c512ed15-70aa-4052-a52c-3a9e289d5f5e"),
                Content = "Template for objects",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("93fbc4d0-26cd-4913-9db2-f92f1cba83a0"),
                Content = "Reusing parent class traits",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f6e505bc-7dec-4aa3-826e-99f051063ef5"),
                Content = "Function calling itself",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6ac8a44b-2f21-46db-8923-812a189d26f9"),
                Content = "Dynamic array",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("20e58bc0-0c1a-429d-8279-b5ca15b67f59"),
                Content = "Converts code to machine language",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("7463401e-704a-428b-9987-f6d2e4cae5c5"),
                Content = "Different behavior under same interface",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("07d87e6e-a9a2-496b-b27d-edc79bb08c21"),
                Content = "Instance of a class",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("a80f0f94-1fa6-4b4a-b72e-ff1271bc1419"),
                Content = "Executes code line by line",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("238a0d22-3988-4271-9246-c7bb9a071f3d"),
                Content = "Dynamic array",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a2d234b2-17f7-4751-a9bc-a10b87d5a4dc"),
                Content = "Interface for communication",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8a11ef6e-3e3a-472c-ab2c-6c6b13b88337"),
                Content = "Reusing parent class traits",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("67cde75c-85f2-422a-a400-7132ee52e2bc"),
                Content = "LIFO structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("550e1666-a69d-4357-baa1-12aed43857a4"),
                Content = "Key‑value store",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("705ec888-384d-4097-9d00-d71bee9dba38"),
                Content = "Different behavior under same interface",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("9a5d0ebd-ec2a-456a-81be-2be0d703ad6c"),
                Content = "Function calling itself",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("742144f5-3f1c-471b-a1a2-3cfb3265a8be"),
                Content = "Indexed collection",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("fd4b3cd1-133c-4ae4-a9a1-4c44ca11e292"),
                Content = "Hierarchical structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2365e607-7ecb-4b9a-a7a0-7c44bf136723"),
                Content = "Indexed collection",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("6ab1d017-b584-433d-9b4a-8b1aa2ad94c5"),
                Content = "Converts code to machine language",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ca1d1662-5c26-4332-9c35-3f7c2369060f"),
                Content = "Hiding implementation details",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("2fe79a9b-e14d-442f-9e6b-d8beb745f1dc"),
                Content = "Hierarchical structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("24de155e-df81-42b2-a4d2-3fc81762c7d7"),
                Content = "Reusable block of code",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("b0641c2f-804f-4b46-94ba-8815bd3c7793"),
                Content = "Executes code line by line",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ca42e568-9ffc-4b43-90a3-9a551ac1bc15"),
                Content = "Modeling essential features",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("8906aac2-afda-4e58-b8d6-9a60861307f6"),
                Content = "Reusing parent class traits",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("1236bcc9-37fe-4562-b37b-c1b8b434afb2"),
                Content = "FIFO structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8964655a-a986-4c09-8a01-f901d840808c"),
                Content = "Repeated execution",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e7cf4128-c257-4401-8152-45818bce4a4f"),
                Content = "Stepwise procedure",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("f5d9797f-476f-4707-a1ae-9e0500135ff0"),
                Content = "FIFO structure",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("5d3ede77-6910-4f1f-a164-c6c5c1a057fb"),
                Content = "Stored value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("c296783a-a791-4c90-b0f3-ebe2edaa209d"),
                Content = "Modeling essential features",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("48cf782a-74da-46af-98b7-af1c27681f04"),
                Content = "Reusable block of code",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e906640e-45db-47a5-8451-77753f1e482b"),
                Content = "Indexed collection",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("8ac37218-b223-4b99-9fed-52dcb0538b91"),
                Content = "Key‑value store",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a4b0d8c9-db18-45b8-9c35-bace3ce7f99d"),
                Content = "LIFO structure",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("d24be42e-9241-49a6-a9f8-120a39876908"),
                Content = "Executes code line by line",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("2eb8c19a-3c1d-457e-90bb-0bf0b85d981f"),
                Content = "Modeling essential features",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("e1c33767-1369-4ee4-b9fa-8bfad866bf9f"),
                Content = "Key‑value store",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("313530a4-d528-4a63-9959-69aaddcdbcba"),
                Content = "Converts code to machine language",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("27edb530-1098-4b91-851e-baa7013e8f84"),
                Content = "Hierarchical structure",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4d7f2748-aaca-4c24-8357-f47ed6e84f96"),
                Content = "Stored value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ccc92f4a-213c-46c4-a361-2268673d63fe"),
                Content = "Function calling itself",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("4f47b5d9-a014-41f5-b2f5-8e4be4f3f1d9"),
                Content = "Hierarchical structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("a96c3126-fba7-4be9-b554-c34d5731d150"),
                Content = "Repeated execution",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("06d2bfa4-f9eb-4247-bfca-05337f3d0b5f"),
                Content = "Stored value",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("ccfbf1f1-834d-4f19-8335-412ab5216c82"),
                Content = "Hiding implementation details",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("9af23a15-d250-4a1c-be6a-f6d2c3fe97af"),
                Content = "Template for objects",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("643fc27c-bc75-4950-b677-52a56b538687"),
                Content = "Converts code to machine language",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("bf966680-7e38-4c68-aff9-6d983b6138e9"),
                Content = "Modeling essential features",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("f3927d0b-0876-4f3b-b79a-640a89b58611"),
                Content = "LIFO structure",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("d7b7fc6f-9078-447b-9ad2-95de352c2680"),
                Content = "Executes code line by line",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("ee69561d-1be8-4594-b673-c6652ce09a0e"),
                Content = "Reusable block of code",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("38001485-6552-4c1f-b173-99a24fd38b70"),
                Content = "Reusing parent class traits",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("409e47f8-c644-4ca6-b267-d042ea5f6f1a"),
                Content = "Instance of a class",
                IsCorrect = false
            },
            new
            {
                Id = Guid.Parse("5cc505d1-9cb0-462d-8913-2c5472173271"),
                Content = "Interface for communication",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("462c3fbf-d9ca-4ef7-8af1-8bef8c195cfd"),
                Content = "Reusable block of code",
                IsCorrect = false
            }
        );
    }
}