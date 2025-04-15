using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();

    private int contentCurrentIndex = 0;

    public int coinsCount;

    public static Inventory instance;

    public Text coinsCountText;

    public Image itemUIImage;
    public Sprite itemUISprite;

    public Text itemUIName;

    public PlayerEffect playerEffects;
    public void Awake()
    {
        if (instance != null){
            Debug.LogWarning("Il a plus d'une instance de Inventory dans la scene");
            return;
        }
        instance = this;
    }

    public void Start()
    {
        UpdateIventoryUI();
    }

    public void AddCoins(int count) {
        coinsCount += count;
        //coinsCountText.text = coinsCount.ToString();
        UpdateTextUI();

    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        //coinsCountText.text = coinsCount.ToString();
        UpdateTextUI();
    }

    public void UpdateTextUI() {
        coinsCountText.text = coinsCount.ToString();
    
    }

    public void ConsumeItem()
    {
        if (content.Count == 0) { 
         return;
        }
        Item currentItem =content[contentCurrentIndex];
        PlayerHealth.instance.HealtPlayer(currentItem.hpGivent);
        //PlayerMove.instanceMove.moveSpeed += currentItem.speedGiven;
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateIventoryUI();
    }

    public void GetNextItem() {

        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1) {
            contentCurrentIndex = 0;
        }
        UpdateIventoryUI();
    }

    public void GetPreviousItem() {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;

        if(contentCurrentIndex < 0) {
            contentCurrentIndex = content.Count-1;
        }
        UpdateIventoryUI();
    }

    public void UpdateIventoryUI() {
        if (content.Count > 0)
        {
            itemUIImage.sprite = content[contentCurrentIndex].image;
            itemUIName.text = content[contentCurrentIndex].name;
        }
        else { 
            itemUIImage.sprite= itemUISprite;
            itemUIName.text = "not item";
        }
    
    }
}
