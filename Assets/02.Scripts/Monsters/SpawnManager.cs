using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //이미 정해진 개수가 있는 경우
    [SerializeField] private GameObject[] monsters;//몬스터종류가 이미 정해진 상태
    [SerializeField] private GameObject[] items;

    //n초마다 몬스터를 랜덤으로 생성하는 기능
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);

            var randomIndex = Random.Range(0, monsters.Length);

            var randomX = Random.Range(-8, 9);//(-8~8)
            var randomY = Random.Range(-3, 5);//(-3~4)
            var CreatePos = new Vector3 (randomX, randomY, 0);

            Instantiate(monsters[randomIndex], CreatePos, Quaternion.identity);//원점에 생성 -> CreatePos에 생성

            //몬스터를 생성하는 기능
        }
    }
    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range (0, items.Length);//랜덤 아이템 인덱스

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);//랜덤 아이템 생성

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        //위치속도(AddForce)
        itemRb.AddForceX(Random.Range(-2,2),ForceMode2D.Impulse);//양옆으로 드랍되게 x축도 건드려주기
        itemRb.AddForceY(3f,ForceMode2D.Impulse);//아이템 머리위로 순간적으로 드랍되게 하기

        float ranPower = Random.Range(-1.5f, 1.5f);
        //회전속도(AddTorque)
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }   


}
