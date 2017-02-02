using SlackAPI;
using SlackRTMBot.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlackRTMBot
{
    public class SlackApiStartup : IDisposable
    {
        ManualResetEventSlim clientReady = new ManualResetEventSlim(false);
        SlackClient Client = new SlackClient(Settings.Default.SlackToken);
        SlackSocketClient SocketClient = new SlackSocketClient(Settings.Default.SlackToken);

        public void Dispose()
        {
            
        }

        public void Start()
        {
            this.Client.Connect((x) => { Console.WriteLine("Connected to Event Server"); });
            this.SocketClient.Connect((x) => { this.clientReady.Set(); }, () => { Console.WriteLine("Connected to Socket Instance"); });
            this.Configure();
        }

        private void Configure()
        {
            this.SocketClient.OnMessageReceived += SocketClient_OnMessageReceived;
        }

        private void SocketClient_OnMessageReceived(SlackAPI.WebSocketMessages.NewMessage obj)
        {
            throw new NotImplementedException();
        }
    }
}
