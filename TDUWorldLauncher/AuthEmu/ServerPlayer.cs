﻿using System.Net;

namespace TDUWorldLauncher.AuthEmu
{
	public class ServerPlayer
	{
		public string Address;
		public int Port;
		public IPEndPoint EndPoint;
		public bool LoginProcess;
		public readonly byte[] Data;
		public bool IsAlive;

		public ServerPlayer(IPEndPoint endPoint)
		{
			this.Data = Data;
			this.LoginProcess = LoginProcess = false;
			this.EndPoint = endPoint;
			this.Address = endPoint.Address.ToString();
			this.Port = endPoint.Port;
			this.IsAlive = false;
		}
	}
}
