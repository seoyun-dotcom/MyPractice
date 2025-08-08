using UnityEngine;

public class Study_LookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turretHead;

    public GameObject bulletPrefab;//Bullet프리펩
    public Transform firePos;//발사위치

    public float timer;
    public float cooldownTime;
    
    void Start()
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()// 무엇인가를 바라보는 기능
    {
        turretHead. LookAt(targetTf);//포탑머리가 타겟을 바라보는 기능

        timer += Time.deltaTime;
        if(timer>=cooldownTime)
        {
            timer = 0;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);//총알을 생성하는 기능
        }

    }
}
