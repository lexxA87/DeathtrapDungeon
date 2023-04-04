using Assets.Scripts;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{
    public Button RollDiceButton;

    public Button PlayButton;
    public Sprite disablePlayButton;
    public Sprite enablePlayButton;

    public TextMeshProUGUI MasterScore;
    public TextMeshProUGUI StaminaScore;
    public TextMeshProUGUI LuckScore;

    public Sprite SwardSprite;
    public Sprite ShieldSprite;
    public Sprite ShirtSprite;

    int scoreMaster = 0;
    int scoreStamina = 0;
    int scoreLuck = 0;
    int trying = 0;

    List<ItemInventory> inventory = new();

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.enabled = false;
        PlayButton.GetComponent<Image>().sprite = disablePlayButton;

        ItemInventory sward = new("Sward", "Simple iron sward", SwardSprite);
        ItemInventory shied = new("Shield", "Simple wooden shield", ShieldSprite);
        ItemInventory shirt = new("Shirt", "Simple leather shirt", ShirtSprite);

        inventory.Add(sward);
        inventory.Add(shied);
        inventory.Add(shirt);
    }

    public void SetScoreCharacter()
    {
        if (trying == 0)
        {
            SetMaster();
            trying++;
        }
        else if (trying == 1)
        {
            SetStamina();
            trying++;
        }
        else
        {
            SetLuck();
            Player player = new(scoreMaster, scoreStamina, scoreLuck, inventory);
            PlayerManager.Instance.Player = player;
            RollDiceButton.enabled = false;
            PlayButton.enabled = true;
            PlayButton.GetComponent<Image>().sprite = enablePlayButton;
        }
    }

    void SetMaster()
    {
        scoreMaster = Random.Range(1, 6) + 6;
        MasterScore.text = scoreMaster.ToString();
    }

    void SetStamina()
    {
        scoreStamina = Random.Range(2, 12) + 12;
        StaminaScore.text = scoreStamina.ToString();
    }

    private void SetLuck()
    {
        scoreLuck = Random.Range(1, 6) + 6;
        LuckScore.text = scoreLuck.ToString();
    }
}
