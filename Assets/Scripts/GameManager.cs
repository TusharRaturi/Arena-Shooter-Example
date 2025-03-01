using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManagerInstance;

    public static GameManager Instance { get => gameManagerInstance; }

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static UnityEvent<bool> muteToggleEvent;

    private static bool isMute = false;

    public static bool IsMute { get => isMute; }
    public static UnityEvent<bool> MuteToggleEvent
    {
        get
        {
            if (muteToggleEvent == null)
                muteToggleEvent = new UnityEvent<bool>();

            return muteToggleEvent;
        }
    }

    public void SetMute(bool mute)
    {
        isMute = mute;
    }

    public void ToggleMute()
    {
        isMute = !isMute;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
            muteToggleEvent.Invoke(isMute);
        }
    }
}
