using AutoMapper;
using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;
using Chinese_Auction.Repository;

namespace Chinese_Auction.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public DonorService(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
        {
            var donors = await _donorRepository.GetAllDonorsAsync();
            return _mapper.Map<IEnumerable<Donor>>(donors);
        }

        public async Task<Donor?> GetDonorByIdAsync(int id)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(id);
            return donor == null ? null : _mapper.Map<Donor>(donor);
        }

        public async Task<ManagerGetDonorDto> CreateDonorAsync(CreateDonorDto donor)
        {
            if (await DonorEmailExistsAsync(donor.Email, -1))
                throw new Exception("Donor with the same email already exists.");
            var createDonor = _mapper.Map<Donor>(donor);
            await _donorRepository.CreateDonorAsync(createDonor);
            return _mapper.Map<ManagerGetDonorDto>(createDonor);
        }

        public async Task<Donor?> UpdateDonorAsync(int id, CreateDonorDto donor)
        {
            var existingDonor = await _donorRepository.GetDonorByIdAsync(id);
            if (existingDonor == null) return null;
            if (await DonorEmailExistsAsync(donor.Email, id))
                throw new Exception("Donor with the same email already exists.");
            _mapper.Map(donor, existingDonor);
            existingDonor.Id = id;
            var updatedDonor = await _donorRepository.UpdateDonorAsync(existingDonor);
            return updatedDonor == null ? null : _mapper.Map<Donor>(updatedDonor);
        }

        public async Task<bool> DeleteDonorAsync(int id)
        {
            var existingDonor = await _donorRepository.GetDonorByIdAsync(id);
            if (existingDonor == null) return false;
            await _donorRepository.DeleteDonorAsync(id);
            return true;
        }

        public async Task<bool> DonorEmailExistsAsync(string email, int id)
        {
            return await _donorRepository.DonorEmailExistsAsync(email, id);
        }

        public async Task<Donor?> GetDonorByEmailAsync(string email)
        {
            return await _donorRepository.GetDonorByEmailAsync(email);
        }
    }
}
