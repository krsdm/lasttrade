using MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    internal class TradeViewModel: INotifyPropertyChanged
    {
        private decimal _price;
        private int _volume;
        private TradeDirection _direction;
        private DateTime _time;
        private string _serverStatus;
        private ExchangeServer _exchangeServer;

        public decimal Price { 
            get { return _price; }
            set { _price = value; OnPropertyChanged(); } 
        }
        public int Volume { 
            get { return _volume; }
            set { _volume = value; OnPropertyChanged(); }
        }
        public TradeDirection Direction { 
            get { return _direction; }
            set { _direction = value; OnPropertyChanged(); }
        }
        public DateTime Time { 
            get { return _time; }
            set { _time = value; OnPropertyChanged(); }
        }
        public string ServerStatus { 
            get { return _serverStatus; } 
            set { _serverStatus = value; OnPropertyChanged(); }
        }

        public TradeViewModel()
        {
            _exchangeServer = new ExchangeServer();
            _exchangeServer.NewTradeEvent += NewTradeHandler;
        }

        public void StartExchangeServer()
        {
            _exchangeServer.Start();
            ServerStatus = ExchangeServer.ConnectedStatus;
        }

        public void StopExchangeServer()
        {
            _exchangeServer.Stop();
            ServerStatus = ExchangeServer.DisconnectedStatus;
        }


        // Событие для уведомления об изменении свойства
        // PropertyChangedEventHandler встроеный делегат для обработки событий изменения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        // Инициирует событие PropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Обработчик события новой сделки NewTradeEvent
        private void NewTradeHandler(Trade trade)
        {
            Price = trade.Price;
            Volume = trade.Volume;
            Direction = trade.Direction;
            Time = trade.Time;
        }

    }
}
