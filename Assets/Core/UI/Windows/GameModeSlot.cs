using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
