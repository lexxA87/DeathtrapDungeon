using UnityEngine;

namespace Assets.Scripts
{
    public class ItemInventory
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Sprite Sprite { get; set; }

        public ItemInventory(string name, string description, Sprite sprite)
        {
            Name = name;
            Description = description;
            Sprite = sprite;
        }
    }
}
