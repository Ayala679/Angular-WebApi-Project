using AutoMapper;
using Chinese_Auction.Dto_s;
using Chinese_Auction.Models;
using Chinese_Auction.Repository;

namespace Chinese_Auction.Services
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IMapper _mapper;

        public GiftService(IGiftRepository giftRepository, IMapper mapper)
        {
            _giftRepository = giftRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGiftDto>> GetAllGiftsAsync()
        {
            var gifts = await _giftRepository.GetAllGiftsAsync();
            return _mapper.Map<IEnumerable<GetGiftDto>>(gifts);
        }

        public async Task<GetGiftDto?> GetGiftByIdAsync(int id)
        {
            var gift = await _giftRepository.GetGiftByIdAsync(id);
            return gift == null ? null : _mapper.Map<GetGiftDto?>(gift);
        }

        public async Task<IEnumerable<GetGiftDto>> GetUnApprovedGiftsAsync()
        {
            var gifts = await _giftRepository.GetUnApprovedGiftsAsync();
            return _mapper.Map<IEnumerable<GetGiftDto>>(gifts);
        }

        public async Task<GetGiftDto> CreateGiftAsync(GiftDto gift)
        {
            var createGift = _mapper.Map<Gift>(gift);
            var addedGift = await _giftRepository.CreateGiftAsync(createGift);
            return _mapper.Map<GetGiftDto>(addedGift);
        }

        public async Task<GetGiftDto?> UpdateGiftAsync(int id, GiftDto gift)
        {
            var existingGift = await _giftRepository.GetGiftByIdAsync(id);
            if (existingGift == null)
                return null;
            _mapper.Map<Gift>(gift);
            existingGift.Id = id;
            var updatedGift = await _giftRepository.UpdateGiftAsync(existingGift);
            return updatedGift == null ? null : _mapper.Map<GetGiftDto>(updatedGift);
        }


        public async Task<UpdateGiftDto?> UpdateGiftPurchasesQuantityAsync(int id)
        {
            var existingGift = await _giftRepository.GetGiftByIdAsync(id);
            if (existingGift == null)
                return null;
            var updatedGift = await _giftRepository.UpdateGiftPurchasesQuantityAsync(id);
            return updatedGift == null ? null : _mapper.Map<UpdateGiftDto>(updatedGift);
        }
        public async Task<bool> DeleteGiftAsync(int id)
        {
            var existingGift = await _giftRepository.GetGiftByIdAsync(id);
            if (existingGift == null) return false;
            await _giftRepository.DeleteGiftAsync(id);
            return true;
        }
    }
}
