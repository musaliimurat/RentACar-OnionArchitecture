using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.AboutDTOs
{
    public class UpdateAboutDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
