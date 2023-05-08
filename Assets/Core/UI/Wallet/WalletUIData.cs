using UI.Data;

namespace UI
{
    public class WalletUIData : ISendData
    {
        public int value;

        public WalletUIData(int value)
        {
            this.value = value;
        }
    }
}