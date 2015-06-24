using Apex.MVVM;
namespace tscui.Pages.Stage
{
    /// <summary>
    /// The StageViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class StageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StageViewModel"/> class.
        /// </summary>
        public StageViewModel()
        {
            //  TODO: Use the following snippets to help build viewmodels:
            //      apexnp - Creates a Notifying Property
            //      apexc - Creates a Command.
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_stage"];
        }



    }
}
