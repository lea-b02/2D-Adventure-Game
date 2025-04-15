using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;

    public void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            StartCoroutine(loadNextScene());    
        }
    }

    public IEnumerator loadNextScene() {
        LoadAndSaveData.instanceLoadAndSaveData.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        //pour passe d'une scene a une autre
        SceneManager.LoadScene(sceneName);
        
    }
}
