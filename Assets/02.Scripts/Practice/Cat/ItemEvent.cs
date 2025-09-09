using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType { Pipe, Fruit, Both }
    public ColliderType colliderType;

    public GameObject pipe;
    public GameObject fruit;
    public GameObject particle;

    public float moveSpeed = 4f;
    public float returnPosX = 15f;
    public float randomPosY;

    private Vector3 initPos;

    void Awake()
    {
        initPos = transform.localPosition; // 처음 위치 저장
    }

    void OnEnable()
    {
        SetRandomSetting(initPos.x); // 다시 활성화될 때 위치 초기화
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            SetRandomSetting(returnPosX);
        }
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-8f, -3.5f);
        transform.position = new Vector3(posX, randomPosY, 0);

        //다 끄고 switch문에서 키기
        pipe.SetActive(false);
        fruit.SetActive(false);
        particle.SetActive(false);

        //Pipe, Fruit, Both중 하나
        colliderType = (ColliderType)Random.Range(0, 3);

        switch (colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Fruit:
                fruit.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                fruit.SetActive(true);
                break;
        }
    }
}
     