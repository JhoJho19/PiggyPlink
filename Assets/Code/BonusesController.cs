using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusesController : MonoBehaviour
{
    public static bool IsDoubleBallBonus;
    public static bool IsDoubleCoinsBonus;
    public static bool IsFasterBonus;
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] Button _doubleCoinsButton;
    [SerializeField] Button _fasterButton;

    public void DoubleBallBonus()
    {
        IsDoubleBallBonus = true;
    }

    public void DoubleCoinsBonus()
    {
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
