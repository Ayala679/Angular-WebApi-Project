using AutoMapper;
using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;
using Chinese_Auction.Repository;

namespace Chinese_Auction.Services
{
    public class PackageService : IPackageService
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

        public async Task<GetPackageDto?> GetPackageByIdAsync(int id)
        {
            var package = await _packageRepository.GetPackageByIdAsync(id);
            return package == null ? null : _mapper.Map<GetPackageDto>(package);
        }

        public async Task<GetPackageDto> CreatePackageAsync(CreatePackageDto createPackageDto)
        {
            var package = _mapper.Map<Package>(createPackageDto);
            await _packageRepository.CreatePackageAsync(package);
            return _mapper.Map<GetPackageDto>(package);
        }

        public async Task<GetPackageDto?> UpdatePackageAsync(int id, CreatePackageDto updatePackageDto)
        {
            var existingPackage = await _packageRepository.GetPackageByIdAsync(id);
            if (existingPackage == null) return null;
            _mapper.Map(updatePackageDto, existingPackage);
            existingPackage.Id = id;
            var updatedPackage = await _packageRepository.UpdatePackageAsync(existingPackage);
            return updatedPackage == null ? null : _mapper.Map<GetPackageDto>(updatedPackage);
        }

        public async Task<bool> DeletePackageAsync(int id)
        {
            var existingPackage = await _packageRepository.GetPackageByIdAsync(id);
            if (existingPackage == null) return false;
            await _packageRepository.DeletePackageAsync(id);
            return true;
        }




    }
}
