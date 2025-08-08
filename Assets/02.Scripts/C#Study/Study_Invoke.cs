using UnityEngine;

public class Study_Invoke : MonoBehaviour
{
    public int count = 10;

    void Start()
    {
        InvokeRepeating("Bomb", 0f, 1f);
    }

    private void Bomb()
    {
        Debug.Log($"현재 남은 시간 : {count}초");
        count--;

        if (count == 0)
        {
            Debug.Log("폭탄이 터졌습니다.");
        }
    }

    //Update()문에 적는이유: 계속 주시하면서, 특정 키 입력이 들어오면
    //즉시 반응하게 하기 위해
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("폭탄이 해제되었습니다.");
        }
    }
}
