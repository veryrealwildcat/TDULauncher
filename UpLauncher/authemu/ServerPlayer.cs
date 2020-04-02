using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UpLauncher.authemu
{
	public class ServerPlayer
	{
		public string address;
		public int port;
		public IPEndPoint endPoint;
		public bool loginProcess;
		public byte[] data;
		public bool IsAlive;

		public ServerPlayer(IPEndPoint endPoint)
		{
			this.data = data;
			this.loginProcess = loginProcess = false;
			this.endPoint = endPoint;
			this.address = endPoint.Address.ToString();
			this.port = endPoint.Port;
			this.IsAlive = false;
		}
	}
}
