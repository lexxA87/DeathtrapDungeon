using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private Player player;
    private List<ItemInventory> inventory;
    private GameObject[] images;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.Instance.Player;
        inventory = player.Inventory;

        images = GameObject.FindGameObjectsWithTag("InventoryPanelImage");

        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            images[i].SetActive(true);
            images[i].GetComponent<Image>().sprite = inventory[i].Sprite;
        }
    }
}
