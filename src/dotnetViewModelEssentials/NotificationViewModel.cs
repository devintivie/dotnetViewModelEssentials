using DotNetStandardEssentials;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetViewModelEssentials
{
    public class NotificationViewModel : NavigatorViewModel, INotificationViewModel
    {
        #region Fields
        private IErrorViewModel _parent;
        #endregion

        #region Properties
        public string Message { get; private set; }
        public GeneralMessageType LogType { get; private set; }
        #endregion

        #region Commands
        public IMvxCommand DismissCommand { get; }
        #endregion

        #region Constructors
        public NotificationViewModel(IBackgroundHandler backgroundHandler, IErrorViewModel parent, GeneralMessage logMessage)
            : base(backgroundHandler)
        {
            _backgroundHandler = backgroundHandler;
            Message = logMessage.Message;
            LogType = logMessage.MessageType;

            _parent = parent;

            DismissCommand = new MvxCommand(OnDismiss);

        }

        private void OnDismiss()
        {
            var index = _parent.Messages.IndexOf(this);
            _parent.Messages.Remove(this);
            _backgroundHandler.DismissMessage(index);
            _parent.UpdateShowMessages();
        }
        #endregion

        #region Methods

        #endregion

    }
}