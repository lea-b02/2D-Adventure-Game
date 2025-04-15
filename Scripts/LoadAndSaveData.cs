using System.Linq;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instanceLoadAndSaveData;

    public void Awake()
    {
        if (instanceLoadAndSaveData != null)
        {
            Debug.LogWarning("Il a plus d'une instance de LoadAndSaveData dans la scene");
            return;
        }
        instanceLoadAndSaveData = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Level01")
        {
            // Remise à zéro des pièces si on est dans le Level01
            Inventory.instance.coinsCount = 0;
        }
        else
        {
            // Sinon, on récupère ce qui a été sauvegardé
            Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        }

        Inventory.instance.UpdateTextUI();

        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.curentHealth = currentHealth;
        PlayerHealth.instance.healtBar.SetHealth(currentHealth);

        //chargement
        string[] itemSave = PlayerPrefs.GetString("inventoryItems","").Split(',');

        for (int i = 0; i < itemSave.Length; i++)
        {
            if (itemSave[i] != "") {
                //Debug.Log("Item Charge :" + itemSave[i]);
                //ajouter l'item a l'interieur

                int id = int.Parse(itemSave[i]);
                Item currentItem = ItemsDataBase.instanceItemsDataBase.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);

            }
            
        }
        Inventory.instance.UpdateIventoryUI();

        
    }

    public void SaveData() {
        PlayerPrefs.SetInt("coinsCount",Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.curentHealth);
        
        if (CurrentSceneManager.instanceCurrentSceneManager.levelToUnlock > PlayerPrefs.GetInt("levelReached",1)) {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instanceCurrentSceneManager.levelToUnlock);
        }

        //d'abore suavegarde les position
        //link - faire des requette sur les donne comm filtre les donne 
        //tout les item doit avoir des identifien unique (id unique )
        string itemInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));

        //Debug.Log("les item on bien etait selectionne :" +itemInInventory);
        
        PlayerPrefs.SetString("inventoryItems", itemInInventory);
    }
}
