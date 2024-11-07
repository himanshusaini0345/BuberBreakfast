using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);
        bool DeleteBreakfast(Guid id);
        Models.Breakfast? GetBreakfast(Guid id);
        bool UpsertBreakfast(Breakfast breakfast);
    }
}
