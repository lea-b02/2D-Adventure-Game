using System;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private TMP_Text interactUI;

    private bool isInRange;

    public Animator animator;

    public int coinsToAdd;

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
        if (Input.GetKeyDown(KeyCode.E) && isInRange ) {

            OpenChest();
        }
    }

    //ouvrir le coffre 
    public void OpenChest() {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instanceAudioManager.PlayClipAt(soundToPlay, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.gameObject.SetActive(false);
        isInRange = false;


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
