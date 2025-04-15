using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public static GameOverManager instanceGameOverManager;



    public void Awake()
    {
        if (instanceGameOverManager != null)
        {
            Debug.LogWarning("Il a plus d'une instance de GameOverManager dans la scene");
            return;
        }
        instanceGameOverManager = this;
    }

    public void OnPlayerHealth() {
       
        gameOverUI.SetActive(true);
    }

    public void RetryButton() {
        //Recommence le niveau
        Inventory.instance.RemoveCoins(CurrentSceneManager.instanceCurrentSceneManager.cointsPickInThisScene);
        //Recharge la scene (les piece ,les coeur enemie eliminet ou pas piece prise ou pas etc etc..)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //replacele jouer ou il etait 
        PlayerHealth.instance.RespawnMethod();

        //Reactive les mouvement du jouer + lui rendre ca vie 

        gameOverUI.SetActive(false);
    }

    public void MenuButton() {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton() {
        //a tester plus tard parce que ferme tout la sesion
        //ferme le jeux
        Application.Quit();
    }

}
