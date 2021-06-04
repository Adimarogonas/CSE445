using System;
using System.Threading;

namespace ProducerAndConsumer
{
    public class SharedResourceBuffer
    {
        private static Semaphore read_pool;
        private static Semaphore write_pool;
        private int[] numberBuffer;
        int cellsUsed = 0;
        public SharedResourceBuffer()
        {
            lock (this)
            {

                //initialize variables
                read_pool = new Semaphore(3, 3);
                write_pool = new Semaphore(3, 3);
                cellsUsed = 0;
                numberBuffer = new int[3];

                for(int i=0; i<3; i++)
                {
                    numberBuffer[i] = 0;
                }

            }


        }

        public void setValue(int val)
        {
            write_pool.WaitOne();
            lock (this)//Monitor can only be used in the event that the object in question has the lock
            {
                while(cellsUsed == 3)
                {
                    Monitor.Wait(this);
                }
                for(int i=0; i<3; i++)
                {
                    if(numberBuffer[i] == 0)
                    {
                        numberBuffer[i] = val;
                        cellsUsed++;
                    }
                }
                write_pool.Release();//If you put something into the semaphore it has to come out
                Monitor.PulseAll(this);
            }
        }

        public int getVal()
        {
            int returnVal = 0;
            read_pool.WaitOne();
            lock(this)
            {
                while(cellsUsed == 0)//Making the thread wait on this condition prevents behavior
                {
                    Monitor.Wait(this);
                }
                for(int i=0; i<3; i++)
                {
                    if(numberBuffer[i] != 0)
                    {
                        returnVal = numberBuffer[i];
                    }
                }
                read_pool.Release();
                Monitor.Pulse(this);

            }
            return returnVal;
        }

    }
}
