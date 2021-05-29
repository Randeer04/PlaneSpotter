using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.ViewModels
{
    public class SightingViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }

        public string Location { get; set; }
        public DateTime SightingDate { get; set; }
    }
}
