using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    internal class Splitter
    {
        public static void SplitterQ()
        {
            // Valueable to hold my objects
            Drink drink;

            // A splitter that acts as a consumer and recieves everything from the previous buffer,
            // and sort the objects by name and pulse the objects out to the next buffers as a producer.
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Program.drinks))
                    {
                        if (Program.drinks.Count == 0)
                        {
                            Monitor.Wait(Program.drinks);
                        }
                        else 
                        {
                            drink = Program.drinks.Dequeue();

                            if (drink.Name == "Beer")
                            {
                                if (Monitor.TryEnter(Program.beers))
                                {
                                    while (Program.beers.Count < 10)
                                    {
                                        Program.beers.Enqueue(drink);
                                        Monitor.PulseAll(Program.beers);

                                    }
                                    
                                    Monitor.Exit(Program.beers);
                                }
                                

                            }
                            else if(drink.Name == "Soda")
                            {
                                if (Monitor.TryEnter(Program.sodas))
                                {
                                    while (Program.sodas.Count < 10)
                                    {
                                        Program.sodas.Enqueue(drink);
                                        Monitor.PulseAll(Program.sodas);

                                    }
                                    //Thread.Sleep(200);
                                    
                                    Monitor.Exit(Program.sodas);
                                }
                            }
                            

                        }
                        Monitor.Exit(Program.drinks);
                    }
                }
                finally
                {
                    Console.Clear();
                    Console.WriteLine("{0} unsorted", Program.drinks.Count);
                    Console.WriteLine("{0} Beers", Program.sodas.Count);
                    Console.WriteLine("{0} Sodas", Program.beers.Count);

                    Thread.Sleep(200);
                    
                }

            }
        }
    }
}
