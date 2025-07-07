using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        void Start()
        {
            startButton.onClick.AddListener(OnStartButton);

        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("입력한 텍스트 없음");
                //startButton.interactable = false;
            }
            else
            {
                nameTextUI.text = inputField.text;
                soundManager.SetBGMSound("Play");

                GameManager.isPlay = true; //true가 되면 타이머 시작
                Debug.Log($"{nameTextUI.text} 입력");

                playObj.SetActive(true);
                playUI.SetActive(true);
                introUI.SetActive(false);
            }
        }
    }
}
