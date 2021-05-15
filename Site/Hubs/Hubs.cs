using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
	[Authorize]
	public class Hubs : Hub
	{
		UserManager<IdentityUser> _um;
		public Hubs(UserManager<IdentityUser> um)
		{
			_um = um;
		}

		public async Task SendMessage(String userId, String message)
		{
			await Clients.All.SendAsync("ReceiveMessage", userId, message);
		}

		public async override Task OnConnectedAsync()
		{
			IdentityUser user = await _um.GetUserAsync(Context.User);
			String cid = Context.ConnectionId;

			await Clients.All.SendAsync("UserAdded", user.Email);
			await base.OnConnectedAsync();
		}

		public async override Task OnDisconnectedAsync(Exception exception)
		{
			IdentityUser user = await _um.GetUserAsync(Context.User);
			String cid = Context.ConnectionId;
			await base.OnDisconnectedAsync(exception);
		}
	}
}