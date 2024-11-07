using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Exceptions.Breakfast;
using BuberBreakfast.Mappers;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BreakfastsController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastsController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            try
            {
                var breakfast = new Breakfast(
                    Guid.NewGuid(),
                    request.Name,
                    request.Description,
                    request.StartDateTime,
                    request.EndDateTime,
                    DateTime.UtcNow,
                    request.Savory,
                    request.Sweet);

                _breakfastService.CreateBreakfast(breakfast);

                var response = breakfast.ToBreakfastResponse();
                return CreatedAtAction(nameof(GetBreakfast), new { id = breakfast.Id }, response);
            }
            catch (BreakfastValidationException ex)
            {
                var validationProblemDetails = new ValidationProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Error",
                    Detail = "One or more validation errors occurred. Please correct the issues and try again.",
                    Instance = HttpContext.Request.Path
                };

                validationProblemDetails.Errors.Add("ValidationErrors", [.. ex.ValidationErrors]);
                return BadRequest(validationProblemDetails);
            }
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            var breakfast = _breakfastService.GetBreakfast(id);

            if (breakfast == null)
            {
                return NotFound();
            }
            var response = breakfast.ToBreakfastResponse();

            return Ok(response);
        }



        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            ;

            return _breakfastService.UpsertBreakfast(breakfast)
                ? CreatedAtAction(nameof(GetBreakfast), new { id = breakfast.Id }, breakfast.ToBreakfastResponse())
                : NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            return _breakfastService.DeleteBreakfast(id) ? NoContent() : NotFound();
        }
    }
}
