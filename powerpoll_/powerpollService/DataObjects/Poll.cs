using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;

namespace powerpollService.DataObjects
{
    public class Poll : EntityData
    {
        public string PollId { get; set; }
        public DateTime End_Time { get; set; }
    }
}