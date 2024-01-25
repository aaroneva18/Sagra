using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    //Variables del jugador PRIVADAS
    [Header("Private")]
    [SerializeField] float gizmoRadious; //Radio del gizmos de IsGrounded 
    [SerializeField] LayerMask Ground; //Layer mask del piso
    [SerializeField] GameObject feetPlayer; //Posición del pie del jugador para dectar el piso
    [SerializeField] bool isRunning; // Booleano que se activa cuando esta corriendo

    //COMPONENTES
    private Rigidbody2D rb2d; //Rigidbody del jugador
    private PlayerInput playerInput; //Nuevo sistema de input para el player


    //Varibales del jugador PUBLICAS
    [Header("Public")]
    public bool isGrounded; //Booleano que se activa cuando esta en el piso
    public float normalSpeedPlayerX; // Velocidad del jugador que se multiplica por el Axis X cuando camina
    public float sprintSpeedPlayerx; //Velocidad del jugador cuando esta corriendo
    public float speedPlayerY; // Velocidad del jugador que se multiplica por el Axis Y
    public float jumpForce; //Fuerza del salto del jugador


    // Start is called before the first frame update
    void Start()
    {
        //Obtención de componentes
        rb2d = GetComponent<Rigidbody2D>();    
        playerInput = GetComponent<PlayerInput>();

        //Declaración de variables


        //Todo lo demás

    }
    private void FixedUpdate() {
        //Llamado de funciones 
        movePlayer();
        jumpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Llamado de funciones 

    }

    public bool isOnAir() {
        //Detectamos si la velocidad en Y es diferente de 0 es que esta en el aire
        if (rb2d.velocity.y != 0) {
            return true;
        }
        return false;
    }
    //Movimiento del jugador 
    private void movePlayer() {

        //Aplicamos la velocidad en X y matenemos la misma velocidad en Y
        var move = playerInput.actions["Move"];
        rb2d.velocity = new Vector2 (move.ReadValue<Vector2>().x * normalSpeedPlayerX, rb2d.velocity.y);

        //Detectamos si se presiona el input para sprintear, ya sea que este en el aire o en el suelo
        var sprint = playerInput.actions["Sprint"];
        if (sprint.IsInProgress() && (isGrounded || isOnAir())) {
            normalSpeedPlayerX = sprintSpeedPlayerx;
            isRunning = true;
        } else {
            normalSpeedPlayerX = 7f;
            isRunning = false;
        }

    }


    private void jumpPlayer() {
        //Checamos si esta en el piso
        isGrounded = Physics2D.OverlapCircle(feetPlayer.transform.position, gizmoRadious, Ground);


        //Aplicamos la velocidad en Y si se detecta la tecla Space
        var jump = playerInput.actions["Jump"];
        if (isGrounded && jump.IsPressed()) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            
        }


        //Para la tecla W que solo se mueva la camara hacia arriba 

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPlayer.transform.position, gizmoRadious);
    }

}
