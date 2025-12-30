using Chinese_Auction.Data;
using Chinese_Auction.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Chinese_Auction.Repository
{
    public class GiftRepository : IGiftRepository
    {
        private readonly ChineseAuctionDbContext _context;
        public GiftRepository(ChineseAuctionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gift>> GetAllGiftsAsync()
        {
            return await _context.Gifts
                .Include(g => g.Category)
                .Include(g => g.Donor)
                .Where(g => g.IsApproved)
                .ToListAsync();
        }

        public async Task<Gift?> GetGiftByIdAsync(int id)
        {
            return await _context.Gifts.Include(g => g.Category).Include(g => g.Donor).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Gift>> GetUnApprovedGiftsAsync()
        {
            return await _context.Gifts
                .Include(g => g.Category)
                .Include(g => g.Donor)
                .Where(g => !g.IsApproved)
                .ToListAsync();
        }

        public async Task<Gift> CreateGiftAsync(Gift gift)
        {
            _context.Gifts.Add(gift);
            await _context.SaveChangesAsync();
            return gift;
        }

        public async Task<Gift?> UpdateGiftAsync(Gift gift)
        {
            var existing = await _context.Gifts.FindAsync(gift.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(gift);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteGiftAsync(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);
            if (gift != null)
            {
                _context.Gifts.Remove(gift);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Gift>> GetGiftsByCategoryIdAsync(int categoryId)
        {
            return await _context.Gifts
                .Include(g => g.Category)
                .Include(g => g.Donor)
                .Where(g => g.Category_Id == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gift>> GetGiftsByDonorIdAsync(int donorId)
        {
            return await _context.Gifts
                .Include(g => g.Category)
                .Include(g => g.Donor)
                .Where(g => g.Donor_Id == donorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gift>> GetGiftsByApprovalStatusAsync(bool isApproved)
        {
            return await _context.Gifts
                .Include(g => g.Category)
                .Include(g => g.Donor)
                .Where(g => g.IsApproved == isApproved)
                .ToListAsync();
        }
        //public async Task<bool> UpdateGiftPurchaseQuantity(int giftId)
        //{
        //    var gift = await _context.Gifts.FindAsync(giftId);
        //    if (gift == null) return false;
        //    gift.Purchase_quantity ++;
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        public async Task<Gift?> UpdateGiftPurchasesQuantityAsync(int giftId)
        {
            int rowsAffected = await _context.Gifts
                .Where(g => g.Id == giftId)
                .ExecuteUpdateAsync(s => s.SetProperty(
                    g => g.Purchase_quantity,
                    g => g.Purchase_quantity + 1));
            if (rowsAffected == 0) return null;
            return await _context.Gifts.FindAsync(giftId);
        }

    }
}