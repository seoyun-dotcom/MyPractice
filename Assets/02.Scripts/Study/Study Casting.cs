using UnityEngine;

public class StudyCasting : MonoBehaviour
{
    void Start()
    {
        int num1 = 123;

        // 불가능 -> ToString 사용
        //string str1 = num1;
        //string str2 = (string)num1;
        string str3 = num1.ToString();
    }
}