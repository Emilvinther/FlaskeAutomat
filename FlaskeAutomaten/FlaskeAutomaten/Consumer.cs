using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    internal class Consumer
    {

        // Beer consumer method that recieve and dequeues if there is any beers in the queue
        public static void BeerConsumer()
        {
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Program.beers))
                    {
                        if (Program.beers.Count == 0)
                        {
                            Monitor.Wait(Program.beers);
                        }
                        else
                        {
                            Program.beers.Dequeue();
                        }
                        Monitor.Exit(Program.beers);
                    }
                }
                finally
                {

                    Thread.Sleep(200);

                }
            }
        }

        // Soda consumer method that recieve and dequeues if there is any soda in the queue
        public static void SodaComsumer()
        {
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Program.sodas))
                    {
                        if (Program.sodas.Count == 0)
                        {
                            Monitor.Wait(Program.sodas);
                        }
                        else
                        {
                            Program.sodas.Dequeue();
                        }
                        Monitor.Exit(Program.sodas);
                    }
                }
                 finally
                {

                    Thread.Sleep(200);
                }
            }
        }

    }
}
