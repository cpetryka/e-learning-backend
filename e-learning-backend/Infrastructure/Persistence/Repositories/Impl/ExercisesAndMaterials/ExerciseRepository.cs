﻿using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationContext _context;

    public ExerciseRepository(ApplicationContext context) => _context = context;


    public async Task<Exercise?> GetByIdAsync(Guid id)
        => await _context.Exercises
            .Include(e => e.Class)
            .Include(e => e.ExerciseResources)
            .SingleOrDefaultAsync(e => e.Id == id);


    public async Task<IEnumerable<Exercise>> GetAllAsync()
        => await _context.Exercises
            .Include(e => e.Class)
            .Include(e => e.ExerciseResources)
            .ToListAsync();


    public async Task AddAsync(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ExerciseBriefDTO>> GetAllUnsolvedExercisesByUserId(Guid userId)
    {
        return await _context.Exercises
            .Include(e => e.Class)
                .ThenInclude(c => c.Participation)
            .Include(e => e.ExerciseResources)
            .Where(e =>
                (e.Status == ExerciseStatus.Unsolved || e.Status == ExerciseStatus.SolutionAdded)
                && e.Class.Participation.UserId == userId)
            .Select(e => new ExerciseBriefDTO
            {
                Id = e.Id,
                CourseId = e.Class.CourseId,
                CourseName = e.Class.Participation.Course.Name,
                ClassStartTime = e.Class.StartTime,
                ExerciseStatus = e.Status.ToString()
            })
            .ToListAsync();
    }
}