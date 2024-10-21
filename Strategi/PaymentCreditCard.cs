namespace EstudiesDocker.Strategi
{
    public class PaymentCreditCard : IPaymentStrategy
    {
        public void Payment(decimal price)
        {
            Console.WriteLine("Payment with credit card with value of: " + price);
        }
    }
}
