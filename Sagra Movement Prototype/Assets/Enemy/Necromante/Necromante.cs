using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que hereda del script: "EnemyScript"
public class Necromante : EnemyScript
{

    //variables del necromante PRIVADAS
    private Rigidbody2D rb2d; //Rigidbody del necromante
    private Animator ani; //animator del necromante


    // Start is called before the first frame update
    void Start()
    {
        //Obtencion de componentes
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        //Declaración de variables


        //Todo lo demás


    }

    // Update is called once per frame
    void Update()
    {
        percebe();
        decide();
        act();
    }

    //percibo, decido, actúo 

    //función para percibir
    public void percebe() {
        
        if (isGrounded()) {
            Debug.Log("Esta en el piso");
        }
    }

    //función para decidir
    public void decide() {

    }

    //función para actuar
    public void act() {

    }

    //funcion para que ataque el necromante
    public void attack() {

    }
}
