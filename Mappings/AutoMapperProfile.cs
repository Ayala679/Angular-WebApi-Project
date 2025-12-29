using AutoMapper;
using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;

namespace Chinese_Auction.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Category
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();

            // Gift
            CreateMap<Gift, GiftDto>()
                .ForMember(dest => dest.Category_Name, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
            CreateMap<UpdateGiftDto, Gift>()
                .ForMember(dest => dest.Purchase_quantity, opt => opt.Condition((src, dest, srcMember) => srcMember != 0));

            // Package
            CreateMap<Package, GetPackageDto>();
            CreateMap<CreatePackageDto,Package>();


            // Purchase
            CreateMap<CreatePurchaseDto, Purchase>();
            CreateMap<Purchase, GetPurchaseDto>();
            CreateMap<UpdatePurchaseDto, Purchase>();

            // Basket
            CreateMap<CreateBasketDto, Basket>();
            CreateMap<Basket, GetBasketDto>();

            // Donor
            CreateMap<CreateDonorDto, Donor>();
            CreateMap<Donor, ManagerGetDonorDto>();
            CreateMap<Donor, UserGetDonorDto>();

            // User
            CreateMap<CreateUserDto, User>();
            CreateMap<User, GetUserDto>();

        }
    }
}