using e_learning_backend.Domain.Users.ValueObjects;

namespace e_learning_backend_tests.ExercisesAndMaterials;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users;
using System.Linq;

[TestClass]
public class TagTests
    {
        private User CreateTestTeacher()
        {
            return new User("John", "Smith", "sample@mail.com", 
                "password", "123-456-789", Role.Teacher);
        }

        private FileResource CreateTestFile()
        {
            return new FileResource("Sample file", "/path/to/file.txt", DateTime.Now,
                CreateTestTeacher());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullName_ThrowsException()
        {
            // Arrange
            var teacher = CreateTestTeacher();

            // Act
            var tag = new Tag(null, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullTeacher_ThrowsException()
        {
            // Arrange
            var tag = new Tag("Science", null);
        }
        
        [TestMethod]
        public void Constructor_ShouldSetTeacherAndTeacherId()
        {
            var teacher = CreateTestTeacher();
            
            // Act
            var tag = new Tag(Guid.NewGuid(), "TestTag", teacher);

            // Assert
            Assert.AreEqual(teacher, tag.Teacher);
            Assert.AreEqual(teacher.Id, tag.TeacherId);
        }

        [TestMethod]
        public void AddFileToTagged_AddsFileCorrectly()
        {
            // Arrange
            var tag = new Tag("Physics", CreateTestTeacher());
            var file = CreateTestFile();

            // Act
            tag.AddFileToTagged(file);

            // Assert
            Assert.AreEqual(1, tag.Files.Count);
            Assert.IsTrue(tag.Files.Contains(file));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddFileToTagged_WithNull_ThrowsException()
        {
            // Arrange
            var tag = new Tag("History", CreateTestTeacher());

            // Act
            tag.AddFileToTagged(null);
        }

        [TestMethod]
        public void RemoveFileFromTagged_RemovesFileCorrectly()
        {
            // Arrange
            var tag = new Tag("Biology", CreateTestTeacher());
            var file = CreateTestFile();
            tag.AddFileToTagged(file);

            // Act
            tag.RemoveFileFromTagged(file);

            // Assert
            Assert.AreEqual(0, tag.Files.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveFileFromTagged_WithNull_ThrowsException()
        {
            // Arrange
            var tag = new Tag("Chemistry", CreateTestTeacher());

            // Act
            tag.RemoveFileFromTagged(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFileFromTagged_NotInSet_ThrowsException()
        {
            // Arrange
            var tag = new Tag("Physics", CreateTestTeacher());
            var file = CreateTestFile();

            // Act
            tag.RemoveFileFromTagged(file);
        }

        [TestMethod]
        public void Files_AreReadOnlyCollection()
        {
            // Arrange
            var tag = new Tag("Geography", CreateTestTeacher());

            // Act & Assert
            Assert.IsInstanceOfType(tag.Files, typeof(IReadOnlyCollection<FileResource>));
        }

        [TestMethod]
        public void Constructor_WithoutTeacher_SetsNameOnly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "TagWithoutTeacher";

            // Act
            var tag = new Tag(id, name);

            // Assert
            Assert.AreEqual(id, tag.Id);
            Assert.AreEqual(name, tag.Name);
            Assert.IsNull(tag.Teacher);
            Assert.IsNull(tag.TeacherId);
        }
        
        [TestMethod]
        public void AddingTagToTeacher_ShouldContainTagInTeacherTagsCollection()
        {
            // Arrange
            var teacher = CreateTestTeacher();
            var tag = new Tag("SampleTag", teacher);

            // Act
            teacher.AddTag(tag);

            // Assert
            Assert.IsTrue(teacher.Tags.Contains(tag));
        }
    }