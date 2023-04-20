using FlaskeAutomaten;

internal class Program
{
    // Queue buffers
    public static Queue<Drink> drinks = new();
    public static Queue<Drink> beers = new();
    public static Queue<Drink> sodas = new();
    public static void Main()
    {
        // Threads
        Thread producers = new Thread(Producer.ProducerQ);
        Thread splitter = new Thread(Splitter.SplitterQ);
        Thread beercons = new Thread(Consumer.BeerConsumer);
        Thread sodacons = new Thread(Consumer.SodaComsumer);
        // Thread start
        producers.Start();
        splitter.Start();
        beercons.Start();
        sodacons.Start();


        Console.Read();
    }
}