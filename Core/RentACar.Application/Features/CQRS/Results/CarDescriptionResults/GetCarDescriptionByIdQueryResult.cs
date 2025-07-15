namespace RentACar.Application.Features.CQRS.Results.CarDescriptionResults
{
    public class GetCarDescriptionByIdQueryResult
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string Details { get; set; }
        public string CoverPhotoUrl { get; set; }
    }
}
