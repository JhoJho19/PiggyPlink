using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioSettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Text musicStatusText;
    [SerializeField] private TMP_Text sfxStatusText;

    private const string MusicParam = "MusicParam";
    private const string SFXParam = "SFXParam";

    private bool isMusicOn = true;
    private bool isSFXOn = true;

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        audioMixer.SetFloat(MusicParam, isMusicOn ? 0f : -80f);

        if (musicStatusText != null)
        {
            musicStatusText.text = isMusicOn ? "Music On" : "Music Off";
        }
    }

    public void ToggleSFX()
    {
        isSFXOn = !isSFXOn;
        audioMixer.SetFloat(SFXParam, isSFXOn ? 0f : -80f);

        if (sfxStatusText != null)
        {
            sfxStatusText.text = isSFXOn ? "Sound On" : "Sound Off";
        }
    }
}
