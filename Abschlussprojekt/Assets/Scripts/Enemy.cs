using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject coin;
    public GameObject death;
    public Animator anim;

    void Start()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            CoinDrop();
            //Death();
            this.gameObject.SetActive(false);
        }
    }

    /*private void Death()
    {
        anim.SetBool("death", true);
    }*/

    private void CoinDrop()
    {
        coin = Instantiate(coin, transform.position, Quaternion.identity);
        coin.SetActive(true);

        /*if(coin != null)
        {
            GameObject drop = Instantiate(coin, transform.position, Quaternion.identity);
        }*/
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
