using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementSystem.Models
{
    public class AddNewPublicMixModel
    {
        public IEnumerable<w_system_params> Params { get; set; }
        public IEnumerable<w_facilities> Facilities { get; set; }
    }
}