using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerpollService.DataObjects
{
    public class Poll : EntityData
    {
        public Poll()
        {
            Results = new List<Result>();
        }

        public DateTime End_Time { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}