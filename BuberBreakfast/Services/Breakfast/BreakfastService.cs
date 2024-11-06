using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfast
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();
        public void CreateBreakfast(Models.Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);
        }

        public bool DeleteBreakfast(Guid id)
        {
            return _breakfasts.Remove(id);
        }

        public Models.Breakfast? GetBreakfast(Guid id)
        {
            if(_breakfasts.TryGetValue(id, out var breakfast))
            {
                return breakfast;
            }
            return null;
        }

        public bool UpsertBreakfast(Models.Breakfast breakfast)
        {
            bool isNew = _breakfasts.ContainsKey(breakfast.Id);
            _breakfasts[breakfast.Id] = breakfast;
            return isNew;
        }
    }
}
