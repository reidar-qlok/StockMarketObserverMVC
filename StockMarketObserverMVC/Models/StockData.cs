namespace StockMarketObserverMVC.Models
{
    public class StockData : ISubject
    {
        // Lista för att hålla registrerade observers
        private List<IObserver> observers;
        // Håller aktiepriser med aktiesymbol
        private Dictionary<string, double> stockPrices;
        // Initierar allt ovanför
        public StockData()
        {
            observers = new List<IObserver>();
            stockPrices = new Dictionary<string, double>();
        }
        // Metod för att registrera en observer
        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        // Metod för att ta bort en observer
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Metod för att notifiera alla observers om en förändring
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                foreach (var stock in stockPrices)
                {
                    // Uppdaterar varje observer med den aktuella aktiens symbol och pris
                    observer.Update(stock.Key, stock.Value);
                }
            }
        }

        // Metod för att sätta aktiepriset och notifiera observers om förändringen
        public void SetStockPrice(string stockSymbol, double stockPrice)
        {
            stockPrices[stockSymbol] = stockPrice;
            NotifyObservers();
        }
        public Dictionary<string, double> GetStockPrices()
        {
            return stockPrices;
        }
    }
}
