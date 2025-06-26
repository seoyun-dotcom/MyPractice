using UnityEngine;

public class Study_Component : MonoBehaviour
{
    public GameObject obj;

    public string changeName;

    void Start()
    {
        obj = GameObject.Find("Main Camera"); // Main Camera 오브젝트를 찾아서 할당하는 기능

        obj.name = changeName;
    }
}
