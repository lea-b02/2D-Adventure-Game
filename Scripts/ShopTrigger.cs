using TMPro;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{

    public Item[] itemToSell;
    public string pngName;

    private TMP_Text interactUI;

    private bool isInRange;


    void Awake()
    {
        GameObject uiObject = GameObject.FindGameObjectWithTag("InteractUI");
        //print("isInRange" + isInRange);
        if (uiObject != null)
        {
            interactUI = uiObject.GetComponent<TMP_Text>();
            //Debug.Log("interactUI trouvé : " + interactUI);
            //interactUI.gameObject.SetActive(false);

        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'interactUI' trouvé !");
        }

        if (interactUI == null)
        {
            Debug.LogError("L'objet avec le tag 'interactUI' n'a PAS de composant Text !");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instanceShopManager.OpenShop(itemToSell,pngName);   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isInRange = true;
            interactUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            isInRange = false;
            interactUI.gameObject.SetActive(false);
            ShopManager.instanceShopManager.CloseShop();
        }
    }

   

}
