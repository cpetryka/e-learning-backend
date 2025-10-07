using e_learning_backend.Domain.Classes;

namespace e_learning_backend.Domain.ExercisesAndMaterials;

public class LinkResource
{
    public Guid Id { get; private set; }
    public string Link { get; private set; } = string.Empty;
    public DateTime? Date { get; private set; }

    public Guid ClassId { get; private set; }
    public Class Class { get; private set; }

    private LinkResource() { } // dla EF

    public LinkResource(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
            throw new ArgumentException("Link cannot be null or empty.", nameof(link));

        Link = link;
        Date = DateTime.UtcNow;
    }
}