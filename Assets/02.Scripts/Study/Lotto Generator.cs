using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoGenerator : MonoBehaviour
{
    //new int[10]: 10개의 정수를 담을 공간을 만든다는 뜻
    //public int[] intArray = new int[10];// 배열은 미리 만들어놓는 방식
    //섞을 횟수 지정 → 총 1000번 Swap할 것

    public List<int> intList = new List<int>();
    // 필요할 때마다 추가 / 삭제 / 삽입 가능한 방식

    public int shakeCount = 100;

    private void Awake()
    {
        for (int i = 1; i < 46; i++) // i = 1 ~ 45까지의 반복
            intList.Add(i);
    }
    IEnumerator Start()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            int ranInt1 = Random.Range(0, intList.Count);
            int ranInt2 = Random.Range(0, intList.Count);

            var temp = intList[ranInt1];
            intList[ranInt1] = intList[ranInt2];
            intList[ranInt2] = temp;

            //매 반복마다 0.1초 지연
            //천 번 동안 진행 -> 전체적으로 약 100초 동안 섞는 연출
            yield return new WaitForSeconds(0.1f);
        }

        List<int> resultGroup = new List<int>();

        for (int i = 0; i < 6; i++)
            resultGroup.Add(intList[i]);

        resultGroup.Sort();
        // resultGroup.Reverse(); // 뒤집기

        string resultNumber = $"이번 주 로또 번호 : {resultGroup[0]} / {resultGroup[1]} / {resultGroup[2]}" +
                                              $"/ {resultGroup[3]} / {resultGroup[4]} / {resultGroup[5]} " +
                                              $"/ 보너스 넘버 : {intList[6]}";

        Debug.Log(resultNumber);

    }
}
