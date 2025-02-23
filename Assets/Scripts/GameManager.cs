using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
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

    public static void SetMute(bool mute)
    {
        isMute = mute;
    }

    public static void ToggleMute()
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
