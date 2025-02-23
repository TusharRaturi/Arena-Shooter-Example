using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.Play();
        GameManager.MuteToggleEvent.AddListener(OnMute);
    }

    private void OnMute(bool isMuted)
    {
        if (isMuted)
            audioSource.Stop();
        else
            audioSource.Play();
    }
}
