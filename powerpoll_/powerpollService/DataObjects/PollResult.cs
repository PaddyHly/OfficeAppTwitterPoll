using Microsoft.WindowsAzure.Mobile.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerpollService.DataObjects
{
    public class PollResult : EntityData
    {
        public string keyword { get; set; }
        public int count { get; set; }
        public string PollHashtag { get; set; }
    }
}