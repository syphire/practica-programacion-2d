using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float speed = 4f;
    public Transform Character;

    public Animator MoveCharacter;

    Vector2 desplazamiento;

    /*public Transform FeetLeft;
    public Transform FeetRight;
    public LayerMask GroundLayer;

    
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
        MoveCharacter.GetComponent<Animator>();
        //JumpCharacter.GetComponent<Animator>();
        //OneShoot.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Creamos un nuevo vector con el desplazamiento del personaje
        desplazamiento = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // Si el personaje se desplaza, indicamos los nuevos puntos del vector y arrancamos la animación.
        if (desplazamiento != Vector2.zero)
        {
            MoveCharacter.SetFloat("MovX", desplazamiento.x);
            MoveCharacter.SetFloat("MovY", desplazamiento.y);
            MoveCharacter.SetBool("IsWalking", true);
        }
        // Si el personaje está quieto volvemos a poner la animación a false.
        else
        {
            MoveCharacter.SetBool("IsWalking", false);
        }

        //HandleAnimations();
    }

    private void FixedUpdate()
    {
        // Movemos al personaje al nuevo punto
        rigidBody.MovePosition(rigidBody.position + desplazamiento * speed * Time.deltaTime);
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
