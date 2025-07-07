using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(Fade(fadeTime, color));
    }

    IEnumerator Fade(float fadeTime, Color color)
    {
        float timer = 0f;//흘러간 시간 누적용
        float percent = 0f;//진행률 (0.0 ~ 1.0)
        while (percent <1f)
        {
            timer += Time.deltaTime;
            percent = timer/ fadeTime;

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
    }
}
