using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel; // 페이드 이미지


    void Start()
    {
        // 3초동안 페이드 인
        //StartCoroutine(FadeRoutineA(3,true));
        // 3초동안 페이드 아웃
        StartCoroutine(FadeRoutineA(3, false));

    }

    IEnumerator FadeRoutineA(float fadeTime, bool isFadeIn)
    {
        float timer = 0f;//흘러간 시간 누적용
        float percent = 0f;//진행률 (0.0 ~ 1.0)
        float value = 0f;//최종적으로 color 알파값에 넣을 값

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            //알파값이 0 → 1 또는 1 → 0으로 변화
            value = isFadeIn ? percent : 1 - percent;

            fadePanel.color = new Color(fadePanel.color.r,
                                        fadePanel.color.g, 
										fadePanel.color.b, 
										value);
            yield return null;
        }
    }
}     
