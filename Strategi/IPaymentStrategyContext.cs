namespace EstudiesDocker.Strategi
{
    public interface IPaymentStrategyContext
    {
        void SetStrategy(IPaymentStrategy strategy);

        void Payment(decimal amount);
        
    }
}
