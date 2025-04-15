using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{

    public void loadMainMenu() {

        SceneManager.LoadScene("MainMenu");
    
    }

    //cette fonction permet de sortir du credit (escapecredit)
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //Debug.Log("je suis bien arrive den la fonction EscapeCredit");
            loadMainMenu();
        }
    
    }
}
