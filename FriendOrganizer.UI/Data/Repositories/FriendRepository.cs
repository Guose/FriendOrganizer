using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : GenericRepository<Friend, FriendOrganizerDbContext>, IFriendRepository
    {
        //return a Func because we're using AutoFac - registered in bootstrapper
        public FriendRepository(FriendOrganizerDbContext context)
            :base(context)
        {
        }

        //Get entities from DB asynchronously
        public override async Task<Friend> GetByIdAsync(int friendId)
        {
            //returns singel friend by Id
            return await Context.Friends
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.Id == friendId);
        }

        public async Task<bool> HasMeetingsAsync(int friendId)
        {
            return await Context.Meetings.AsNoTracking()
                .Include(m => m.Friends)
                .AnyAsync(m => m.Friends.Any(f => f.Id == friendId));
        }

        public void RemovePhoneNumber(FriendPhoneNumber model)
        {
            Context.FriendPhoneNumbers.Remove(model);
        }
    }
}
