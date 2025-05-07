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

    public static Role Admin => new Role("admin");
    public static Role Teacher => new Role("teacher");
    public static Role Spectator => new Role("spectator");
    public static Role Student => new Role("student");

    public static Role FromString(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            throw new ArgumentException("Role name cannot be empty.", nameof(roleName));
        }

        return roleName.ToLower() switch
        {
            "admin" => Admin,
            "teacher" => Teacher,
            "spectator" => Spectator,
            "student" => Student,
            _ => throw new ArgumentException($"Invalid role name: {roleName}", nameof(roleName))
        };
    }

    public bool Equals(Role? other) => other is not null && RoleName == other.RoleName;
    public override string ToString() => RoleName;
}