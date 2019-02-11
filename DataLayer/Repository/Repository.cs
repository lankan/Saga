using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Helpers;

namespace DataLayer.Models
{
    public class Repository : IRepository
    {
        public List<Basket> getAllBaskets()
        {
            return GetAll();
        }
        public Basket getBasketById(string transactionId)
        {
            List<Basket> allbookings = GetAll();

            return allbookings.FirstOrDefault(x => x.TransactionNumber == transactionId);
        }

        private List<Basket> GetAll()
        {
            string UserDirectory = @"../DataLayer/Data/baskets.csv";

            List<Basket> lines = File.ReadAllLines(UserDirectory)
                            .Skip(1)
                            .Select(x => SagaHelpers.FromCSV(x))
                            .OrderByDescending(x => x.CreatedDateTime)
                            .ToList();
            return lines;
        }
    }
}
