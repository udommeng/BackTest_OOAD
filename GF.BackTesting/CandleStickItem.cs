using System;

namespace GF.BackTesting {
    public class CandleStickItem {

        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Close { get; set; }
        public decimal Low { get; set; }
        public CandleStickColor Color { get; set; }

    }
}