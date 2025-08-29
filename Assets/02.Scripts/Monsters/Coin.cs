using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public enum CoinType { Red, Love, Purple}
    public CoinType coinType;
    private Inventory inventory;

    public float price;
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
        gameObject.SetActive(false);
    }
}
