using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UpLauncher.authemu
{
	public class ServerData
	{
		public byte[] datagram;
		public IPEndPoint ipEndPoint;
		public EndPoint endPoint;
		public IPAddress endIPadress;
	}
}
