using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public Sprite image;
    public int hpGivent;
    public int speedGiven ;
    public float speedDuration;

    public int price;
    
}
