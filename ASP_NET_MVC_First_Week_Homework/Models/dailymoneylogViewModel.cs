using Homework.Repository.Entities;
using System;

namespace ASP_NET_MVC_First_Week_Homework.Models
{
    public class dailymoneylogViewModel
    {
        public int SerialNumber { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }//doubl 不要用在有關於錢的 算錢用浮點 遲早被人扁 用浮點計算會少一塊 decimal

        //model為null
        public dailymoneylogViewModel(AccountBook source)
        {
            this.Type = source.Categoryyy > 0 ? "收入" : "支出";
            this.Date = source.Dateee;//無法tostring待解
            this.Amount = source.Amounttt;//無法tostring待解
        }
    }


}