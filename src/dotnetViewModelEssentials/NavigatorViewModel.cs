using DotNetStandardEssentials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetViewModelEssentials
{
    /// <summary>
    /// ViewModel that updated via <see cref="UpdateViewMessage"/> and
    /// is able get cleaned via GarbageCollection after receiving <see cref="ViewUnloadedMessage"/>
    /// </summary>
    public abstract class NavigatorViewModel : UpdateableViewModel, INavigatorViewModel
    {
        #region Properties

        #endregion

        #region Constructors

        public NavigatorViewModel(IBackgroundHandler backgroundHandler) : base(backgroundHandler)
        {
            _backgroundHandler.RegisterMessage<ViewUnloadedMessage>(this, async x => await OnUnloadedAsync());
        }
        #endregion

        #region Methods
        public virtual Task OnUnloadedAsync()
        {
            _backgroundHandler.UnregisterMessages(this);
            return Task.CompletedTask;
        }


        #endregion

    }
}
