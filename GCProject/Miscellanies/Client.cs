﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GCProject.Annotations;

namespace GCProject.Miscellanies
{
	class Client : INotifyPropertyChanged
	{
		#region members
		private TcpClient _client;
		private NetworkStream _ns;
		private const int Port = 8090;
		private const string Ip = "127.0.0.1";

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void Stop()
		{
			_client.Close();
		}

		//public async void RunAsync()
		//{
		//	try
		//	{
		//		IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(Ip), Port);
		//		_client = new TcpClient(iPEndPoint);

		//		// Enter the listening loop. 
		//		while (true)
		//		{
		//			//State = "Waiting for a connection...";
		//			// wait for a client
		//			TcpClient client = mServer.AcceptTcpClient();

		//			//State = "Client Connected";

		//			// client connected
		//			var res = await GetClientStateAsync(client);
		//			Console.WriteLine("String: " + res.ToString());
		//			State = res;
		//		}
		//	}
		//	catch (SocketException e)
		//	{
		//		Console.WriteLine("SocketException: {0}", e.Message);
		//	}
		//	finally
		//	{
		//		// Stop listening for new clients.
		//		mServer.Stop();
		//	}

		//}
	}
}
