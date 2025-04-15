using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMove playerMovement;
    public BoxCollider2D topcollider;

    private TMP_Text interactUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        //interactUI = GameObject.FindGameObjectWithTag("interactUI").GetComponent<Text>();
        GameObject uiObject = GameObject.FindGameObjectWithTag("InteractUI");
        
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
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E)) {
            //descendre de l'echelle
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            //Debug.Log("Le jouer et descendu de l'echelle");
            return;
        }
        if (isInRange && Input.GetKeyDown(KeyCode.E)) { 
            playerMovement.isClimbing = true;
            topcollider.isTrigger = true;
        
        }
    }

    //quand il et a cote de cette boite de collision il et asset proche pour monte
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            interactUI.gameObject.SetActive(true);
            isInRange = true;
        }

    }

    //quand un objet quite la zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.gameObject.SetActive(false);
            isInRange = false;
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
        }

    }
}
