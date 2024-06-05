namespace StockMarketObserverMVC.Models
{
    public interface IObserver
    {
        void Update(string stockSymbol, double stockPrice);
    }
}
