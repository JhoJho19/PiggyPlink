using ProgressAndDataNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusesController : MonoBehaviour
{
    public static bool IsDoubleBallBonus;
    public static bool IsDoubleCoinsBonus;
    public static bool IsFasterBonus;
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] Button _doubleCoinsButton;
    [SerializeField] Button _doubleBallButton;
    [SerializeField] Button _fasterButton;
    [SerializeField] TextMeshProUGUI ballBonusesCount;
    [SerializeField] TextMeshProUGUI coinsBonusesCount;
    [SerializeField] TextMeshProUGUI fasterBonusesCount;

    private void OnEnable()
    {
        RefreshBonusCounter();
    }

    public void RefreshBonusCounter()
    {
        ballBonusesCount.text = ProgressData.DoubleBalls.ToString();
        coinsBonusesCount.text = ProgressData.DoubleCoins.ToString();
        fasterBonusesCount.text = ProgressData.FasterBonus.ToString();

        if (ProgressData.DoubleCoins <= 0)
            _doubleCoinsButton.interactable = false;
        else
            _doubleCoinsButton.interactable = true;

        if (ProgressData.DoubleBalls <= 0)
            _doubleBallButton.interactable = false;
        else
            _doubleBallButton.interactable = true;

        if (ProgressData.FasterBonus <= 0)
            _fasterButton.interactable = false;
        else
            _fasterButton.interactable = true;
    }

    public void DoubleBallBonus()
    {
        IsDoubleBallBonus = true;

        ProgressData.DoubleBalls--;
        RefreshBonusCounter();
    }

    public void DoubleCoinsBonus()
    {
        ProgressData.DoubleCoins--;
        RefreshBonusCounter();
        IsDoubleCoinsBonus = true;
        _doubleCoinsButton.interactable = false;
        StartCoroutine(DoubleCoinsBonusCor());
    }

    IEnumerator DoubleCoinsBonusCor()
    {
        yield return new WaitForSeconds(5f);
        IsDoubleCoinsBonus = false;
        _doubleCoinsButton.interactable = true;
    }

    public void Faster()
    {
        ProgressData.FasterBonus--;
        RefreshBonusCounter();
        IsFasterBonus = true;
        _fasterButton.interactable = false;
        StartCoroutine(FasterCor());
    }

    IEnumerator FasterCor()
    {
        yield return new WaitForSeconds(10f);
        IsFasterBonus = false;
        _fasterButton.interactable = true;
    }

    public void SpawnDoubleBall(Vector2 position)
    {
        if (!IsDoubleBallBonus)
            return;

        Instantiate(
            _ballPrefab,
            new Vector3(position.x, position.y, 0f),
            Quaternion.identity
        );

        IsDoubleBallBonus = false;
    }
}
