﻿using SamplePersonalStandard.Core.BuildingBlocks;

namespace SamplePersonalStandard.Core.Rules
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class MinimumAmountOfASingleOrderShouldBeAtLeast10 : IBusinessRule
    {
        private readonly decimal _totalPrice;
        public string Code => "minimum_amount_of_a_single_order_should_be_at_least_10";
        public string Message => "The minimum amount of a single order should be at least $10.";

        public MinimumAmountOfASingleOrderShouldBeAtLeast10(decimal totalPrice)
            => _totalPrice = totalPrice;

        public bool IsBroken()
            => _totalPrice >= 10.00m ? false : true;
    }
}
