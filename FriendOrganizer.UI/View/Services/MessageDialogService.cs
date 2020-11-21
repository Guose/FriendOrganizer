using System.Windows;

namespace FriendOrganizer.UI.View.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK ? MessageDialogResult.OK : MessageDialogResult.Cancel;
        }
        public void ShowInfoDialog(string text)
        {
            MessageBox.Show(text, "Info");
        }
    }
    public enum MessageDialogResult
    {
        OK,
        Cancel
    }
}
