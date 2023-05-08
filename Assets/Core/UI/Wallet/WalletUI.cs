using TMPro;
using UI.Data;
using UnityEngine;

namespace UI
{
    public class WalletUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currencyText;

        public void SetData(ISendData data)
        {
            switch (data)
            {
                case WalletUIData wallet:
                    currencyText.text = wallet.value.ToString();
                    break;
            }
        }
    }
}