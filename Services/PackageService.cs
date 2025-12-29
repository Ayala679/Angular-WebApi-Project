using AutoMapper;
using Chinese_Auction.Dto_s;
using Chinese_Auction.Repository;

namespace Chinese_Auction.Services
{
    public class PackageService
    {
        private readonly IMapper _mapper;
        private readonly IPackageRepository _packageRepository;

        public PackageService(IMapper mapper, IPackageRepository packageRepository)
        {
            _mapper = mapper;
            _packageRepository = packageRepository;
        }
        public async Task<IEnumerable<GetPackageDto>> GetAllPackagesAsync()
        {
            var packages = await _packageRepository.GetAllPackagesAsync();
            return _mapper.Map<IEnumerable<GetPackageDto>>(packages);
        }
    }
}
