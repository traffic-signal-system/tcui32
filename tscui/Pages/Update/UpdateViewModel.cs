namespace tscui.Pages.Update
{
    /// <summary>
    /// The TheShellViewModel ViewModel class.
    /// </summary>
    public class UpdateViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheShellViewModel"/> class.
        /// </summary>
        public UpdateViewModel()
        {
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_update"];

            //  Create the show popup command. It actually won't do anything in the 
            //  view model, but a view can still handle it.
           ///ShowPopupCommand = new Command(() => { });
        }

    }
}
