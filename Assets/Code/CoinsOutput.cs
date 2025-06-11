using ProgressAndDataNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsOutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] int targetAmount;
    [SerializeField] Image progressBar;
    [SerializeField] GameObject winScreen;

    private void Start()
    {
        UpdateCoinCounter();
    }

    public void UpdateCoinCounter()
    {
        coinsText.text = ProgressData.GoldCoinCounter.ToString();

        if (progressBar && targetAmount > 0)
        {
            progressBar.fillAmount = Mathf.Clamp01((float)ProgressData.GoldCoinCounter / targetAmount);
            if (winScreen != null && progressBar.fillAmount >= 1)
            {
                winScreen.gameObject.SetActive(true);
                this.enabled = false;
            }
        }

        if (ProgressData.GoldCoinCounter <= 0)
        {
            ProgressData.GoldCoinCounter = 100;
            coinsText.text = ProgressData.GoldCoinCounter.ToString();
        }
    }
}
