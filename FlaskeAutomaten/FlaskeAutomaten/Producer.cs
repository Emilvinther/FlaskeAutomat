using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    internal class Producer
    {
        // Drinks generator, its generated in a random and added to the buffer
        public static void ProducerQ()
        {
            Random random = new Random();
            int rando;

            while (true)
            {
                Monitor.Enter(Program.drinks);
                try
                {
                    if (Program.drinks.Count < 3)
                    {

                    
                    while (Program.drinks.Count < 10)
                    {
                        rando = random.Next(1, 5);

                        if (rando == 1 || rando == 2)
                        {
                            Program.drinks.Enqueue(new Soda("Soda"));
                        }
                        else if (rando == 3 || rando == 4)
                        {
                            Program.drinks.Enqueue(new Beer("Beer"));
                        }
                        Monitor.PulseAll(Program.drinks);
                    }

                    }
                }
                finally
                {
                    
                    Monitor.Exit(Program.drinks);
                    Thread.Sleep(200);
                   
                }


            }
        }
    }
}
