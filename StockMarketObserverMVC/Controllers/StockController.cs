using Microsoft.AspNetCore.Mvc;
using StockMarketObserverMVC.Display;
using StockMarketObserverMVC.Models;

namespace StockMarketObserverMVC.Controllers
{
    public class StockController : Controller
    {
        // Statisk variabel för att hålla instansen av StockData
        private static StockData stockData;

        // Statisk konstruktor för att initiera StockData och registrera observatörer
        static StockController()
        {
            stockData = new StockData();
            var display = new StockDisplay();
            stockData.RegisterObserver(display);

            // Initiera några standardvärden för aktiepriser för teständamål
            stockData.SetStockPrice("OMX Stockholm", 350.00);
            stockData.SetStockPrice("OSEBX Oslo", 250.00);
            stockData.SetStockPrice("OMX Helsinki", 150.00);
        }

        // Action-metod för att returnera Index-vyn med modellen stockData
        public IActionResult Index()
        {
            return View(stockData);
        }

        // Action-metod för att hantera formulärinlämning för att uppdatera aktiepriser
        [HttpPost]
        public IActionResult UpdateStockPrice(string stockSymbol, double stockPrice)
        {
            // Uppdatera aktiepriset i stockData
            stockData.SetStockPrice(stockSymbol, stockPrice);
            // Omdirigera till Index-metoden för att visa den uppdaterade datan
            return RedirectToAction("Index");
        }
    }
}
