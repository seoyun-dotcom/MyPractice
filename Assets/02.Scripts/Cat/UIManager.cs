using TMPro;
using UnityEngine;
using UnityEngine.UI;   

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject introUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

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
                playObj.SetActive(true);
                introUI.SetActive(false);

                nameTextUI.text = inputField.text;
                Debug.Log($"{nameTextUI.text} 입력");
            }
        }
    }
}
