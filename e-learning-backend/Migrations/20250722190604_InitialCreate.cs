using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_learning_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StarsNumber = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AboutMe = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    RefreshToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => new { x.QuestionId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedUsers",
                columns: table => new
                {
                    BlockingUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockedUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => new { x.BlockingUserId, x.BlockedUserId });
                    table.ForeignKey(
                        name: "FK_BlockedUsers_Users_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_Users_BlockingUserId",
                        column: x => x.BlockingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Path = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileResources_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionCategories_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherQuestionAccesses",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherQuestionAccesses", x => new { x.TeacherId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_TeacherQuestionAccesses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherQuestionAccesses_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleName });
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSpectators",
                columns: table => new
                {
                    SpectatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpectatorUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSpectators", x => new { x.SpectatedUserId, x.SpectatorUserId });
                    table.ForeignKey(
                        name: "FK_UserSpectators_Users_SpectatedUserId",
                        column: x => x.SpectatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSpectators_Users_SpectatorUserId",
                        column: x => x.SpectatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvailabilityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseLanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseVariants_CourseLanguages_CourseLanguageId",
                        column: x => x.CourseLanguageId,
                        principalTable: "CourseLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseVariants_CourseLevels_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseVariants_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: true),
                    Notifications = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Participations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategoryAssignments",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionCategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategoryAssignments", x => new { x.QuestionId, x.QuestionCategoryId });
                    table.ForeignKey(
                        name: "FK_QuestionCategoryAssignments_QuestionCategories_QuestionCate~",
                        column: x => x.QuestionCategoryId,
                        principalTable: "QuestionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionCategoryAssignments_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagFiles",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileResourceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagFiles", x => new { x.TagId, x.FileResourceId });
                    table.ForeignKey(
                        name: "FK_TagFiles_FileResources_FileResourceId",
                        column: x => x.FileResourceId,
                        principalTable: "FileResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagFiles_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    LinkToMeeting = table.Column<string>(type: "text", nullable: true),
                    ClassStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_ClassStatuses_ClassStatusId",
                        column: x => x.ClassStatusId,
                        principalTable: "ClassStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Participations_UserId_CourseId",
                        columns: x => new { x.UserId, x.CourseId },
                        principalTable: "Participations",
                        principalColumns: new[] { "UserId", "CourseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFileResources",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileResourceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFileResources", x => new { x.ClassId, x.FileResourceId });
                    table.ForeignKey(
                        name: "FK_ClassFileResources_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassFileResources_FileResources_FileResourceId",
                        column: x => x.FileResourceId,
                        principalTable: "FileResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Instruction = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Grade = table.Column<double>(type: "double precision", precision: 3, scale: 2, nullable: true),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: true),
                    MultipleChoice = table.Column<bool>(type: "boolean", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseResources",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseResources", x => new { x.ExerciseId, x.FileId });
                    table.ForeignKey(
                        name: "FK_ExerciseResources_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseResources_FileResources_FileId",
                        column: x => x.FileId,
                        principalTable: "FileResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => new { x.QuizId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "IsCorrect" },
                values: new object[,]
                {
                    { new Guid("20000000-0033-0000-0000-000000000001"), "4", true },
                    { new Guid("20000000-0033-0000-0000-000000000002"), "5", false }
                });

            migrationBuilder.InsertData(
                table: "ClassStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { new Guid("41111111-1111-1111-1111-111111111111"), "Scheduled" },
                    { new Guid("42222222-2222-2222-2222-222222222222"), "Done" }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("92625ae5-da0e-48ce-ac3f-79f9be35caa4"), "Programming" });

            migrationBuilder.InsertData(
                table: "CourseLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3e118082-c17c-4a4c-945a-1a88733c2e28"), "English" });

            migrationBuilder.InsertData(
                table: "CourseLevels",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1dcb1002-ec77-49ea-8f21-56e0caac0824"), "Beginner" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content" },
                values: new object[] { new Guid("10000000-0000-0000-0002-000000000001"), "What is 2 + 2?" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "StarsNumber" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "Świetny kurs!", 5 });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { new Guid("aaaaaaa3-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Chemia", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "Email", "HashedPassword", "Name", "Phone", "RefreshToken", "RefreshTokenExpiryTime", "Surname" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Passionate about teaching mathematics.", "alice.johnson@example.com", "$2a$12$abcdefghijklmnopqrstuu4CCWBIT4hflhcfUk9bNoatbvS5.d4pe", "Alice", "+1-202-555-0101", null, null, "Johnson" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "john.doe@example.com", "$2a$12$abcdefghijklmnopqrstuujMFUXAM4k/lY17vfDwnx7yNLJqx5wXW", "John", "+1-202-555-0102", null, null, "Doe" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "jane.doe@example.com", "$2a$12$abcdefghijklmnopqrstuuKbr1cYNTcpTfIrQbyKoc7w9QqzPY9QC", "Jane", "+1-202-555-0103", null, null, "Doe" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Enjoys following courses as a spectator.", "michael.brown@example.com", "$2a$12$abcdefghijklmnopqrstuuQWvbKyvRYSwa0yXIU1Metx2nqgPWowS", "Michael", "+1-202-555-0104", null, null, "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Id", "Date", "TeacherId" },
                values: new object[] { new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "BlockedUsers",
                columns: new[] { "BlockedUserId", "BlockingUserId" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "TeacherId" },
                values: new object[] { new Guid("0042b980-d8cc-4969-af0f-62d8c1632871"), new Guid("92625ae5-da0e-48ce-ac3f-79f9be35caa4"), "Learn the basics of C# programming.", "C# Basics", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "FileResources",
                columns: new[] { "Id", "AddedAt", "Name", "Path", "UserId" },
                values: new object[] { new Guid("ff555555-5555-5555-5555-555555555555"), new DateTime(2025, 7, 11, 10, 0, 0, 0, DateTimeKind.Utc), "example.pdf", "/uploads/example.pdf", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "AnswerId", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("20000000-0033-0000-0000-000000000001"), new Guid("10000000-0000-0000-0002-000000000001") },
                    { new Guid("20000000-0033-0000-0000-000000000002"), new Guid("10000000-0000-0000-0002-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "Description", "Name", "TeacherId" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000001"), "Basic math questions", "Math", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Matematyka", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Fizyka", new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "TeacherQuestionAccesses",
                columns: new[] { "QuestionId", "TeacherId", "Created" },
                values: new object[] { new Guid("10000000-0000-0000-0002-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), true });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleName", "UserId" },
                values: new object[,]
                {
                    { "teacher", new Guid("11111111-1111-1111-1111-111111111111") },
                    { "student", new Guid("22222222-2222-2222-2222-222222222222") },
                    { "student", new Guid("33333333-3333-3333-3333-333333333333") },
                    { "spectator", new Guid("44444444-4444-4444-4444-444444444444") },
                    { "student", new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.InsertData(
                table: "UserSpectators",
                columns: new[] { "SpectatedUserId", "SpectatorUserId" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.InsertData(
                table: "CourseVariants",
                columns: new[] { "Id", "CourseId", "CourseLanguageId", "CourseLevelId" },
                values: new object[] { new Guid("4f0da3ec-6a56-4705-b691-8890b67d24b1"), new Guid("0042b980-d8cc-4969-af0f-62d8c1632871"), new Guid("3e118082-c17c-4a4c-945a-1a88733c2e28"), new Guid("1dcb1002-ec77-49ea-8f21-56e0caac0824") });

            migrationBuilder.InsertData(
                table: "Participations",
                columns: new[] { "CourseId", "UserId", "Notifications", "ReviewId" },
                values: new object[,]
                {
                    { new Guid("0042b980-d8cc-4969-af0f-62d8c1632871"), new Guid("22222222-2222-2222-2222-222222222222"), false, null },
                    { new Guid("0042b980-d8cc-4969-af0f-62d8c1632871"), new Guid("33333333-3333-3333-3333-333333333333"), true, null }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategoryAssignments",
                columns: new[] { "QuestionCategoryId", "QuestionId" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000001"), new Guid("10000000-0000-0000-0002-000000000001") });

            migrationBuilder.InsertData(
                table: "TagFiles",
                columns: new[] { "FileResourceId", "TagId" },
                values: new object[] { new Guid("ff555555-5555-5555-5555-555555555555"), new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "AvailabilityId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { new Guid("f2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 15, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 7, 15, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 15, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 7, 15, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassStatusId", "Comment", "CourseId", "LinkToMeeting", "StartTime", "UserId" },
                values: new object[] { new Guid("43333333-3333-3333-3333-333333333333"), new Guid("41111111-1111-1111-1111-111111111111"), "Introductory session", new Guid("0042b980-d8cc-4969-af0f-62d8c1632871"), "https://example.com/meeting", new DateTime(2025, 5, 8, 19, 24, 25, 619, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                table: "ClassFileResources",
                columns: new[] { "ClassId", "FileResourceId" },
                values: new object[] { new Guid("43333333-3333-3333-3333-333333333333"), new Guid("ff555555-5555-5555-5555-555555555555") });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "ClassId", "Comment", "Grade", "Instruction", "Status" },
                values: new object[] { new Guid("ee111111-1111-1111-1111-111111111111"), new Guid("43333333-3333-3333-3333-333333333333"), "Good job on the assignment!", 4.5, "Complete the assignment on OOP concepts.", "Graded" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "ClassId", "MultipleChoice", "Score" },
                values: new object[] { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("43333333-3333-3333-3333-333333333333"), true, null });

            migrationBuilder.InsertData(
                table: "ExerciseResources",
                columns: new[] { "ExerciseId", "FileId", "Type" },
                values: new object[] { new Guid("ee111111-1111-1111-1111-111111111111"), new Guid("ff555555-5555-5555-5555-555555555555"), "Content" });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "QuestionId", "QuizId" },
                values: new object[] { new Guid("10000000-0000-0000-0002-000000000001"), new Guid("40000000-0000-0000-0000-000000000001") });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_TeacherId",
                table: "Availabilities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_BlockedUserId",
                table: "BlockedUsers",
                column: "BlockedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassStatusId",
                table: "Classes",
                column: "ClassStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UserId_CourseId",
                table: "Classes",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassFileResources_FileResourceId",
                table: "ClassFileResources",
                column: "FileResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVariants_CourseId",
                table: "CourseVariants",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVariants_CourseLanguageId",
                table: "CourseVariants",
                column: "CourseLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseVariants_CourseLevelId",
                table: "CourseVariants",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseResources_FileId",
                table: "ExerciseResources",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ClassId",
                table: "Exercises",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FileResources_UserId",
                table: "FileResources",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_CourseId",
                table: "Participations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_ReviewId",
                table: "Participations",
                column: "ReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_AnswerId",
                table: "QuestionAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCategories_TeacherId",
                table: "QuestionCategories",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionCategoryAssignments_QuestionCategoryId",
                table: "QuestionCategoryAssignments",
                column: "QuestionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionId",
                table: "QuizQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ClassId",
                table: "Quizzes",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TagFiles_FileResourceId",
                table: "TagFiles",
                column: "FileResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TeacherId",
                table: "Tags",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherQuestionAccesses_QuestionId",
                table: "TeacherQuestionAccesses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_AvailabilityId",
                table: "TimeSlots",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSpectators_SpectatorUserId",
                table: "UserSpectators",
                column: "SpectatorUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedUsers");

            migrationBuilder.DropTable(
                name: "ClassFileResources");

            migrationBuilder.DropTable(
                name: "CourseVariants");

            migrationBuilder.DropTable(
                name: "ExerciseResources");

            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuestionCategoryAssignments");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "TagFiles");

            migrationBuilder.DropTable(
                name: "TeacherQuestionAccesses");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSpectators");

            migrationBuilder.DropTable(
                name: "CourseLanguages");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionCategories");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "FileResources");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "ClassStatuses");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
