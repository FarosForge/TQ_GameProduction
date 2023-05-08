using System.Collections;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;

public class WalletUIData : ISendData
{
    public int value;

    public WalletUIData(int value)
    {
        this.value = value;
    }
}
