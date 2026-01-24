namespace e_learning_backend_tests.ExercisesAndMaterials;

using e_learning_backend.Domain.Users.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;

[TestClass]
public class ExerciseResourceTests
{
    private User _testUser;
    private Class _testClass;
    private Exercise _testExercise;
    private FileResource _testFile;

    [TestInitialize]
    public void Setup()
    {
        _testUser = new User(
            Guid.NewGuid(),
            "File",
            "Owner",
            "file.owner@example.com",
            "hashedpass",
            "111222333",
            Role.Student
        );

        _testClass = new Class(DateTime.Now.AddDays(1));
        _testExercise = new Exercise(Guid.NewGuid(), "Solve equation X+Y=Z", _testClass);
        _testFile = new FileResource(Guid.NewGuid(), "ProblemSet1.pdf", "/uploads/problems.pdf", DateTime.UtcNow, _testUser);
    }

    [TestMethod]
    public void Constructor_InitializesCorrectlyAndLinksBothWays()
    {
        // Arrange
        var resourceType = ExerciseResourceType.Content;

        // Act
        var exerciseResource = new ExerciseResource(_testExercise, _testFile, resourceType);

        // Assert
        Assert.AreEqual(_testExercise, exerciseResource.Exercise);
        Assert.AreEqual(_testExercise.Id, exerciseResource.ExerciseId);
        Assert.AreEqual(_testFile, exerciseResource.File);
        Assert.AreEqual(_testFile.Id, exerciseResource.FileId);
        Assert.AreEqual(resourceType, exerciseResource.Type);

        // Check if ExerciseResource was added to Exercise's collection
        Assert.AreEqual(1, _testExercise.ExerciseResources.Count);
        Assert.IsTrue(_testExercise.ExerciseResources.Contains(exerciseResource));

        // Check if ExerciseResource was added to FileResource's collection
        Assert.AreEqual(1, _testFile.ExerciseResources.Count);
        Assert.IsTrue(_testFile.ExerciseResources.Contains(exerciseResource));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_WithNullExercise_ThrowsArgumentNullException()
    {
        // Arrange
        var resourceType = ExerciseResourceType.Content;

        // Act & Assert
        new ExerciseResource(null, _testFile, resourceType);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_WithNullFile_ThrowsArgumentNullException()
    {
        // Arrange
        var resourceType = ExerciseResourceType.Content;

        // Act & Assert
        new ExerciseResource(_testExercise, null, resourceType);
    }
    
    [TestMethod]
    public void AddingMultipleExerciseResourcesToSameExercise_LinksCorrectly()
    {
        // Arrange
        var file1 = new FileResource("File1.doc", "/path/file1.doc", DateTime.UtcNow, _testUser);
        var file2 = new FileResource("File2.pdf", "/path/file2.pdf", DateTime.UtcNow, _testUser);

        // Act
        var er1 = new ExerciseResource(_testExercise, file1, ExerciseResourceType.Content);
        var er2 = new ExerciseResource(_testExercise, file2, ExerciseResourceType.Solution);

        // Assert
        Assert.AreEqual(2, _testExercise.ExerciseResources.Count);
        Assert.IsTrue(_testExercise.ExerciseResources.Contains(er1));
        Assert.IsTrue(_testExercise.ExerciseResources.Contains(er2));

        Assert.AreEqual(1, file1.ExerciseResources.Count);
        Assert.IsTrue(file1.ExerciseResources.Contains(er1));
        Assert.AreEqual(1, file2.ExerciseResources.Count);
        Assert.IsTrue(file2.ExerciseResources.Contains(er2));
    }
    
    [TestMethod]
    public void AddingMultipleExerciseResourcesWithSameFileButDifferentExercises_LinksCorrectly()
    {
        // Arrange
        var exercise1 = new Exercise(Guid.NewGuid(), "Exercise A", _testClass);
        var exercise2 = new Exercise(Guid.NewGuid(), "Exercise B", _testClass);
        var sharedFile = new FileResource("Shared.pdf", "/path/shared.pdf", DateTime.UtcNow, _testUser);

        // Act
        var er1 = new ExerciseResource(exercise1, sharedFile, ExerciseResourceType.Content);
        var er2 = new ExerciseResource(exercise2, sharedFile, ExerciseResourceType.Solution);

        // Assert
        Assert.AreEqual(1, exercise1.ExerciseResources.Count);
        Assert.IsTrue(exercise1.ExerciseResources.Contains(er1));
        
        Assert.AreEqual(1, exercise2.ExerciseResources.Count);
        Assert.IsTrue(exercise2.ExerciseResources.Contains(er2));

        Assert.AreEqual(2, sharedFile.ExerciseResources.Count);
        Assert.IsTrue(sharedFile.ExerciseResources.Contains(er1));
        Assert.IsTrue(sharedFile.ExerciseResources.Contains(er2));
    }
}