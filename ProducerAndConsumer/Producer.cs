using System;
using System.Threading;

namespace ProducerAndConsumer
{
    public static event Program.numberCreatedEvent numCre;
    public class Producer
    {
        public int count = 0;
        public Producer()
        {

        }

        public void producerThread()//Designate a thread method
        {
            while(count != 20)
            {
                count++;
                Program.Resources.setValue(count);
                numCre();
                Thread.Sleep(1000);
            }
        }
    }
}
