using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using GCProject.Miscellanies;
using Newtonsoft.Json;

namespace GCProject.ClientService
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
            //_client = new TcpClient();
        }

        /// <summary>
        /// Connects asynchronously to a pre-defined address
        /// </summary>
        /// <returns>whether connection succeeded</returns>
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

        private async Task<bool> WriteAllBytesAsync(byte[] buffer)
        {
            try
            {
                await _ns.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sends a request asynchronously
        /// </summary>
        /// <param name="jsonRequest">a json formatted string</param>
        /// <returns>whether the request was sent</returns>
        private async Task<bool> SendRequestAsync(string jsonRequest)
        {
            bool hasConnected = await ConnectAsync();
            if (!hasConnected)
            {
                return false;
            }

            _ns = _client.GetStream();
            byte[] bufferBytes = jsonRequest.GetStringAsBytes();

            return await WriteAllBytesAsync(bufferBytes);
        }

        /// <summary>
        /// Receives a response from the server asynchronously
        /// </summary>
        /// <param name="responseSize">default response size</param>
        /// <returns>the received response</returns>
        private async Task<string> ReceiveResponseAsync(int responseSize = 4096)
        {
            byte[] bufferBytes = new byte[responseSize];
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
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();

            Console.WriteLine("Sending request:\n{0}", jsonRequest);
            using (_client = new TcpClient())
            {
                bool hasSent = await SendRequestAsync(jsonRequest);
                if (!hasSent)
                {
                    responseDictionary["Status"] = "Error";
                    return JsonConvert.SerializeObject(responseDictionary);
                }

                string response = await ReceiveResponseAsync();
                Close();

                return response;
            }
        }
    }
}
