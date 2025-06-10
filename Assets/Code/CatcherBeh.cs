using ProgressAndDataNamespace;
using UnityEngine;

public enum CatcherTypes
{
    lose,
    normal,
    bonus
}

public class CatcherBeh : MonoBehaviour
{
    [SerializeField] float coefficient;
    [SerializeField] CoinsOutput CoinsOutput;
    [SerializeField] CatcherTypes type;
    [SerializeField] AudioSource audioSourceWin;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip megaSound;
    float _coeficientOnStart;

    private void Start()
    {
        _coeficientOnStart = coefficient;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (type == CatcherTypes.normal)
                audioSourceWin.PlayOneShot(winSound);

            if (type == CatcherTypes.bonus)
                audioSourceWin.PlayOneShot(megaSound);

            if (BonusesController.IsDoubleBallBonus)
                coefficient = coefficient * 2;
            else
                coefficient = _coeficientOnStart;

            ProgressData.GoldCoinCounter = (int)Mathf.Round(ProgressData.GoldCoinCounter * coefficient);
            Debug.Log(ProgressData.GoldCoinCounter);
            CoinsOutput.UpdateCoinCounter();
            Destroy(collision.gameObject);
        }
    }
}
