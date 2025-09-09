using TMPro;
using UnityEngine;

namespace Cat
{

    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TextMeshProUGUI playtimeUI;
        public TextMeshProUGUI scoreUI;

        private static float timer;
        public static int score; // 딸기를 먹은 개수
        public static bool isPlay;

        void Start()
        {
            soundManager.SetBGMSound("Intro");
        }

        void Update()
        {
            //게임시작전에는 Update문 실행X
            if (!isPlay) return;

            timer += Time.deltaTime;

            playtimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            // playTimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            scoreUI.text = $"X {score}";
        }
        public static void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }
    }
}
