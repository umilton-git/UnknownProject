using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public enum ItemList
    {
        Test,
        Cube
    }
    public class GetItem : InteractableBase
    {
        public ItemList m_Item;
        public int m_amount;
        public Inventory inventory = new Inventory();

        public override void OnInteract()
        {
            base.OnInteract();
            switch (m_Item)
            {
                case ItemList.Test:
                    inventory.AddItem(new Item { itemType = Item.ItemType.Test, amount = m_amount });
                    break;

                case ItemList.Cube:
                    inventory.AddItem(new Item { itemType = Item.ItemType.Cube, amount = m_amount });
                    break;

                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
