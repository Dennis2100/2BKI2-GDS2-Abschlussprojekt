using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState //Definition der verschiedenen Statuse
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public GameObject shop;
    public GameObject dialog;
    public GameObject inventory;
    public IntValue numberOfHealthPotions;
    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        numberOfHealthPotions.initialValue = numberOfHealthPotions.masterValue;
        numberOfHealthPotions.RuntimeValue = numberOfHealthPotions.initialValue;
        //startingPosition.initialValue = startingPosition.masterValue;
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && currentState != PlayerState.attack && currentState != PlayerState.stagger && dialog.activeInHierarchy == false && shop.activeInHierarchy == false)
        {
            StartCoroutine(AttackCo());
        }
        /*else if (Input.GetButton("archer"))
        {
            Debug.Log("Yes");
        }*/
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

        if (Input.GetKeyUp(KeyCode.F) && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            OpenInventory();
        }
    }

    private void OpenInventory()
    {
        if (inventory.activeInHierarchy)
        {
            inventory.SetActive(false);                 //Dialogbox ist deaktiviert
        }
        else
        {
            inventory.SetActive(true);                  //Dialogbox ist aktiviert
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);    //Animation für Angriff wird aktiviert
        currentState = PlayerState.attack;      //Status wird auf Angriff gesetzt
        yield return null;
        animator.SetBool("attacking", false);   //Animation für Angriff wird deaktiviert
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;        //Status wird auf Laufen gesetzt
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);   //Animation für das Laufen wird aktiviert
        }
        else
        {
            animator.SetBool("moving", false);  //Animation für das Laufen wird deaktiviert
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); //Weite der Bewegung wird ermittelt
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;   //Der Schaden wird vom derzeitigen Gesundheitsstand abgezogen
        //playerHealthSignal.Raise();             //playerHealthSignal sendet ein Signal an .Raise()

        if (currentHealth.RuntimeValue > 0)     //Wenn die derzeitige Gesundheitsanzeige über 0 liegt
        {
            StartCoroutine(KnockCo(knockTime)); //KnockCo() wird aufgerufen
        }
        else
        {
            this.gameObject.SetActive(false);   //Spieler wird deaktiviert
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
