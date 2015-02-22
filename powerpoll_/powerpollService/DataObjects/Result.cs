using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace powerpollService.DataObjects
{
    public class Result : EntityData
    {
        public int Count { get; set; }
        [ForeignKey("Poll")]
        public string PollId { get; set; }
        [JsonIgnore]
        public virtual Poll Poll { get; set; }
    }
}