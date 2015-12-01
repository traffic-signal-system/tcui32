using Apex.MVVM;
using tscui.Pages;
using tscui.Pages.Music;

namespace tscui.ViewModels
{
    /// <summary>
    /// The MusicViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class ModuleViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicViewModel"/> class.
        /// </summary>
        public ModuleViewModel()
        {
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_module"];
        }

    }
}
