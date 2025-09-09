using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        Debug.Log($"[FadePanel] OnFade 호출됨: isFadeStart={isFadeStart}, color={color}");
        StartCoroutine(Fade(fadeTime, color, isFadeStart));
    }

    IEnumerator Fade(float fadeTime, Color color, bool isFadeStart)
    {
        float timer = 0f;//흘러간 시간 누적용
        float percent = 0f;//진행률 (0.0 ~ 1.0)

        while (percent <1f)
        {
            //게임이 시작될 때와 종료될 때 다른 fade값을 넣어주기위해 변수 생성
            float value = isFadeStart ? percent : 1 - percent;

            timer += Time.deltaTime;
            percent = timer/ fadeTime;

            fadePanel.color = new Color(color.r, color.g, color.b, value);

            Debug.Log($"[Fade] 진행 중: isFadeStart={isFadeStart}, alpha={value:F2}");
            yield return null;
        }
    }
}
