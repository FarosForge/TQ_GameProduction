using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Global.Wallet
{
    public class Wallet
    {
        private Dictionary<CurrencyType, Currency> wallets = new Dictionary<CurrencyType, Currency>();

        public void Init(SaveSystem saveSystem)
        {
            CreateCurrency(saveSystem);
        }

        private void CreateCurrency(SaveSystem saveSystem)
        {
            wallets.Add(CurrencyType.Gold, new GoldCurrency(saveSystem.data.Currency, saveSystem));
        }

        public Currency GetCurrency(CurrencyType type)
        {
            return wallets[type];
        }
    }

    public enum CurrencyType
    {
        Gold
    }
}