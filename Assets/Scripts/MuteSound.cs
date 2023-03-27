using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public bool mute = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.FindAnyObjectByType<AudioSource>().mute = mute;
    }

    public void ClickMute()
    {
        mute = !mute;
        AudioSource.FindAnyObjectByType<AudioSource>().mute = mute;
    }
}
