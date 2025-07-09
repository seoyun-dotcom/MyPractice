using Cat; // 사운드 매니저가 있는 namespace
using System.Collections;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameoverUI;
    public GameObject fadeUI;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPower = 30f;
    public float limitPower = 25f;
    public int jumpCount = 0;

    void Awake()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();  
    }

    //다시하기될때마다 한번씩 실행
    void OnEnable()
    {
        //고양이를 특정위치로 재배치
        transform.localPosition = new Vector3(-7.91f, -2.15f, 0f);
        //충돌 다시 켜기
        this.GetComponent<CircleCollider2D>().enabled = true;
        //브금 재생
        soundManager.audioSource.Play();
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 10)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            jumpCount++;
            soundManager.OnJumpSound();
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

            if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                catRb.linearVelocityY = limitPower;
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Fruit"))
        {
            other.gameObject.SetActive(false);

            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score++;

            //게임 성공
            if(GameManager.score == 10)
            {
                fadeUI.SetActive(true);

                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white, true);
                GetComponent<CircleCollider2D>().enabled = false;

                StartCoroutine(EndingRoutine(true));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //게임 오버 아웃트로
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();

            gameoverUI.SetActive(true);
            fadeUI.SetActive(true);

            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black, true); // 페이드 실행
            GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(EndingRoutine(false));
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);

        videoManager.VideoPlay(isHappy); // 영상 재생 시작
        yield return new WaitForSeconds(1f);

        var newColor = isHappy ? Color.white : Color.black;
        fadeUI.GetComponent<FadePanel>().OnFade(3f, newColor, false); // 페이드 실행

        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameoverUI.SetActive(false);
        soundManager.audioSource.Stop();

        transform.parent.gameObject.SetActive(false); // PLAY 오브젝트 Off

    }
}
