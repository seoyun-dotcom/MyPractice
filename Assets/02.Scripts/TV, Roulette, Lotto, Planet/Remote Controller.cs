using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    private VideoPlayer videoPlayer;

    public bool isOn = false;
    public bool isMute = false;

    public VideoClip[] clips; // 영상 파일 배열
    public int currClipIndex = 0; // 현재 영상 Index

    //여러 버튼을 한개의 스크립트로 처리하기 위해
    public Button[] buttonUIs;

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0]; // Default 영상 설정
    }

    void Start()
    {
        //코드에서 직접 등록하고있으므로 유니티상 ->
        //버튼 컴포넌트 (OnClick Event)로 중복 등록하면
        //중복실행이 되버린다.
        buttonUIs[0].onClick.AddListener(OnScreenPower);
        buttonUIs[1].onClick.AddListener(OnMute);
        buttonUIs[2].onClick.AddListener(OnPrevChannel);
        buttonUIs[3].onClick.AddListener(OnNextChannel);
    }
    public void OnScreenPower()
    {
        // GameObject 속성을 활용한 방법
        videoScreen.SetActive(!videoScreen.activeSelf);

        //길게 적은 방법
        //if (!isOn)//isOn == false
        //{
        //    videoScreen.SetActive(true);
        //    isOn = true;
        //}
        //else
        //{
        //    videoScreen.SetActive(false);
        //    isOn = false;
        //}

        // NOT을 활용하여 줄여서 적은 방법
        // isOn = !isOn;
        // videoScreen.SetActive(isOn);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    //public void OnChangeChannel(bool isNext)
    //{
    //    int value = isNext ? 1 : -1;
    //    currClipIndex += value;
    //    //다음채널이 마지막채널 인덱스보다 커지면 처음채널로 돌아가는 기능
    //    if (currClipIndex > clips.Length - 1)
    //        currClipIndex = 0;
    //    //이전채널이 0보다 작아지면 마지막채널로 돌아가는 기능
    //    if (currClipIndex < 0)
    //        currClipIndex = clips.Length - 1;

    //    videoPlayer.clip = clips[currClipIndex];
    //    videoPlayer.Play();
    //}

    public void OnNextChannel() // 오른쪽 버튼
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1)
            currClipIndex = 0;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // 왼쪽 버튼
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = clips.Length - 1;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

}
