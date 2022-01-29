using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public Text coinText;
    int coin;
    private void Awake()
    {
        _instance = this;
    }
    public void CollectCoin()
    {
        coin += 1;
        coinText.text = "Coin: " + coin;
    }
}
