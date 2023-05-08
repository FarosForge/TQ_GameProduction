
using Save;

namespace Global.Wallet
{
    public class GoldCurrency : Currency
    {
        private const int maxPrice = 1000;
        public GoldCurrency(int currentValue, SaveSystem saveSystem)
        {
            Init(currentValue, maxPrice, CurrencyCountType.Infinite, saveSystem);
        }
    }
}