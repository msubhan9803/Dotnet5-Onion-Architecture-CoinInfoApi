using System;

namespace Domain.Dtos
{
    public class CoinUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Current_price { get; set; }
        public double Market_cap { get; set; }
        public double Market_cap_rank { get; set; }
        public double Total_volume { get; set; }
        public double High_24h { get; set; }
        public double Low_24h { get; set; }
        public double Price_change_24h { get; set; }
        public double Market_cap_change_24h { get; set; }
        public double Market_cap_change_percentage_24h { get; set; }
        public double Circulating_supply { get; set; }
        public DateTime Last_updated { get; set; }
        public DateTime Created_on { get; set; }
    }
}