using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float speed = 4f;
    public Transform Character;
    /*public Transform FeetLeft;
    public Transform FeetRight;
    public LayerMask GroundLayer;

    public Animator MoveCharacter;
    public Animator JumpCharacter;

    public Action OnKilled;
    public Action OnReachedEndOfLevelFlagStick;
    public Action Mushroom;
    public Action GetSuperMario;*/

    private Rigidbody2D rigidBody;

    //public AudioSource OneShoot;

    public float delayTime = 0.3f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //MoveCharacter.GetComponent<Animator>();
        //JumpCharacter.GetComponent<Animator>();
        //OneShoot.GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 mov = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );

        transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);

        //HandleAnimations();
    }

    // Función que mueve el personaje hacia delante en base a una velocidad definida.
    private void MoveForward()
    {
        Vector3 mov = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );

        transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);

        //rigidBody.position = new Vector2(Speed, rigidBody.position.x);

        //MoveCharacter.SetTrigger("IsWalking");
        //rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
    }

    // Función que mueve el personaje hacia arriba en base a una velocidad definida.
    private void MoveUp()
    {
       // MoveCharacter.SetTrigger("IsWalking");
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.x);
    }

    // Función que mueve el personaje hacia abajo en base a una velocidad definida.
    private void MoveDown()
    {
        //MoveCharacter.SetTrigger("IsWalking");
        rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.x);
    }

    // Función que mueve el personaje hacia atrás en base a una velocidad definida.
    private void MoveBackward()
    {
        //MoveCharacter.SetTrigger("IsWalking");
        rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
    }

    // Función que resetea el trigger cuando el personaje se deja de mover.
    private void StopMoving()
    {
        //MoveCharacter.ResetTrigger("IsWalking");
    }

    // Función que gestiona las animaciones.
    /*private void HandleAnimations()
    {
        if (!IsGrounded())
        {
            JumpCharacter.SetBool("IsJumping", true);
            JumpCharacter.SetFloat("VelocityY", 1 * Mathf.Sign(rigidBody.velocity.y));
        }

        if (IsGrounded())
        {
            JumpCharacter.SetBool("IsJumping", false);
            JumpCharacter.SetFloat("VelocityY", 0);
        }
    }*/


    // Función que comprueba si el personaje ha colisionado contra algún elemento.
    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        // Si el objeto contra el que se colisiona tiene el tag "EndOfLevel" es que hemos llegado al final de la partida.
        if (collider.gameObject.CompareTag("EndOfLevel"))
        {
            OnReachedEndOfLevelFlagStick?.Invoke();
        }
        // En cambio si el objeto tiene el tag "Enemy" o "HoleCollider" es que ha chocado contra un enemigo o se ha caído por el agujero.
        // Por lo tanto, el personaje muere.
        else if (collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("HoleCollider")) 
        {
            OnKilled?.Invoke();
        }
        else if (collider.gameObject.CompareTag("BrickMushroom"))
        {
            Mushroom?.Invoke();
        }
        else if (collider.gameObject.CompareTag("RoseMushroom"))
        {
            // Eliminamos la seta.
            Destroy(collider.gameObject);
            // Llamamos a la función GetSuperMario.
            GetSuperMario?.Invoke();
        }
    }*/
}
