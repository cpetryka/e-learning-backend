using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Domain.Participations;
using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public string Phone { get; private set; }
    public string? AboutMe { get; private set; }
    
    public ProfilePicture? ProfilePicture { get; private set; }

    // Used to differentiate between a teacher, a student, etc.
    private readonly HashSet<Role> _roles = new();
    public IReadOnlyCollection<Role> Roles => _roles;
    
    // Blocking other users
    private readonly HashSet<User> _blockedUsers = new();
    public IReadOnlyCollection<User> BlockedUsers => _blockedUsers;
    
    private readonly HashSet<User> _blockedByUsers = new();
    public IReadOnlyCollection<User> BlockedByUsers => _blockedByUsers;
    
    // Used for authentication
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    
    // Files
    private readonly HashSet<FileResource> _files = new();
    public IReadOnlyCollection<FileResource> Files => _files;
    
    // Teacher only
    private readonly HashSet<Course> _conductedCourses = new();
    public IReadOnlyCollection<Course> ConductedCourses => _conductedCourses;
    
    private readonly HashSet<Availability> _availability = new();
    public IReadOnlyCollection<Availability> Availability => _availability;
    
    private readonly HashSet<Tag> _tags = new();
    public IReadOnlyCollection<Tag> Tags => _tags;
    
    private readonly HashSet<QuestionCategory> _questionCategories = new();
    public IReadOnlyCollection<QuestionCategory> QuestionCategories => _questionCategories;
    
    private readonly HashSet<TeacherQuestionAccess> _teacherQuestionAccesses = new();
    public IReadOnlyCollection<TeacherQuestionAccess> TeacherQuestionAccesses => _teacherQuestionAccesses;
    
    // Spectator only
    private readonly HashSet<User> _spectates = new();
    public IReadOnlyCollection<User> Spectates => _spectates;
    
    // Student only
    private readonly HashSet<Participation> _participations = new();
    public IReadOnlyCollection<Participation> Participations => _participations;
    
    private readonly HashSet<User> _spectatedBy = new();
    public IReadOnlyCollection<User> SpectatedBy => _spectatedBy;

    private User() { }

    public User(
        Guid id,
        string name,
        string surname,
        string email,
        string hashedPassword,
        string phone,
        Role initialRole,
        string? aboutMe = "")
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentException("Surname cannot be empty.", nameof(surname));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(hashedPassword))
        {
            throw new ArgumentException("Password cannot be empty.", nameof(hashedPassword));
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Phone number cannot be empty.", nameof(phone));
        }

        if (initialRole is null)
        {
            throw new ArgumentNullException(nameof(initialRole));
        }

        // The role at the time of creation must be either Student or Teacher
        if (!initialRole.Equals(Role.Student) && !initialRole.Equals(Role.Teacher))
        {
            throw new InvalidOperationException("Initial role must be either student or teacher.");
        }

        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        HashedPassword = hashedPassword;
        Phone = phone;
        AboutMe = aboutMe;

        _roles.Add(initialRole);
    }

    public User(
        string name,
        string surname,
        string email,
        string hashedPassword,
        string phone,
        Role initialRole,
        string? aboutMe = null)
        : this(Guid.NewGuid(), name, surname, email, hashedPassword, phone, initialRole, aboutMe) { }

    /// <summary>
    ///     Used to add a new role to the user.
    /// </summary>
    /// <param name="role">The role to be added. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown when the provided role is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the user already has the provided role.</exception>
    public void AddRole(Role role)
    {
        if (role is null)
        {
            throw new ArgumentNullException(nameof(role));
        }

        if (_roles.Contains(role))
        {
            throw new InvalidOperationException($"User already has role '{role}'.");
        }

        _roles.Add(role);
    }

    /// <summary>
    ///     Used to remove an existing role from the user.
    /// </summary>
    /// <param name="role">The role to be removed. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the provided role is null.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the user does not have the provided role.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when attempting to remove the last remaining role, as a user must have at least one role.
    /// </exception>
    public void RemoveRole(Role role)
    {
        if (role is null)
        {
            throw new ArgumentNullException(nameof(role));
        }

        if (!_roles.Contains(role))
        {
            throw new InvalidOperationException($"User does not have role '{role}'.");
        }

        if (_roles.Count == 1)
        {
            throw new InvalidOperationException("User must have at least one role.");
        }

        _roles.Remove(role);
    }
    
    /// <summary>
    ///     Adds a course to the collection of courses conducted by this user.
    /// </summary>
    /// <param name="course">The <see cref="Course"/> object to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="course"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the user does not have the <see cref="Role.Teacher"/> role.</exception>
    public void AddConductedCourse(Course course)
    {
        if (course is null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        if(!Roles.Contains(Role.Teacher)) 
        {
            throw new InvalidOperationException("Only users with the Teacher role can conduct courses.");
        }
        
        _conductedCourses.Add(course);
    }
    
    /// <summary>
    ///     Removes a course from the collection of courses conducted by this user.
    /// </summary>
    /// <param name="course">The <see cref="Course"/> object to remove.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="course"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the course is not found in the user's conducted courses.</exception>
    public void RemoveConductedCourse(Course course)
    {
        if (course is null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        if (!_conductedCourses.Contains(course))
        {
            throw new InvalidOperationException("Course is not conducted by this user.");
        }

        _conductedCourses.Remove(course);
    }

    /// <summary>
    ///     Blocks the specified user.
    /// </summary>
    /// <param name="user">The user to block. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the provided user is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the user is already blocked.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when attempting to block oneself.
    /// </exception>
    public void BlockUser(User user)
    {
        if(user is null) 
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        if (_blockedUsers.Contains(user))
        {
            throw new InvalidOperationException("User is already blocked.");
        }
        
        if(user == this) 
        {
            throw new InvalidOperationException("Cannot block yourself.");
        }
        
        _blockedUsers.Add(user);
        user._blockedByUsers.Add(this);
    }
    
    /// <summary>
    ///     Unblocks the specified user.
    /// </summary>
    /// <param name="user">The user to unblock. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the provided user is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the user is not currently blocked.
    /// </exception>
    public void UnblockUser(User user)
    {
        if(user is null) 
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        if (!_blockedUsers.Contains(user))
        {
            throw new InvalidOperationException("User is not blocked.");
        }
        
        _blockedUsers.Remove(user);
        user._blockedByUsers.Remove(this);
    }

    /// <summary>
    ///     Determines whether the current user is blocked by the specified <paramref name="user"/>.
    /// </summary>
    /// <param name="user">The user to check against.</param>
    /// <returns>
    ///     <c>true</c> if the current user is in the <paramref name="user"/>'s list of blocked users; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="user"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the method is called on the same user as the argument.</exception>
    public bool IsBlockedBy(User user)
    {
        if(user is null) 
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        if (user == this)
        {
            throw new InvalidOperationException("Cannot check if yourself is blocked.");
        }
        
        return _blockedByUsers.Contains(user);
    }
    
    /// <summary>
    ///     Adds an availability slot to the user's collection of availabilities.
    /// </summary>
    /// <param name="availability">The <see cref="Availability"/> object to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="availability"/> is null.</exception>
    public void AddAvailability(Availability availability)
    {
        if (availability == null)
        {
            throw new ArgumentNullException(nameof(availability));
        }

        _availability.Add(availability);
    }
    
    /// <summary>
    ///     Removes an availability slot from the user's collection of availabilities.
    /// </summary>
    /// <param name="availability">The <see cref="Availability"/> object to remove.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="availability"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the specified availability slot does not exist for this user.</exception>
    public void RemoveAvailability(Availability availability)
    {
        if (availability == null)
        {
            throw new ArgumentNullException(nameof(availability));
        }

        if (!_availability.Contains(availability))
        {
            throw new InvalidOperationException("Availability does not exist for this user.");
        }

        _availability.Remove(availability);
    }
    
    public void AddParticipation(Participation participation)
    {
        if (participation == null)
        {
            throw new ArgumentNullException(nameof(participation));
        }

        _participations.Add(participation);
    }
    
    public void RemoveParticipation(Participation participation)
    {
        if (participation == null)
        {
            throw new ArgumentNullException(nameof(participation));
        }

        if (!_participations.Contains(participation))
        {
            throw new InvalidOperationException("Participation does not exist for this course.");
        }

        _participations.Remove(participation);
    }

    /// <summary>
    /// Adds a user as a spectator to this user.
    /// This establishes a bidirectional relationship where this user is spectated by the given user,
    /// and the given user spectates this user.
    /// </summary>
    /// <param name="user">The <see cref="User"/> object to add as a spectator.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="user"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when this user does not have the <see cref="Role.Student"/> role,
    /// as only students can have spectators.</exception>
    public void AddSpectator(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        //
        // if (!this._roles.Contains(Role.Student))
        // {
        //     throw new InvalidOperationException("Only users with the Student role can have spectators.");
        // }

        _spectatedBy.Add(user);
        user._spectates.Add(this);
    }
    
    /// <summary>
    ///     Removes a user from the list of spectators for this user.
    ///     This removes the bidirectional relationship between this user and the specified spectator.
    /// </summary>
    /// <param name="user">The <see cref="User"/> object to remove as a spectator.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="user"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the specified user is not currently a spectator of this user.</exception>
    public void RemoveSpectator(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (!_spectatedBy.Contains(user))
        {
            throw new InvalidOperationException("User is not a spectator of this user.");
        }

        _spectatedBy.Remove(user);
        user._spectates.Remove(this);
    }
    
    public void AddTag(Tag tag)
    {
        if (tag == null)
        {
            throw new ArgumentNullException(nameof(tag));
        }

        _tags.Add(tag);
    }
    
    public void AddFile(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        _files.Add(file);
    }
    
    public void RemoveFile(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        _files.Remove(file);
    }
    
    public void SetProfilePicture(ProfilePicture picture) => ProfilePicture = picture;
}