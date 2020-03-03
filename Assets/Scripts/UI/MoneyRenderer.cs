using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MoneyRenderer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _moneyText;

    private void Start()
    {
        _player.TakeMoney += WriteMoney;
    }

    public void WriteMoney(int money)
    {
        _moneyText.text = money.ToString();
    }
}
