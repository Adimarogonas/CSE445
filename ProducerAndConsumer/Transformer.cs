using System;
namespace ProducerAndConsumer
{
    public class Transformer
    {
        public static Program.numberProcessedEvent numberProcessed;
        public Transformer(int val)
        {
            
        }
        public void transform(double val)
        {
            double value = Math.Pow(val, 2);
            numberProcessed(Double value);
        }
        
    }
}
