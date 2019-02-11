using System.Collections.Generic;

namespace DataLayer.Models
{
    public interface IRepository
    {
        List<Basket> getAllBaskets();
        Basket getBasketById(string transactionId);
    }
}