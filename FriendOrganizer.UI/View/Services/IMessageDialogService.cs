namespace FriendOrganizer.UI.View.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowOkCancelDialog(string message, string title);
        void ShowInfoDialog(string text);
    }
}