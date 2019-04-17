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
using Newtonsoft.Json;

namespace GCProject.Miscellanies
{
	class Client : INotifyPropertyChanged
	{
		#region members

		private static readonly Client Instance = new Client();
		public static Client INSTANCE => Instance;

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
				_ns.Close();
				_client.Close();
			}
		}

		private Client()
		{
			_client = new TcpClient();
		}

		private async Task<bool> ConnectAsync()
		{
			try
			{
				await _client.ConnectAsync(IPAddress.Parse(Ip), Port);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		private async Task WriteAllBytesAsync(byte[] buffer)
		{
			await _ns.WriteAsync(buffer, 0, buffer.Length);
		}

		private async Task<bool> SendRequestAsync(string jsonRequest)
		{
			bool hasConnected = await ConnectAsync();
			if (!hasConnected)
			{
				return false;
			}
			_ns = _client.GetStream();
			byte[] bufferBytes = jsonRequest.GetStringAsBytes();

			await WriteAllBytesAsync(bufferBytes);
			return true;
		}

		private async Task<string> ReceiveResponseAsync()
		{
			byte[] bufferBytes = new byte[4096];
			int bytesRead = await _ns.ReadAsync(bufferBytes, 0, bufferBytes.Length);
			byte[] res = new byte[bytesRead];
			
			Array.Copy(bufferBytes, res, bytesRead);

			return res.GetBytesAsString();
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
				Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
		
				bool hasSent = await SendRequestAsync(jsonRequest);
				if (!hasSent)
				{
					responseDictionary.Add("Status", "ERROR");
					return JsonConvert.SerializeObject(responseDictionary);
				}

				string response = await ReceiveResponseAsync();
				Close();

				responseDictionary.Add("Status", "OK");
				responseDictionary.Add("Result", response);
				string result = JsonConvert.SerializeObject(responseDictionary);

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
