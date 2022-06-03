using System.Collections.ObjectModel;

namespace dotnetViewModelEssentials
{
    public interface IErrorViewModel
    {
        ObservableCollection<INotificationViewModel> Messages { get; }
        void UpdateShowMessages();
    }
}