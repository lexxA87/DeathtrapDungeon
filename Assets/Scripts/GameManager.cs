using Assets.Scripts;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CardText;
    Card card;

    //private Card card;
    void Start()
    {
        //Card card = APIHelper.GetCard();
        //CardText.text = card.Description;
        GetCard();
    }

    [ContextMenu("Get Card")]
    public async void GetCard()
    {
        var httpClient = new APIHelper();

        card = await httpClient.GetCardAsync("1");
        CardText.text = card.Description;
    }
}
