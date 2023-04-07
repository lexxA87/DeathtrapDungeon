using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI CardText;

    [SerializeField]
    private Button[] directionButtons;

    [SerializeField]
    private TextMeshProUGUI[] directionButtonsText;

    APIHelper httpClient = new();

    private int _currentCardNumber = 1;

    private Card card;

    void Start()
    {
        SetCardInfo();

        for (int i = 0; i < directionButtons.Length; i++)
        {
            int copy = i;
            directionButtons[i].onClick.AddListener(() => ButtonClick(copy));
        }
    }

    private void ButtonClick(int dir)
    {
        //var card = await httpClient.GetCardAsync(_currentCardNumber.ToString());

        _currentCardNumber = card.Directions[dir].NumberCard;

        SetCardInfo();
    }

    private async void SetCardInfo()
    {
        for (int i = 0; i < directionButtons.Length; i++)
        {
            directionButtons[i].gameObject.SetActive(false);
        }
        //var card = await httpClient.GetCardAsync(_currentCardNumber.ToString());
        card = await httpClient.GetCardAsync(_currentCardNumber.ToString());



        if (card != null)
        {
            CardText.text = card.Description;

            if (card.Directions.Count > 0)
            {
                for (int j = 0; j < card.Directions.Count; j++)
                {
                    directionButtons[j].gameObject.SetActive(true);
                    directionButtonsText[j].text = card.Directions[j].Description;
                }
            }
            else EndGame();

        }
    }

    private void EndGame()
    {
        for (int i = 0; i < directionButtons.Length; i++)
        {
            directionButtons[i].gameObject.SetActive(false);
        }

        directionButtons[0].gameObject.SetActive(true);
        directionButtonsText[0].text = "Start over";
        directionButtons[0].onClick.RemoveAllListeners();
        directionButtons[0].onClick.AddListener(() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }
}
