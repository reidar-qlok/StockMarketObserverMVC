using StockMarketObserverMVC.Models;

namespace StockMarketObserverMVC.Display
{
    public class StockDisplay : IObserver
    {
        private string stockSymbol;
        private double stockPrice;
        public void Update(string stockSymbol, double stockPrice)
        {
            // Uppdaterar fält med ny data
            this.stockSymbol = stockSymbol;
            this.stockPrice = stockPrice;
            //Anropa display metoden för att visa ny data
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Stock: {stockSymbol}, Price: {stockPrice}");
        }
    }
}
