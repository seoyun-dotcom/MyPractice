using UnityEngine;

public class Study_Gameobject : MonoBehaviour
{
    public GameObject prefab;

    void Awake()
    {
        CreateAmongus();
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab);// GameObject를 생성하는 기능

    }
}

