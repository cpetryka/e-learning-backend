using System.Text.Json;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class FileResourceRepository : IFileResourceRepository
{
    private class UserFileRow
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;
        public DateTimeOffset UploadedAt { get; set; }
        public string Tags { get; set; } = "[]";
        public string ParticipationUsers { get; set; } = "[]"; 
        public string OwnerInfo { get; set; } 
        public string Courses { get; set; } = "[]";
    }
    
    private class FileExtensionRow
    { 
        public string Extension { get; set; } = string.Empty;
    }
    
    private class ClassFileOwnerRow
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }

    
    private readonly ApplicationContext _context;

    public FileResourceRepository(ApplicationContext context)
        => _context = context;


    public async Task<FileResource?> GetByIdAsync(Guid id)
        => await _context.FileResources
            .Include(f => f.User)
            .Include(f => f.Tags)
            .Include(f => f.ExerciseResources)
            .SingleOrDefaultAsync(f => f.Id == id);


    public async Task<IEnumerable<FileResource>> GetAllAsync()
        => await _context.FileResources
            .Include(f => f.User)
            .Include(f => f.Tags)
            .Include(f => f.ExerciseResources)
            .ToListAsync();


    public async Task<bool> DeleteFileAsync(Guid id, CancellationToken ct = default)
    {
        var file = await _context.FileResources.FindAsync(new object?[] { id }, ct);

        if (file is null)
            return false;

        _context.FileResources.Remove(file);
        await _context.SaveChangesAsync(ct);

        return true;
    }


    public async Task<List<GetFileDTO>> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        
    var rows = await _context.Database
            .SqlQueryRaw<UserFileRow>(
                """
                SELECT
                    "FileId",
                    "FileName",
                    "RelativePath",
                    "UploadedAt",
                    "Tags",
                    "ParticipationUsers",
                    "OwnerInfo",
                    "Courses"
                FROM get_user_files({0})
                """,
                userId
            )
            .ToListAsync(ct);

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var result = rows.Select(r => new GetFileDTO
        {
            Id = r.FileId,
            FileName = r.FileName,
            RelativePath = r.RelativePath,
            UploadedAt = r.UploadedAt,
            Tags = JsonSerializer.Deserialize<List<GetFileDTO.TagDTO>>(r.Tags, jsonOptions) ?? new(),
            ParticipationUsers =
                JsonSerializer.Deserialize<List<GetFileDTO.UserDTO>>(r.ParticipationUsers, jsonOptions) ??   new(),
            OwnerInfo = JsonSerializer.Deserialize<GetFileDTO.UserDTO>(r.OwnerInfo ?? "{}", jsonOptions) ?? new(),
            Courses = JsonSerializer.Deserialize<List<GetFileDTO.CourseDTO>>(r.Courses, jsonOptions) ?? new(),
            
        }).ToList();

        return result;
    }
    
    public async Task<List<string>> GetFileExtensionsByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        var rows = await _context.Database
            .SqlQueryRaw<FileExtensionRow>(
                """
                SELECT "Extension"
                FROM get_file_extensions_for_user({0})
                """,
                userId
            )
            .ToListAsync(ct);
        
        var result = rows
            .Select(r => r.Extension?.Trim())
            .Where(e => !string.IsNullOrWhiteSpace(e))
            .ToList();

        return result;
    }

    public async Task<List<ClassFileOwnerDTO>> GetClassFileOwnersAsync(Guid userId, CancellationToken ct = default)
    {
        var rows = await _context.Database
            .SqlQueryRaw<ClassFileOwnerRow>(
                """
                SELECT "Id", "Name", "Surname"
                FROM get_class_file_owners({0})
                """,
                userId
            )
            .ToListAsync(ct);

        return rows
            .Select(r => new ClassFileOwnerDTO
            {
                Id = r.Id,
                Name = r.Name,
                Surname = r.Surname
            })
            .ToList();
    }

    public async Task AddAsync(FileResource file)
    {
        await _context.FileResources.AddAsync(file);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(FileResource file)
    {
        _context.FileResources.Update(file);
        await _context.SaveChangesAsync();
    }
}

