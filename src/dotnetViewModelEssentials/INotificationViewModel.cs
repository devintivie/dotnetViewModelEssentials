using DotNetStandardEssentials;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetViewModelEssentials
{
    public interface INotificationViewModel
    {
        string Message { get; }
        GeneralMessageType LogType { get; }
        IMvxCommand DismissCommand { get; }
    }
}
