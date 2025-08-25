﻿using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationContext _context;

    public CourseRepository(ApplicationContext context) => _context = context;

   
    public async Task<Course?> GetByIdAsync(Guid id)
        => await _context.Courses
            .Include(c => c.Teacher)
            .Include(c => c.Variants)
            .Include(c => c.Participations)
            .SingleOrDefaultAsync(c => c.Id == id);

    
    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses
            .Include(c => c.Category)
            .Include(c => c.Teacher)
            .Include(c => c.Variants)
            .ThenInclude(v => v.Level)
            .Include(c => c.Variants)
            .ThenInclude(v => v.Language)
            .Include(c => c.Variants)
            .ThenInclude(v => v.Rate)
            .Include(c => c.Participations)
            .ThenInclude(p => p.Review)
            .ToListAsync();
    }

    
    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    
    public async Task DeleteAsync(Guid id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}