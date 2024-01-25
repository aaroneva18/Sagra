using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    //Variables del enemigo PROTEGIDAS
    protected int enemyHealth; //vida del enemigo
    protected int enemyStamina; //estamina del enemigo
    protected int enemyDamage; //daño que hace el enemigo
    protected Vector2 enemyVelocity; //vector de velocidad del enemigo
    protected Collider2D[] enemyColliders; //colliders con los que percibe el enemigo 

    //Variables del enemigo PRIVADAS
    [SerializeField] LayerMask Ground; //Layer mask del piso
    private bool boolGround; //Booleano para detectar si esta en el piso

    //Variables del enemigos PUBLICAS
    public float gizmoRadious; //Radio del gizmos de los pies
    public GameObject feetPosition; //pies del enemigo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion para dectectar si esta en el piso
    public bool isGrounded() {   
        boolGround = Physics2D.OverlapCircle(feetPosition.transform.position, gizmoRadious, Ground);
        return boolGround;
    }

    //función para hacer daño al enemigo
    public void getDamage(int p_damage) {
        enemyHealth -= p_damage; 
    }

    //función para hacer daño al enemigo
    public void getHealed(int p_heal) {
        enemyHealth += p_heal;
    }

    //Funcion para dibujar los Gizmos
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPosition.transform.position, gizmoRadious);
    }
}
