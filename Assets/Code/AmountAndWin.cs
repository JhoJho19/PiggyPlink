using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ProgressAndDataNamespace;

public class AmountAndWin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI amountText;
    public static int Amount = 10;
    public static int WinAmount;

    private void FixedUpdate()
    {
        winText.text = WinAmount.ToString();
        amountText.text = Amount.ToString();
    }

    public void AmountPlus()
    {
        if(((Amount + 10) <= ProgressData.GoldCoinCounter) && (Amount + 10) <= 110)
            Amount += 10;
    }

    public void AmountMinus()
    {
        if(ProgressData.GoldCoinCounter >= 20)
            Amount = Mathf.Max(0, Amount - 10);
    }
}
