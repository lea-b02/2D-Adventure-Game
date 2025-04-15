using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int levelToUnlock;

    public int cointsPickInThisScene;

    public Vector3 respawnPoint;

    public static CurrentSceneManager instanceCurrentSceneManager;

    public void Awake()
    {
        if (instanceCurrentSceneManager != null)
        {
            Debug.LogWarning("Il a plus d'un instance de CurrentSceneManager dans la scene");
            return;
        }
        instanceCurrentSceneManager = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }


}
