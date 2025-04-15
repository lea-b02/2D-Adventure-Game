using UnityEngine;
using UnityEngine.SceneManagement; 
public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindows;
    public void StartGameButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsMenuButton()
    {
        settingsWindows.SetActive(true);    

    }

    public void CloseSettingsWindows() {
        settingsWindows.SetActive(false);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void LoadCreditsButton()
    {
        SceneManager.LoadScene("CreditScene");
    
    }
}
