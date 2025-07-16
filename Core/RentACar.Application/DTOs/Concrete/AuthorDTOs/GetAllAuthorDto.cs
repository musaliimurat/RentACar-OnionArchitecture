using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.AuthorDTOs
{
    public class GetAllAuthorDto : IDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
