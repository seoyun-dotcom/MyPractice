using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0f;
    public bool isStop = false;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed);

        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 4f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }
            
        if(isStop == true)// 현재 속도에서 특정 값만큼 줄이는 기능
        {
            rotSpeed *= 0.98f;

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }               
    }
}
