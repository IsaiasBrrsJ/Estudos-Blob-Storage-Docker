namespace EstudiesDocker.Strategi
{
    public class PaymentStrategyContext : IPaymentStrategyContext
    {
        private IPaymentStrategy _strategy = default!;
        public void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Payment(decimal amount)
        {
            _strategy.Payment(amount);
        }
    }
}
