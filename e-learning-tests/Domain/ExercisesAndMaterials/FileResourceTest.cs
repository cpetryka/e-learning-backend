using e_learning_backend.Domain.Users.ValueObjects;

namespace e_learning_backend_tests.ExercisesAndMaterials;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.ExercisesAndMaterials;

[TestClass]
public class FileResourceTests
{
    private User _testStudentUser;
    private User _testTeacherUser;

    [TestInitialize]
    public void Setup()
    {
        _testStudentUser = new User(
            Guid.NewGuid(),
            "Student",
            "User",
            "student.user@example.com",
            "hashedpassword123",
            "987654321",
            Role.Student
        );

        _testTeacherUser = new User(
            Guid.NewGuid(),
            "Teacher",
            "User",
            "teacher.user@example.com",
            "123hashedpassword",
            "112233445",
            Role.Teacher
        );
    }

    [TestMethod]
    public void Constructor_WithGuidAndUser_InitializesCorrectly()
    {
        // Arrange
        var fileId = Guid.NewGuid();
        var fileName = "TestFile.pdf";
        var filePath = "/uploads/TestFile.pdf";
        var addedAt = DateTime.UtcNow;

        // Act
        var fileResource = new FileResource(fileId, fileName, filePath, addedAt, _testStudentUser);

        // Assert
        Assert.AreEqual(fileId, fileResource.Id);
        Assert.AreEqual(fileName, fileResource.Name);
        Assert.AreEqual(filePath, fileResource.Path);
        Assert.AreEqual(addedAt, fileResource.AddedAt);
        Assert.AreEqual(_testStudentUser, fileResource.User);
        Assert.AreEqual(_testStudentUser.Id, fileResource.UserId);
        Assert.IsNotNull(fileResource.ExerciseResources);
        Assert.IsFalse(fileResource.ExerciseResources.Any());
        Assert.IsNotNull(fileResource.Tags);
        Assert.IsFalse(fileResource.Tags.Any());
        Assert.IsTrue(_testStudentUser.Files.Contains(fileResource));
    }

    [TestMethod]
    public void Constructor_WithoutGuid_GeneratesNewGuidAndInitializesCorrectly()
    {
        // Arrange
        var fileName = "AnotherTestFile.docx";
        var filePath = "/uploads/AnotherTestFile.docx";
        var addedAt = DateTime.UtcNow;

        // Act
        var fileResource = new FileResource(fileName, filePath, addedAt, _testStudentUser);

        // Assert
        Assert.AreNotEqual(Guid.Empty, fileResource.Id);
        Assert.AreEqual(fileName, fileResource.Name);
        Assert.AreEqual(filePath, fileResource.Path);
        Assert.AreEqual(addedAt, fileResource.AddedAt);
        Assert.AreEqual(_testStudentUser, fileResource.User);
        Assert.AreEqual(_testStudentUser.Id, fileResource.UserId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_WithNullUser_ThrowsArgumentNullException()
    {
        // Arrange
        var fileName = "InvalidFile.txt";
        var filePath = "/uploads/InvalidFile.txt";
        var addedAt = DateTime.UtcNow;

        // Act & Assert
        new FileResource(fileName, filePath, addedAt, null);
    }

    [TestMethod]
    public void AddTag_AddsTagToCollectionAndLinksBothWays()
    {
        // Arrange
        var fileResource = new FileResource("File.jpg", "/path/file.jpg", DateTime.UtcNow, _testStudentUser);
        var tag1 = new Tag("Photography", _testTeacherUser); 

        // Act
        fileResource.AddTag(tag1);

        // Assert
        Assert.AreEqual(1, fileResource.Tags.Count);
        Assert.IsTrue(fileResource.Tags.Contains(tag1));
        Assert.AreEqual(1, tag1.Files.Count);
        Assert.IsTrue(tag1.Files.Contains(fileResource));
    }

    [TestMethod]
    public void AddTag_AddingMultipleTags_AddsAllToCollectionAndLinksBothWays()
    {
        // Arrange
        var fileResource = new FileResource("Document.pdf", "/path/doc.pdf", DateTime.UtcNow, _testStudentUser);
        var tag1 = new Tag("Work", _testTeacherUser);
        var tag2 = new Tag("Important", _testTeacherUser);

        // Act
        fileResource.AddTag(tag1);
        fileResource.AddTag(tag2);

        // Assert
        Assert.AreEqual(2, fileResource.Tags.Count);
        Assert.IsTrue(fileResource.Tags.Contains(tag1));
        Assert.IsTrue(fileResource.Tags.Contains(tag2));

        Assert.AreEqual(1, tag1.Files.Count);
        Assert.IsTrue(tag1.Files.Contains(fileResource));

        Assert.AreEqual(1, tag2.Files.Count);
        Assert.IsTrue(tag2.Files.Contains(fileResource));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddTag_WithNullTag_ThrowsArgumentNullException()
    {
        // Arrange
        var fileResource = new FileResource("File.mp4", "/path/video.mp4", DateTime.UtcNow, _testStudentUser);

        // Act & Assert
        fileResource.AddTag(null);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddTag_AddingExistingTag_ThrowsInvalidOperationException()
    {
        // Arrange
        var fileResource = new FileResource("Dupe.png", "/path/dupe.png", DateTime.UtcNow, _testStudentUser);
        var tag1 = new Tag("Duplicate", _testTeacherUser);

        // Act
        fileResource.AddTag(tag1);
        fileResource.AddTag(tag1);
    }

    [TestMethod]
    public void RemoveTag_RemovesTagFromCollectionAndUnlinksBothWays()
    {
        // Arrange
        var fileResource = new FileResource("Report.xlsx", "/path/report.xlsx", DateTime.UtcNow, _testStudentUser);
        var tag1 = new Tag("Finance", _testTeacherUser);
        fileResource.AddTag(tag1);

        // Assert initial state
        Assert.IsTrue(fileResource.Tags.Contains(tag1));
        Assert.IsTrue(tag1.Files.Contains(fileResource));

        // Act
        fileResource.RemoveTag(tag1);

        // Assert
        Assert.IsFalse(fileResource.Tags.Any());
        Assert.IsFalse(fileResource.Tags.Contains(tag1));
        Assert.IsFalse(tag1.Files.Any());
        Assert.IsFalse(tag1.Files.Contains(fileResource));
    }

    [TestMethod]
    public void RemoveTag_RemovingOneOfMultipleTags_RemovesOnlySpecifiedTag()
    {
        // Arrange
        var fileResource = new FileResource("Article.txt", "/path/article.txt", DateTime.UtcNow, _testStudentUser);
        var tag1 = new Tag("Science", _testTeacherUser);
        var tag2 = new Tag("Research", _testTeacherUser);
        fileResource.AddTag(tag1);
        fileResource.AddTag(tag2);

        // Assert initial state
        Assert.AreEqual(2, fileResource.Tags.Count);
        Assert.IsTrue(fileResource.Tags.Contains(tag1));
        Assert.IsTrue(fileResource.Tags.Contains(tag2));
        Assert.IsTrue(tag1.Files.Contains(fileResource));
        Assert.IsTrue(tag2.Files.Contains(fileResource));

        // Act
        fileResource.RemoveTag(tag1);

        // Assert
        Assert.AreEqual(1, fileResource.Tags.Count);
        Assert.IsFalse(fileResource.Tags.Contains(tag1));
        Assert.IsTrue(fileResource.Tags.Contains(tag2));

        Assert.IsFalse(tag1.Files.Any());
        Assert.IsTrue(tag2.Files.Contains(fileResource));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void RemoveTag_WithNullTag_ThrowsArgumentNullException()
    {
        // Arrange
        var fileResource = new FileResource("Temp.log", "/path/temp.log", DateTime.UtcNow, _testStudentUser);

        // Act & Assert
        fileResource.RemoveTag(null);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void RemoveTag_RemovingNonExistingTag_ThrowsInvalidOperationException()
    {
        // Arrange
        var fileResource = new FileResource("NoTag.zip", "/path/notag.zip", DateTime.UtcNow, _testStudentUser);
        var tag1 = new Tag("NonExistent", _testTeacherUser);

        // Act & Assert
        fileResource.RemoveTag(tag1);
    }
}