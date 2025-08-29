using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private float h, v;

    private Animator animator;

    [SerializeField] private GameObject hitBox;
    private bool isAttack = false;//불값 설정으로 광클방지

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if( h == 0 && v == 0 )//Idle -> 움직이지않는상태
        {
            animator.SetBool("Run",false);
        }
        else//Run -> 움직이는 상태
        {
            int scaleX = h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
            /*
            //if(h > 0)
            //    transform.localScale = new Vector3(1, 1, 1);
            //else if (h < 0)
            //    transform.localScale = new Vector3(-1, 1, 1);
            */

            animator.SetBool("Run", true);
            var dir = new Vector3(h, v, 0).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }

    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isAttack)//광클방지 (&&조건)
        {
            StartCoroutine(AttackRoutine());
        }
    }
    IEnumerator AttackRoutine()//0.25초동안만 공격, 불값 설정으로 광클방지
    {
        isAttack = true;
        hitBox.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);

        yield return new WaitForSeconds(0.75f);//쿨타임
        isAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get();
        }
    }
}
