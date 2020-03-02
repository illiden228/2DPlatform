using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyRenderer : MonoBehaviour
{
    public TMP_Text MoneyText;

    public void WriteMoney(int money)
    {
        MoneyText.text = money.ToString();
    }
}
