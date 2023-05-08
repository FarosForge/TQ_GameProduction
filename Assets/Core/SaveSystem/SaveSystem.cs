using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Global.Wallet;

public class SaveSystem
{
    private const string SAVEID = "GameProduction";
    public Data data { get; private set; }

    private SessionManager session;

    [Inject]
    public void Construct(SessionManager session)
    {
        this.session = session;
        data = new Data();
    }

    public void Save()
    {
        data.Currency = session.Wallet.GetCurrency(CurrencyType.Gold).GetValue();

        List<ItemData> items = new List<ItemData>();
        foreach (var item in session.ItemsContainer.ResourcesList)
        {
            ItemData it = new ItemData(item.Key, item.Value.Count);
            items.Add(it);
        }

        foreach (var item in session.ItemsContainer.ItemsList)
        {
            ItemData it = new ItemData(item.Key, item.Value.Count);
            items.Add(it);
        }

        data.items = items;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVEID, json);
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey(SAVEID)) return;

        string json = PlayerPrefs.GetString(SAVEID);
        data = JsonUtility.FromJson<Data>(json);
    }
}
