using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetViewModelEssentials
{
    public class DetailNavigationMessage
    {
        public INavigatorViewModel NavigateToViewModel { get; }

        public DetailNavigationMessage(INavigatorViewModel vm)
        {
            NavigateToViewModel = vm;
        }
    }
}
