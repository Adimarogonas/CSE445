using System;
namespace ProducerAndConsumer
{
    public class Consumer
    {
        public Consumer()
        {
            
        }
        public void consumerThread()
        {
            while (Program.prod.count < 20)
            {
                Thread.Sleep(2000);
            }
        }

        public void numberCreatedHandler()
        {
            number = res.getVal();
            Thread transFormerThread = new Thread(() => Transformer.transform(numberCreatedHandler()));

        }
        public void numberProcessedHandler(Double val) => Console.WriteLine("{0}", val);
    }
}
