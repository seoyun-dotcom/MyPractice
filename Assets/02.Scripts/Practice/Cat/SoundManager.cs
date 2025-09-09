using UnityEngine;

//다른 클래스들과 구분하려고 이름공간 설정
namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip playClip;
        public AudioClip jumpClip;
        public AudioClip introClip;
        public AudioClip colliderClip;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
                audioSource.clip = introClip;
            else if (bgmName == "Play")
                audioSource.clip = playClip;

            audioSource.loop = true;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }

        public void OnJumpSound()
        {
            //PlayOneShot: 짧은 효과음을 재생할 때 자주 사용하는 함수
            //한 번만 재생하고 끝나는 사운드
            audioSource.PlayOneShot(jumpClip); // 이벤트 사운드
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
            audioSource.volume = 1.0f;
        }
    }
}
