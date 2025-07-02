using UnityEngine;

//다른 클래스들과 구분하려고 이름공간 설정
namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource;
        public AudioClip bgmClip;
        public AudioClip jumpClip;

        void Start()
        {
            //오디오소스 먼저 연결하고 함수재생안하면 널레퍼런스 오류뜸
            audioSource = GetComponent<AudioSource>();
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; // 오디오 소스에 사운드 파일 설정

            //audioSource.Play(); 안써도 자동재생
            audioSource.playOnAwake = true; // 시작할 때 자동 재생

            audioSource.loop = true; // 반복 기능
            audioSource.volume = 0.1f; // 소리 음량
        }

        public void OnJumpSound()
        {
            //PlayOneShot: 짧은 효과음을 재생할 때 자주 사용하는 함수
            //한 번만 재생하고 끝나는 사운드
            audioSource.PlayOneShot(jumpClip); // 이벤트 사운드
        }
    }
}
