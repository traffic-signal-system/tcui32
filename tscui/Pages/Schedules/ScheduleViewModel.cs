
using Apex.MVVM;

namespace tscui.Pages.Schedules
{
    /// <summary>
    /// The CountDownViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class ScheduleViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        public ScheduleViewModel()
        {
            //  TODO: Use the following snippets to help build viewmodels:
            //      apexnp - Creates a Notifying Property
            //      apexc - Creates a Command.
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_schedule"];

        }



    }
}
