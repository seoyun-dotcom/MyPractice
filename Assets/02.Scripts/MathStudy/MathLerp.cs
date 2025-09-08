using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    private Vector3 startPos;
    private float timer, percent;
    public float lerpTime;

    private void Start()
    {
        startPos = transform.position; //시작지점저장
    }

    void Update()
    {
        timer += Time.deltaTime;// deltaTime: 시간 조작

        //timer = Time.time;// 유니티에디터를 플레이 한 이후의 누적시간

        percent = timer/lerpTime;
        // (현재위치, 목표위치, 이동 비율)
        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}