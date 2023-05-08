using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Global.Wallet
{
    public abstract class Currency
    {
        public Action<int> OnAddedCurrencyValue;
        public Action<int> OnRemovedCurrencyValue;

        private int value = 0;
        private int maxPrice = 0;
        private int maxValue = 0;
        private CurrencyCountType type;
        private SaveSystem saveSystem;

        public bool canTransaction { get; private set; }

        public int GetValue()
        {
            return value;
        }

        public virtual void Init(int currentValue, int maxPrice, CurrencyCountType type, SaveSystem saveSystem, int maxValue = 0)
        {
            value = currentValue;
            this.maxPrice = maxPrice;
            this.type = type;
            this.maxValue = maxValue;
            this.saveSystem = saveSystem;
            OnAddedCurrencyValue += AddToValue;
            OnRemovedCurrencyValue += RemoveFromValue;
        }

        protected virtual void AddToValue(int val)
        {
            if (val > maxPrice)
            {
                Debug.LogError("This value is not correct to maxPrice");
                canTransaction = false;
                return;
            }

            if(type == CurrencyCountType.Maxible)
            {
                if(value == maxValue)
                {
                    canTransaction = false;
                    return;
                }

                if(value + val > maxValue)
                {
                    value = maxValue;
                    canTransaction = true;
                    return;
                }
            }

            canTransaction = true;
            value += val;

            saveSystem.Save();
        }

        protected virtual void RemoveFromValue(int val)
        {
            if (value - val < 0)
            {
                Debug.LogError("This value is not correct");
                canTransaction = false;
                return;
            }

            canTransaction = true;
            value -= val;

            saveSystem.Save();
        }
    }

    public enum CurrencyCountType
    {
        Maxible,
        Infinite
    }
}