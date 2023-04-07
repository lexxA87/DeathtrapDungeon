using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CardText;
    Card card = new();

    [SerializeField]
    private Button[] directionButtons;

    [SerializeField]
    private TextMeshProUGUI[] directionButtonsText;

    APIHelper httpClient = new();


    //private Card card;
    async void Start()
    {
        for (int i = 0; i < directionButtons.Length; i++)
        {
            directionButtons[i].gameObject.SetActive(false);
        }

        card = await httpClient.GetCardAsync("1");
        SetMainText(card.Description);
        SetDirectionButton();
    }

    [ContextMenu("Get Card")]
    public async void GetCard(string id = "1")
    {
        card = await httpClient.GetCardAsync(id);
        SetMainText(card.Description);
        SetDirectionButton();
    }

    public async void SetNewCard(string id = "1")
    {
        card = new();

        for (int i = 0; i < directionButtons.Length; i++)
        {
            directionButtons[i].gameObject.SetActive(false);
        }

        card = await httpClient.GetCardAsync(id);
        SetMainText(card.Description);
        SetDirectionButton();
    }

    private void SetMainText(string text)
    {
        CardText.text = text;
    }

    private void SetDirectionButton()
    {
        string direction;
        string description;

        for (int j = 0; j < card.Directions.Count; j++)
        {
            int copy = j;
            direction = card.Directions[copy].NumberCard.ToString();
            description = card.Directions[copy].Description;
            directionButtonsText[j].text = description;
            directionButtons[j].onClick.AddListener(() => SetNewCard(direction));
            directionButtons[j].gameObject.SetActive(true);
        }
    }
}
