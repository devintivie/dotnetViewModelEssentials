//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using dotnetStandardEssentials;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace dotnetViewModelEssentials
//{
//    /// <summary>
//    /// ViewModel that updates via <see cref="UpdateViewMessage"/> but 
//    /// does not Navigate, generally used for Application global menu
//    /// </summary>
//    public abstract class ToolkitUpdateableViewModel : ObservableObject, IUpdateableViewModel
//    {
//        #region Fields
//        protected IBackgroundHandler _backgroundHandler;
//        #endregion

//        public ToolkitUpdateableViewModel(IBackgroundHandler backgroundHandler)
//        {
//            _backgroundHandler = backgroundHandler;

//            _backgroundHandler.RegisterMessage<UpdateViewMessage>(this, x => OnUpdateView());
//        }

//        public virtual void OnUpdateView()
//        {
//            UpdateUIControlAccess();
//        }

//        public virtual void UpdateUIControlAccess()
//        {
//            // Loop through all Properties in ViewModel, updating CanExecute method tied
//            // to IMvxCommand 
//            foreach (var property in GetType().GetProperties())
//            {
//                try
//                {
//                    if (property.PropertyType == typeof(IRelayCommand) && property.GetValue(this) != null)
//                    {
//                        MethodInfo m = property.PropertyType.GetMethod("NotifyCanExecuteChanged");
//                        m.Invoke(property.GetValue(this), null);
//                    }
//                }
//                catch (TargetException)
//                {
//                    //If IMvxCommand is declared but not instantiated, TargetException occurs
//                }
//            }
//        }
//    }
//}
