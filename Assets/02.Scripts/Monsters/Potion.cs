using UnityEngine;

public class Potion : MonoBehaviour,IItem
{
    public enum PotionType { Sky, Green, Yellow}
    public PotionType potionType;
    private Inventory inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        obj = this.gameObject;
    }
    void OnMouseDown()
    {
        Get();
    }

    public GameObject obj { get; set; }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득했습니다");
        inventory.AddItem(this);
        gameObject.SetActive( false );
    }
}
