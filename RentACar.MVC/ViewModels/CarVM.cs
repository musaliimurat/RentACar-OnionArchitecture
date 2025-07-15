using RentACar.Application.DTOs.Concrete.CarDto;

namespace RentACar.MVC.ViewModels
{
    public class CarVM
    {
        public GetCarByIdDto GetCarByIdDto { get; set; }
        public List<GetAllCarsSliderDto> GetAllCarsSliderDtos { get; set; }
    }
}
