using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.SignalRSelfHost.Hubs
{

    public class JobsHub : Hub
    {
        public override Task OnConnected()
        {

            this.Groups.Add(this.Context.ConnectionId, "Gdynia");this.Context.
        //    this.Context
            return base.OnConnected();
        }

        public void Send(string message)
        {
            this.Clients.Others.SendMessage(message);

            this.Clients.Group()
        }

        public void Ping()
        {
            this.Clients.Caller.Pong();


        }
    }

}
