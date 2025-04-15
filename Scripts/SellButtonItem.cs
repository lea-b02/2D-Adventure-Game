using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    
    public Item item;

    public void ByItem() {
        Inventory inventory = Inventory.instance;

        if (Inventory.instance.coinsCount >= item.price) {

            inventory.content.Add(item);
            inventory.UpdateIventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateTextUI();
            Debug.Log("Cette item a etait achete !");

        }

    }
    
}
