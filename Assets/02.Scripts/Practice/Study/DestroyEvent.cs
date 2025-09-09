using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, destroyTime); // 자기 자신을 3초 뒤에 파괴하는 기능
    }

    /*오브젝트가 삭제되기 직전에 실행되는 함수
   //보통 정리, 이펙트 처리, 저장 등 마무리 작업에 사용
   //OnDestroy()는 Unity가 자동으로 실행해주는 함수(ex)Start(),Update())
   //따라서, Start문에 적지않아도 콘솔창에 실행된다.
   */
    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}이 파괴되었습니다.");
    }
}
