using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;

namespace RentACar.MVC.Areas.Admin.ViewModels
{
    public class BlogVM
    {
        public List<GetAllAuthorDto> GetAllAuthorDtos { get; set; }
        public List<GetAllCategoryDto> GetAllCategoryDtos { get; set; }
        public CreateBlogDto CreateBlogDto { get; set; }
    }
}
