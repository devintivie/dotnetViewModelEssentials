//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
using dotnetStandardEssentials;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace dotnetViewModelEssentials
{
    public abstract class MultipleNotificationsViewModel : UpdateableViewModel, IErrorViewModel
    {
        #region Fields
        #endregion

        #region Properties
        public ObservableCollection<INotificationViewModel> Messages { get; } = new ObservableCollection<INotificationViewModel>();

        public string MessageCountInfo => $"{MessageCount}";
        public int MessageCount => _backgroundHandler.NotificationCount;

        private bool _showMessages;
        /// <summary>
        /// 
        /// </summary>
        public bool ShowMessages
        {
            get { return _showMessages; }
            set
            {
                if (_showMessages != value)
                {
                    _showMessages = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Commands
        public IMvxCommand ToggleShowNotificationsCommand { get; }
        #endregion

        #region Constructors
        public MultipleNotificationsViewModel(IBackgroundHandler backgroundHandler) : base(backgroundHandler)
        {
            _backgroundHandler = backgroundHandler;
            //_backgroundHandler.RegisterMessage<NotifyMessage>(this, x => AddNotification(x));

            ToggleShowNotificationsCommand = new MvxCommand(OnToggleShowNotifications);
            //_ = UpdateMessagesLoopAsync();
        }
        #endregion

        #region Methods
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
            }
            catch(Exception ex)
            {

            }
            
        }

        //private async Task UpdateMessagesLoopAsync()
        //{
        //    while (true)
        //    {
        //        Messages.Clear();
        //        foreach (GeneralMessage message in _backgroundHandler.)
        //        {

        //        }
        //    }
        //}

        public void UpdateShowMessages()
        {
            RaisePropertyChanged(nameof(MessageCountInfo));
            if (_backgroundHandler.NotificationCount == 0)
            {
                ShowMessages = false;
            }
        }
        #endregion

    }
}
