using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    public GameObject MuteButton;
    public Sprite OnMuteImage;
    public Sprite OffMuteImage;
    public bool mute = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.FindAnyObjectByType<AudioSource>().mute = mute;
        ChangeButtonSprite(mute);
    }

    public void ClickMute()
    {
        mute = !mute;
        AudioSource.FindAnyObjectByType<AudioSource>().mute = mute;
        ChangeButtonSprite(mute);
    }

    public void ChangeButtonSprite(bool mute)
    {
        if (mute)
        {
            MuteButton.GetComponent<Image>().sprite = OnMuteImage;
        }
        else
        {
            MuteButton.GetComponent<Image>().sprite = OffMuteImage;
        }
    }
}
