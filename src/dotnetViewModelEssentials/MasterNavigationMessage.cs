using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetViewModelEssentials
{
    public class MasterNavigationMessage
    {
        public INavigatorViewModel NavigateToViewModel { get; }

        public MasterNavigationMessage(INavigatorViewModel vm)
        {
            NavigateToViewModel = vm;
        }
    }
}
