using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public Item[] allItems;

    public static ItemsDataBase instanceItemsDataBase;

    public void Awake()
    {
        if (instanceItemsDataBase != null)
        {
            Debug.LogWarning("Il a plus d'une instance de ItemsDataBase dans la scene");
            return;
        }
        instanceItemsDataBase = this;
    }
}
