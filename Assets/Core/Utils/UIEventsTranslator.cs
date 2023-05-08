using System;
using System.Collections.Generic;
using UI.Data;
using UnityEngine;

namespace UI
{
    public class UIEventsTranslator
    {
        private static readonly Dictionary<string, Action> eventsList = new();
        private static readonly Dictionary<string, Action<ISendData>> eventsDataList = new();

        public static void AddListener(string key, Action func)
        {
            if (!eventsList.ContainsKey(key))
                eventsList.Add(key, func);
            else
                eventsList[key] += func;
        }

        public static void AddListener(string key, Action<ISendData> func)
        {
            if (!eventsDataList.ContainsKey(key))
                eventsDataList.Add(key, func);
            else
                eventsDataList[key] += func;
        }

        public static void RemoveAllListeners()
        {
            eventsList.Clear();
            eventsDataList.Clear();
        }

        public static void Call(string key)
        {
            foreach (KeyValuePair<string, Action> item in eventsList)
            {
                if (item.Key == key) 
                    item.Value.Invoke();
            }
        }

        public static void Call(string key, ISendData data)
        {
            foreach (KeyValuePair<string, Action<ISendData>> item in eventsDataList)
            {
                if (item.Key == key) 
                    item.Value.Invoke(data);
            }
        }

        public static string GetKey(string type, string tag = "") => 
            type + tag;
    }
}