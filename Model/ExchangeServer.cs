using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MVVM.Model
{
    internal class ExchangeServer
    {
        public const string ConnectedStatus = "Соединение установлено";
        public const string DisconnectedStatus = "";

        private static readonly Random random = new Random();
        private Timer timer = new Timer(1000);

        public ExchangeServer()
        {
            timer.Elapsed += Timer_Elapsed;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var price = random.Next(50000, 60000);
            var volume = random.Next(-9, 9);
            var trade = new Trade(price, volume);
            NewTradeEvent?.Invoke(trade);
        }

        public event Action<Trade> NewTradeEvent;

    }
}
