using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    private Animator animator;
    private SpawnManager spawner;

    private bool isMove = true;
    private bool isHit = false;

    protected float hp = 3f;
    protected float moveSpeed = 5f;
    //화면끝까지가면 더이상안가고 방향을 바꾸게 하기위해
    private int dir = 1;

    //Initialize(초기화)의 줄임말
    //추상화 abstract
    public abstract void Init();

    private void Start()
    {
        spawner = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Init();
    }
    private void Update()
    {
        Move();
    }
    void OnMouseDown()
    {
        //Hit(1);
        StartCoroutine(Hit(1));
    }

    /// <summary>
    /// 몬스터가 오른쪽으로 이동하는 기능
    /// </summary>
    void Move()
    {
        if (!isMove)
            return;
    
        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        //캐릭터가 화면밖으로 나가지 못하게
        if (transform.position.x > 8f)
        {
            dir = -1;
            //다시 돌아갈때 고개를?돌리도록 만들기 문워크안하도록!
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }
    /// <summary>
    /// 몬스터가 공격받았을때 로직
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    IEnumerator Hit(float damage)
    {
        if(isHit)
            yield break;

        isHit = true;
        isMove = false;

        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("Death");
            Debug.Log("몬스터 죽음");

            spawner.DropCoin(transform.position);//죽은위치에 코인생성

            yield return new WaitForSeconds(2f);
            Destroy(gameObject);

            yield break;
        }
        animator.SetTrigger("Hit");

        //공격받았을 때 잠깐 멈추게 하는 기능
        yield return new WaitForSeconds(0.7f);
        isMove = true;
        isHit = false;
    }

    public virtual void Attack()
    {
        Debug.Log("공격");
    }
}
