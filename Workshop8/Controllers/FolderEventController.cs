using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop8.Data;
using Workshop8.Hubs;
using Workshop8.Models;

namespace Workshop8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderEventController : ControllerBase
    {
        IHubContext<EventHub> hub;
        ApiDbContext db;
        UserManager<AppUser> _userManager;

        public FolderEventController(IHubContext<EventHub> hub, ApiDbContext db, UserManager<AppUser> userManager)
        {
            this.hub = hub;
            this.db = db;
            this._userManager = userManager;
        }
        [HttpGet]
        public IEnumerable<FolderEvent> GetFolderEvents()
        {
            return db.FolderEvents;
        }

        [HttpGet("{id}")]
        [Authorize]
        public FolderEvent? GetFolderEvents(string id)
        {
            return db.FolderEvents.FirstOrDefault(t => t.Id == id);
        }

        [Route("[action]")]
        [Authorize]
        [HttpPost]
        public async void AddCar([FromBody] FolderEvent fe)
        {
            var user = _userManager.Users.FirstOrDefault
                (t => t.UserName == this.User.Identity.Name);
            fe.Id = Guid.NewGuid().ToString();
            fe.EventDate = DateTime.Now;

            db.FolderEvents.Add(fe);
            db.SaveChanges();
            await hub.Clients.All.SendAsync("folderEventCreated", fe);
        }
    }
}
