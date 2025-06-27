using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet;

    //rotSpeed = 90f → 1초에 90도 회전
    public float rotSpeed = 30f;//자전속도

    public float revolutionSpeed = 60f; //공전속도
    public bool isRevolution = false; // 논리 타입 -> true / false

    void Update()
    {
        //Vector3.up: Y축 방향, 위쪽 축을 기준으로 회전
        //자전하는 기능
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if (isRevolution == true) // 조건문 -> 만약 공전을 한다면
        {
            //공전(revolution)하는 기능
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
