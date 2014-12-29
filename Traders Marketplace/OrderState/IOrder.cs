using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderState
{
    public interface IOrder
    {
        void NewOrderPlaced();
        string Register();
        string Dispatch();
        string Approve();
    } 
}
