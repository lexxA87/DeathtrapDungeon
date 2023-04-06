using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CardText;
    Card card;
    private GameObject[] directions;

    //private Card card;
    void Start()
    {
        GetCard();
    }

    [ContextMenu("Get Card")]
    public async void GetCard(string id = "1")
    {
        var httpClient = new APIHelper();

        directions = GameObject.FindGameObjectsWithTag("Direction");
        for (int i = 0; i < directions.Length; i++)
        {
            directions[i].SetActive(false);
        }

        card = await httpClient.GetCardAsync(id);
        CardText.text = card.Description;

        if (card.Directions.Count > 0)
        {
            for (int j = 0; j < card.Directions.Count; j++)
            {
                string direction = card.Directions[j].NumberCard.ToString();
                string description = card.Directions[j].Description;
                directions[j].GetComponentInChildren<TextMeshProUGUI>().text = description;
                directions[j].GetComponent<Button>().onClick.AddListener(() => GetCard(direction));
                directions[j].SetActive(true);
            }
        }
    }
}
