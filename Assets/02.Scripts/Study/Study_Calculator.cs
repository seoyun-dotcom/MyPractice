using UnityEngine;

public class Study_Calculator : MonoBehaviour
{
    public int number1, number2;//멤버변수 (필드)
    void Start()
    {
        int addResult = AddMethod();//함수 호출
        int minusResult = MinusMethod();

        Debug.Log($"더한 값: {addResult} / 뺀 값: {minusResult}");
    }

    int AddMethod()
    {
        //지역변수 result
        int result = number1 + number2;
        return result;
    }
    int MinusMethod()
    {
        int result = number1 - number2;
        return result;
    }
   
}
