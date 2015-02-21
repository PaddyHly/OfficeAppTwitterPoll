using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerpollService.DataObjects
{
    public class PollResults : EntityData
    {
        public string PollResultsId { get; set; }
        [ForeignKey("Poll")]
        public string PollId { get; set; }
        public int count { get; set; }

        public virtual Poll Poll { get; set; }
    }
}