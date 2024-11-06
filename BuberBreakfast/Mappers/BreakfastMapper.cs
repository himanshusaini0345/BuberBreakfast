using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;

namespace BuberBreakfast.Mappers
{

    public static class BreakfastMapper
    {
        /// <summary>
        /// Converts Breakfast to BreakfastResponse
        /// </summary>
        public static BreakfastResponse ToBreakfastResponse(this Breakfast breakfast)
        {
            return new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);
        }
    }
}
