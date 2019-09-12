using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transformation.ViewModel
{
    public class TopUsers
    {

        public IEnumerable<TrainingUser> Users { get; set; }
        public User User { get; set; }
    }
}