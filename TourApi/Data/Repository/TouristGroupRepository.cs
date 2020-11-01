using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApi.Infrastructure;
using TourApi.Models;
using TourApi.Models.IRepository;

namespace TourApi.Data.Repository
{
    public class TouristGroupRepository : Repository<TouristGroup>, ITouristGroupRepository
    {
        private readonly TourContext _context;
        public TouristGroupRepository(TourContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateTouristGroupDetailsOfStaff(int touristGroupId, List<TouristGroupDetailsOfStaff> newList)
        {
            var listTouristGroupDetailsOfStaff = _context.TouristGroupDetailsOfStaff.Where(t => t.TouristGroupId == touristGroupId);
            _context.TouristGroupDetailsOfStaff.RemoveRange(listTouristGroupDetailsOfStaff);
            await _context.TouristGroupDetailsOfStaff.AddRangeAsync(newList);
            await _context.SaveChangesAsync();
        }
    }
}