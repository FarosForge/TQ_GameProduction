using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameModeSlot : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buttonText;

        public void SetData(int val, Action action)
        {
            buttonText.text = val.ToString();
            button.onClick.AddListener(() => action());
        }
    }
}