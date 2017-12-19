﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF.BackTesting {
	public abstract class PriceReader {
		private List<PriceItem> prices;

		public PriceReader() {
			prices = new List<PriceItem>();
		}

		public event EventHandler<NewPriceEventArgs> NewPrice;

        //-- event NewPrice ไม่สืบทอดไปหาลูก --
        //-- แก้ไขโดยให้ ลูกสามารถส่ง Events มาที่แม่ แล้วให้แม่ ส่ง  Events ออกไป
        //-- ตอนลุกใช้ RaiseNewPrice(p); 
        protected void RaiseNewPrice(PriceItem item) {
			NewPrice?.Invoke(this, new NewPriceEventArgs(item));
		}

		public void AddSeedPrice(decimal last) {
			AddSeedPrice(DateTime.Now, last, 0m, 0m);
		}

		public void AddSeedPrice(DateTime date, decimal last,
								 decimal bid, decimal offer) {
			var item = new PriceItem {
				Date = date,
				Last = last,
				Bid = bid,
				Offer = offer
			};
			prices.Add(item);
		}

		public virtual void Start() {
			foreach (var p in prices) {
				var e = new NewPriceEventArgs(p);
				NewPrice?.Invoke(this, e);
			}
		}
	}
}