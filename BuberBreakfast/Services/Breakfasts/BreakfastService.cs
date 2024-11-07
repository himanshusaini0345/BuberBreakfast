using BuberBreakfast.Models;
using BuberBreakfast.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        private readonly BuberBreakfastDbContext _dbContext;

        public BreakfastService(BuberBreakfastDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBreakfast(Breakfast breakfast)
        {
            _dbContext.Breakfasts.Add(breakfast);
            _dbContext.SaveChanges();
        }

        public bool DeleteBreakfast(Guid id)
        {
            var breakfast = _dbContext.Breakfasts.Find(id);

            if (breakfast is null)
            {
                return false;
            }

            _dbContext.Breakfasts.Remove(breakfast);
            _dbContext.SaveChanges();
            return true;
        }

        public Models.Breakfast? GetBreakfast(Guid id)
        {
            if(_dbContext.Breakfasts.Find(id) is Breakfast breakfast)
            {
                return breakfast;
            }
            return null;
        }
        
        public bool UpsertBreakfast(Models.Breakfast breakfast)
        {
            var existingBreakfast = _dbContext.Breakfasts
                                       .AsNoTracking()
                                       .FirstOrDefault(b => b.Id == breakfast.Id);
            if (existingBreakfast is null)
            {
                _dbContext.Breakfasts.Add(breakfast);
            }
            else
            {
                _dbContext.Breakfasts.Update(breakfast);
            }

            _dbContext.SaveChanges();
            return existingBreakfast is null;
        }
    }
}
