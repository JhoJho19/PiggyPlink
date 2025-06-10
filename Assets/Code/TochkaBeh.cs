using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TochkaBeh : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioSource.clip);
        if (BonusesController.IsDoubleBallBonus)
            FindObjectOfType<BonusesController>().SpawnDoubleBall(collision.transform.position);
    }
}
