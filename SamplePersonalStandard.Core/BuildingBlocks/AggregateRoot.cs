using SamplePersonalStandard.Core.Exceptions;

namespace SamplePersonalStandard.Core.BuildingBlocks
{
    public abstract class AggregateRoot
    {
        protected static void CheckRule(IBusinessRule businessRule)
        {
            if (businessRule.IsBroken())
            {
                throw new BusinessRuleValidationException(businessRule);
            }
        }
    }
}
