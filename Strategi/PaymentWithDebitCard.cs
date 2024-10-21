namespace EstudiesDocker.Strategi
{
    public class PaymentWithDebitCard : IPaymentStrategy
    {
        public void Payment(decimal price)
        {
            Console.WriteLine("Payment with debit card with value of: "+price);
        }
    }
}
