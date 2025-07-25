using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.TestimonialDTOs
{
    public class UpdateTestimonialDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
