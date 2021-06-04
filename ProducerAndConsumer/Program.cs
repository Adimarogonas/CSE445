using System;
using System.Threading;

namespace ProducerAndConsumer
{
    class Program
    {
        public delegate void numberCreatedEvent();
        public delegate void numberProcessedEvent(double Value);
        public static SharedResourceBuffer res;
        public static Producer prod;
        public static Consumer cons;
        public static Transformer proc;
        static Thread[] consumers;
       
        
        static void Main(string[] args)
        {
            //init
            res = new SharedResourceBuffer();
            prod = new Producer();
            cons = new Consumer();
            proc = new Transformer();
            consumers = new Thread[3];


            //Event Setup
            //to add subscriber [Classname] [Event] += new [EventType]([classInstance.handler])
            Producer.numCre += new numberCreatedEvent(cons.numberCreatedHandler);
            Transformer.numberProcessed += new numberProcessedEvent(cons.numberProcessedHandler);

            //thread setup
            Thread Producer = new Thread(new ThreadStart(prod.producerThread));

            Producer.Start();
            for(int i=0; i<3; i++)
            {
                consumers[i] = new Thread(new ThreadStart(cons.consumerThread));
                consumers[i].Name = (i + 1).ToString();
                consumers[i].Start();
            }

        }
    }
}
