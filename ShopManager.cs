using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{
    public Text nameTextPng;

    public Animator animator;

    public static ShopManager instanceShopManager;

    public GameObject sellButtonPrefab;

    public Transform sellButtonsParent;


    public void Awake()
    {
        if (instanceShopManager != null)
        {
            Debug.LogWarning("Il a plus d'une instance de ShopManager dans la scene");
            return;
        }
        instanceShopManager = this;
    }

    public void OpenShop(Item[] items , string pngName) {
        nameTextPng.text = pngName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen", true);

    }

    public void UpdateItemsToSell(Item[] items)
    {
        //supprime les potentiels bouton qui pourrai avoir aux depart dans les parent 
        for (int i = 0; i < sellButtonsParent.childCount; i++)
        {
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        
        }
        
        //instancie un bouton pour chaque item a vendre et e configure
        for (int i = 0; i < items.Length; i++) {

            GameObject button = Instantiate(sellButtonPrefab, sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = items[i].name;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();

            //de manier dinamique
            buttonScript.item = items[i];
            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.ByItem(); });
        }
        
    }

    public void CloseShop()
    {

        Debug.Log("Fin du shopping");
        animator.SetBool("isOpen", false);
    }
}
