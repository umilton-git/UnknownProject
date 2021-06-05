using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item
{
    // List of items, add your items here
    public enum ItemType
    {
        Test,
        Cube
    }

    public ItemType itemType;
    public int amount;
}
