using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0f;
    public bool isStop = false;
    public bool isRotating = false;

    void Update()
    {
        // Z축 기준으로 회전하는 기능
        transform.Rotate(Vector3.forward * rotSpeed);

        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 4f;
            isRotating = true;// 룰렛이 도는 중
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isRotating)// 만약 돌고 있다면
            {
                isStop = true;// 감속 시작
            }
        }
        //if (isStop == true) 랑 if (isStop)랑 같은 말   
        if (isStop == true)
        {
            rotSpeed *= 0.98f;// 현재 속도에서 특정 값만큼 줄이는 기능

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isRotating = false;
                isStop = false;
            }
        }               
    }
}
