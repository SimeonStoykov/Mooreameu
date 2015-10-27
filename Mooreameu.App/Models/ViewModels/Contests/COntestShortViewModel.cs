namespace Mooreameu.App.Models.ViewModels.Contests
{
    using System;

    public class ContestShortViewModel
    {
        public int ContestId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}