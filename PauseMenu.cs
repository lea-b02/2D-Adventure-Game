using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPause = false;

    public GameObject settingWindows;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            
                if (gameIsPause)
                {
                    Resume();
                }
                else
                {
                    Paused();
                } 
        }
    }

    private void Paused() {
        PlayerMove.instanceMove.enabled = false;
    //active notre menu pause /l'affiche 
        pauseMenuUI.SetActive(true);
    //arreter le temps
        Time.timeScale = 0;

    // change le statue de jeux
        gameIsPause = true;
    }


    //pour aussi le button resune et aussi quand on rerfait escape
    public void Resume()
    {
        PlayerMove.instanceMove.enabled = true;

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1;

        gameIsPause = false;
    }

    public void LoadMainMenu() {

        Resume();
        SceneManager.LoadScene("MainMenu");
    
    }

    public void OpenSettingsWindows() { 
        settingWindows.SetActive(true);
    
    }

    public void CloseSettingsWindows()
    {
        settingWindows.SetActive(false);

    }
}
