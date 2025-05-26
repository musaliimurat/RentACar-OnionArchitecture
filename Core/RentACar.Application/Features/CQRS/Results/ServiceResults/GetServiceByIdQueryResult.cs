namespace RentACar.Application.Features.CQRS.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
