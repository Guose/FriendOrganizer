using System.Threading.Tasks;

namespace FriendOrganizer.UI.View.Services
{
    public interface IMessageDialogService
    {
        Task<MessageDialogResult> ShowOkCancelDialogAsync(string message, string title);
        Task ShowInfoDialogAsync(string text);
    }
}