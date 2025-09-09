using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform grabPos;

    private IDropItem currentItem;

    void Update()
    {
        Move();
        Interaction();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); // x축 오른쪽/왼쪽
        float v = Input.GetAxis("Vertical"); // z축 앞쪽/뒤쪽

        Vector3 dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    private void Interaction()
    {
        //손에 아무것도없을때 마우스클릭하면 널오류 뜨지않도록
        if (currentItem == null)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            currentItem.Use();// 아이템 사용
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop(); // 아이템 버리기
            currentItem = null;
        }
    }
    //손전등,총 isTrigger 체크해주기
    private void OnTriggerEnter(Collider other)
    {
        //그 오브젝트가 IDropItem이 있다면 아이템 닿으면 자동으로 손으로 가꼬오기! 줍기!
        if (other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item;

            currentItem.Grab(grabPos); // 아이템 줍기
        }
    }
}
