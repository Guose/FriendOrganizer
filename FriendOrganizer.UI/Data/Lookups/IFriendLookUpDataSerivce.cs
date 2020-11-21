using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Lookups
{
    public interface IFriendLookUpDataSerivce
    {
        Task<IEnumerable<LookUpItem>> GetFriendLookupAsync();
    }
}