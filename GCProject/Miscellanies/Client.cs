using System;
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

		private void Close()
		{
			if (_client.Connected)
			{
				_client.Close();
				_ns.Close();
			}
		}

		public Client()
		{
			_client = new TcpClient();
		}

		private async Task ConnectAsync()
		{
			await _client.ConnectAsync(IPAddress.Parse(Ip), Port);
		}

		private async Task WriteAllBytesAsync(byte[] buffer)
		{
			await _ns.WriteAsync(buffer, 0, buffer.Length);
		}

		private async Task SendRequestAsync(string jsonRequest)
		{
			await ConnectAsync();
			_ns = _client.GetStream();
			byte[] bufferBytes = jsonRequest.GetStringAsBytes();

			await WriteAllBytesAsync(bufferBytes);
		}

		private async Task<string> ReceiveResponseAsync()
		{
			byte[] bufferBytes = new byte[4096];
			await _ns.ReadAsync(bufferBytes, 0, bufferBytes.Length);

			return bufferBytes.GetBytesAsString();
		}

		/// <summary>
		/// Sends a request to the server and gets the response
		/// </summary>
		/// <param name="jsonRequest">a json formatted string request</param>
		/// <returns>the server's response</returns>
		public async Task<string> SendAndReceiveAsync(string jsonRequest)
		{
			return await Task.Run(async () =>
			{
				await SendRequestAsync(jsonRequest);
				string response = await ReceiveResponseAsync();

				Close();
				return response;
			});
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
