using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfast
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Models.Breakfast breakfast);
        bool DeleteBreakfast(Guid id);
        Models.Breakfast? GetBreakfast(Guid id);
        bool UpsertBreakfast(Models.Breakfast breakfast);
    }
}
