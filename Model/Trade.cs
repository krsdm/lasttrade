using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    internal class Trade
    {
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public TradeDirection Direction { get; set; }
        public DateTime Time { get; set; }


        public Trade(decimal price, int volume)
        {
            Price = price;
            Volume = volume;
            Direction = Volume > 0 ? TradeDirection.LONG : TradeDirection.SHORT;
            Time = DateTime.Now;
        }
    }
}
