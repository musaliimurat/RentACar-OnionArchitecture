using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class UpdateBlogVM
    {
        public List<GetAllAuthorDto> GetAllAuthorDtos { get; set; }
        public List<GetAllCategoryDto> GetAllCategoryDtos { get; set; }
        public UpdateBlogDto UpdateBlogDto { get; set; }
    }
}
