using dotnetStandardEssentials;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace dotnetViewModelEssentials
{
    public abstract class SingleNotificationViewModel : UpdateableViewModel, IErrorViewModel
    {
        #region Fields
        //protected IBackgroundHandler _backgroundHandler;
        #endregion

        #region Properties
        public ObservableCollection<INotificationViewModel> Messages { get; } = new ObservableCollection<INotificationViewModel>();
        public string MessageCountInfo => $"{MessageCount}";
        public int MessageCount => _backgroundHandler.NotificationCount;

        private bool showMessages = false;
        public bool ShowMessages
        {
            get { return showMessages; }
            set
            {
                if (showMessages != value)
                {
                    showMessages = value;
                    RaisePropertyChanged();
                }
            }
        }


        #endregion

        #region Commands
        public IMvxCommand ToggleShowNotificationsCommand { get; }

        #endregion

        #region Constructors
        public SingleNotificationViewModel(IBackgroundHandler backgroundHandler) : base(backgroundHandler)
        {
            _backgroundHandler = backgroundHandler;
            _backgroundHandler.RegisterMessage<NotifyMessage>(this, x => AddNotification(x));

            ToggleShowNotificationsCommand = new MvxCommand(OnToggleShowNotifications);
        }

        private void OnToggleShowNotifications()
        {
            if (_backgroundHandler.NotificationCount > 0)
            {
                ShowMessages = !ShowMessages;
            }
            else
            {
                ShowMessages = false;
            }


        }

        private void AddNotification(NotifyMessage x)
        {
            try
            {
                Messages.Add(new NotificationViewModel(_backgroundHandler, this, x.LogMessage));
                RaisePropertyChanged(nameof(MessageCountInfo));
                //Messages.Add(x.LogMessage.Message);
            }
            catch (Exception ex)
            {

            }

        }

        public void UpdateShowMessages()
        {
            RaisePropertyChanged(nameof(MessageCountInfo));
            if (_backgroundHandler.NotificationCount == 0)
            {
                ShowMessages = false;
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}
