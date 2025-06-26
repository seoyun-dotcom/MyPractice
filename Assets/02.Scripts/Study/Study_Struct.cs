using UnityEngine;

public class Study_Class
{
    public int number;

    public Study_Class(int _number)
    {
        this.number = _number;
    }
}

public struct Study_Struct1
{
    public int number;

    public Study_Struct1(int _number)
    {
        this.number = _number;
    }
}

public class Study_Struct : MonoBehaviour
{
    void Start()
    {
        Debug.Log("클래스-----------------------");
        Study_Class c1 = new Study_Class(10);
        Study_Class c2 = c1;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");

        c1.number = 100;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");

        Debug.Log("구조체-----------------------");
        Study_Struct1 s1 = new Study_Struct1(10);
        Study_Struct1 s2 = s1;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");

        s1.number = 100;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
    }

}
