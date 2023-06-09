using Assets.Scripts;
using TMPro;
using UnityEngine;

public class CharNumbersManager : MonoBehaviour
{
    public TextMeshProUGUI MasterScore;
    public TextMeshProUGUI StaminaScore;
    public TextMeshProUGUI LuckScore;
    public TextMeshProUGUI FoodScore;
    public TextMeshProUGUI GoldScore;

    // Start is called before the first frame update
    void Start()
    {
        Player player = PlayerManager.Instance.Player;

        MasterScore.text = player.Master.ToString();
        StaminaScore.text = player.Stamina.ToString();
        LuckScore.text = player.Luck.ToString();
        FoodScore.text = player.Food.ToString();
        GoldScore.text = player.Gold.ToString();
    }

}
