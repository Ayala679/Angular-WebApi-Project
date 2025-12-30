using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;

namespace Chinese_Auction.Services
{
    public interface IDonorService
    {
        Task<ManagerGetDonorDto> CreateDonorAsync(CreateDonorDto donor);
        Task<bool> DeleteDonorAsync(int id);
        Task<bool> DonorEmailExistsAsync(string email, int id);
        Task<IEnumerable<Donor>> GetAllDonorsAsync();
        Task<Donor?> GetDonorByEmailAsync(string email);
        Task<Donor?> GetDonorByIdAsync(int id);
        Task<Donor?> UpdateDonorAsync(int id, CreateDonorDto donor);
    }
}