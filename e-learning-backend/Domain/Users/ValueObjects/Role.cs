namespace e_learning_backend.Domain.Users.ValueObjects;

/// <summary>
///    Represents a role within the system, such as Admin, Teacher, Spectator, or Student.
/// </summary>
public class Role : IEquatable<Role>
{
    public string RoleName { get; private set; }

    private Role(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            throw new ArgumentException("Role name cannot be empty.", nameof(roleName));
        }

        RoleName = roleName;
    }

    public static Role Admin => new Role("Admin");
    public static Role Teacher => new Role("Teacher");
    public static Role Spectator => new Role("Spectator");
    public static Role Student => new Role("Student");

    public bool Equals(Role? other) => other is not null && RoleName == other.RoleName;

    public override string ToString() => RoleName;
}