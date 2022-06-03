using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetViewModelEssentials
{
    /// <summary>
    /// Shared navigation service, base methods for all navigation services
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to Settings Page
        /// </summary>
        /// <returns></returns>
        Task NavigateToSettingsScreen();

        /// <summary>
        /// Asynchronously close current configuration
        /// </summary>
        /// <returns></returns>
        Task CloseConfigurationAsync();

        /// <summary>
        /// Asynchronously load new Configuration
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        Task LoadConfigurationAsync(string filename);
    }
}
