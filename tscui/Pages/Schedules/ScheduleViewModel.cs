
using System.Collections.Generic;
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
            Title =  (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_schedule"];
           
            SetControlList();
        }

        private List<ScheduleViewModel.ScheduleCtrl> _lsc = new List<ScheduleViewModel.ScheduleCtrl>() ;

        public List<ScheduleViewModel.ScheduleCtrl> Lsc
        {
            get { return _lsc; }
            set { _lsc = value; }
        }

        public class ScheduleCtrl
        {
           public string name { get; set; }
           public byte value { get; set; }
       }
         string selfcontrol = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_self_control"];
            string off = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_off"];
            string flashing = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_flashing"];
            string allred = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_allred"];
            string reaction = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_reaction"];
            string secondreaction = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_secondreaction"];
            string gpscoordination = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_gpscoordination"];
            string one = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_self_one"];
            string maincoordination = (string)App.Current.Resources.MergedDictionaries[3]["dic_maincoordination"];
            string system = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_system"];
            string manual = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_manual"];
            string PreAnalysis = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_PreAnalysis"];

           

        private void SetControlList()
        {
            _lsc.Add(new ScheduleCtrl() { name = selfcontrol, value = (byte)0 });
            _lsc.Add(new ScheduleCtrl() { name = off, value = (byte)1 });
            _lsc.Add(new ScheduleCtrl() { name = flashing, value = 2 });
            _lsc.Add(new ScheduleCtrl() { name = allred, value = 3 });
            _lsc.Add(new ScheduleCtrl() { name = reaction, value = 6 });
            _lsc.Add(new ScheduleCtrl() { name = secondreaction, value = 5 });
            _lsc.Add(new ScheduleCtrl() { name = gpscoordination, value = 7 });
            //  lsc.Add(new ScheduleCtrl() { name = one, value = 8 });
            _lsc.Add(new ScheduleCtrl() { name = maincoordination, value = 11 });
            _lsc.Add(new ScheduleCtrl() { name = system, value = 12 });
            _lsc.Add(new ScheduleCtrl() { name = manual, value = 13 });
            _lsc.Add(new ScheduleCtrl() { name = PreAnalysis, value = 9 });
        }

    }
}
