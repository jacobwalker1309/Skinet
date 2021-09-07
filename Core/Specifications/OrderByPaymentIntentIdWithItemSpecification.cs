using System;
using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderByPaymentIntentIdWithItemSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdWithItemSpecification(string paymentIntentId) 
        : base(o => o.PaymentIntentId == paymentIntentId)
        {

        }
    }
}