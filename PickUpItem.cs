using System;
using TMPro;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private TMP_Text interactUI;

    private bool isInRange;

    public Item item;
    public AudioClip soundToPlay;



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

    private void Start()
    {
        interactUI.gameObject.SetActive(false);

    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {

            TakeItem();
        }
    }

    //ouvrir le coffre 
    public void TakeItem()
    {
       Inventory.instance.content.Add(item);
       Inventory.instance.UpdateIventoryUI();
        AudioManager.instanceAudioManager.PlayClipAt(soundToPlay, transform.position);
        interactUI.gameObject.SetActive(false);
        isInRange = false;
        Destroy(gameObject);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactUI != null)
            {
                interactUI.gameObject.SetActive(true);
                isInRange = true;
            }
            else
            {
                Debug.LogError("interactUI is null in OnTriggerEnter2D!");
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        interactUI.gameObject.SetActive(false);
    //        isInRange = false;
    //    }

    //}
}

