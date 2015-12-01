
using Apex.MVVM;

namespace tscui.Pages.Phase
{
    /// <summary>
    /// The PhaseViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class PhaseViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhaseViewModel"/> class.
        /// </summary>
        public PhaseViewModel()
        {
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_phase"];
            ShowPopupCommandSouthLeft = new Command(DoShowPopupCommandSouthLeft);
            ShowPopupCommandSouthStaight = new Command(DoShowPopupCommandSouthStaight);
            ShowPopupCommandSouthRight = new Command(DoShowPopupCommandSouthRight);
            ShowPopupCommandSouthOther = new Command(DoShowPopupCommandSouthOther);
            ShowFailePopup = new Command(DoShowFailePopup);
             
            
        }

        public Command ShowFailePopup { get; private set; }
        private void DoShowFailePopup()
        { 
        }
       
        public Command ShowPopupCommandSouthLeft { get; private set; }
        private void DoShowPopupCommandSouthLeft()
        {
        }
        public Command ShowPopupCommandSouthStaight { get; private set; }
        private void DoShowPopupCommandSouthStaight()
        {
        }
        public Command ShowPopupCommandSouthRight { get; private set; }
        private void DoShowPopupCommandSouthRight()
        {
        }
        public Command ShowPopupCommandSouthOther { get; private set; }
        private void DoShowPopupCommandSouthOther()
        {
        }
    }
}
