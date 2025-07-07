using Cat; // 사운드 매니저가 있는 namespace
using System.Collections;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public bool isGround;

    public float jumpPower = 5f;
    public float limitPower = 7f;
    public int jumpCount = 0;

    public GameObject gameoverUI;
    public GameObject fadeUI;
    public GameObject playUI;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++; // 1씩 증가

            soundManager.OnJumpSound();

            if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                catRb.linearVelocityY = limitPower;
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
        //게임 오버 아웃트로
        if (other.gameObject.CompareTag("Pipe"))
        { 
            soundManager.OnColliderSound(); 

            gameoverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black);

            this.GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(EndingRoutine(false));
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
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
                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white);

                this.GetComponent<CircleCollider2D>().enabled = false;

                StartCoroutine(EndingRoutine(true));
            }
        }
    }
    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);
        videoManager.VideoPlay(isHappy);

        // yield return new WaitUntil(() => videoMusing System.Collections;anager.vPlayer.isPlaying);

        fadeUI.SetActive(false);
        gameoverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
}
