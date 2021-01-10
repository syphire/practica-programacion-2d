using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private float speed = 4f;
    public Transform Character;
    public GameObject Puerta;
    public Text Corazones;

    public Animator MoveCharacter;

    public AudioSource AudioCofre;
    public AudioSource AudioTrap;

    public Action GetCofre;
    public Action GoToSecondLevel;
    public Action EndGame;
    public Action FinishGame;

    private float numeroCofres = 0f;
    public float delayTime = 0.3f;

    private Vector2 desplazamiento;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        MoveCharacter.GetComponent<Animator>();

        AudioCofre.GetComponent<AudioSource>();
        AudioTrap.GetComponent<AudioSource>();
        Corazones.GetComponent<Text>();

        Puerta.GetComponent<GameObject>();
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
    }

    private void FixedUpdate()
    {
        // Movemos al personaje al nuevo punto
        rigidBody.MovePosition(rigidBody.position + desplazamiento * speed * Time.deltaTime);
    }

    // Función que comprueba si el personaje ha colisionado contra algún elemento.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Si el objeto contra el que se colisiona tiene el tag "Cofre" es que ha cogido un cofre.
        if (collider.gameObject.CompareTag("Cofre"))
        {
            // Reproducimos el audio del cofre.
            AudioCofre.Play();
            // Al colisionar se destruye el cofre.
            Destroy(collider.gameObject);

            numeroCofres++;

            if (numeroCofres == 6)
            {
                Destroy(Puerta);
            }
        }
        else if (collider.gameObject.CompareTag("Pinchos"))
        {   
            if (Corazones.text == "1")
            {
                // Si perdemos los 3 corazones de vida, el personaje muere y reiniciamos el nivel.
                Corazones.text = "0";
                AudioTrap.Play();
                EndGame?.Invoke();
            }
            else if (Corazones.text == "2")
            {
                // Cuando colisionamos contra pinchos, reproducimos el audio correspondiente y perdemos vida.
                Corazones.text = "1";
                AudioTrap.Play();
            }
            else if (Corazones.text == "3")
            {
                // Cuando colisionamos contra pinchos, reproducimos el audio correspondiente y perdemos vida.
                Corazones.text = "2";
                AudioTrap.Play();
            }
        }
        else if (collider.gameObject.CompareTag("Puerta"))
        {
            // Cuando colisionamos con el hueco de la puerta, pasamos al siguiente nivel.
            GoToSecondLevel?.Invoke();
        }
        else if (collider.gameObject.CompareTag("GranCofre"))
        {
            // Cuando abrimos el gran cofre, terminamos la partida.
            FinishGame?.Invoke();
        }
    }
}
