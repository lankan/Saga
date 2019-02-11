using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace DataLayer
{

    public class Basket : IBasket
    {
        public Basket()
        {
        }
        public string TransactionNumber { get; set; }
        public int? NumberOfPassengers { get; set; }
        public int? Domain { get; set; }
        public int? AgentId { get; set; }
        public string ReferrerUrl { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string UserId { get; set; }
        public string SelectedCurrency { get; set; }
        public string ReservationSystem { get; set; }

    }

    //enum domain
    //{

    //    // all the domain items
    //}

    //enum ReservationSystem
    //{

    //    // all the ReservationSystems
    //}
}