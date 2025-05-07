using e_learning_backend.Domain.Users.ValueObjects;

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

    // Used to differentiate between a teacher, a student, etc.
    private readonly HashSet<Role> _roles = new();
    public IReadOnlyCollection<Role> Roles => _roles;

    // Used for authentication
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    private User() { }

    public User(
        Guid id,
        string name,
        string surname,
        string email,
        string hashedPassword,
        string phone,
        Role initialRole,
        string? aboutMe = null)
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
}