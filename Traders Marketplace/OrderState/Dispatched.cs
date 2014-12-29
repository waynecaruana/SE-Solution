﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderState
{
    public class Dispatched : IOrder
    {
        private readonly Order _Parent;
        public void NewOrderPlaced()
        {
            throw new Exception("OrderState has already been placed");
        }
        public Dispatched(Order OrderState)
        {
            _Parent = OrderState;
            this.Dispatch();
        }
        public string Dispatch()
        {
            return "Dispatched";
        }
        public string Register()
        {
            throw new Exception("OrderState has already been registered");
        }
        public string Approve()
        {
            _Parent._CurrentState = new Approved(_Parent);
            return _Parent._CurrentState.Approve();
        }
    } 
}
