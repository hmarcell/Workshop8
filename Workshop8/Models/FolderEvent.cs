using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop8.Models
{
    public class FolderEvent
    {
        [Key]
        public string Id { get; set; }
        public string EventType { get; set; } //modify delete create stb.
        public DateTime EventDate { get; set; }
        public string FolderPath { get; set; }
        public FolderEvent()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
