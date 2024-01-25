using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryScript : MonoBehaviour
{


    //poder cambiar el inventario en los arboles

    //Variables del Inventario PRIVADAS
    [SerializeField] WeaponScript[] WeaponInventary; //Array de armas para crear un inventario

    private WeaponTypes weaponTypes;
    private int inputNumberCase; //Cambiador de switch case dependiendo la tecla

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeWeapon();
    }

    private void changeWeapon() {

        //Quitar el input system viejo 

        //Detectamos que tecla del numero se presionó
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Se presionó 1");
            inputNumberCase = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("Se presionó 2");
            inputNumberCase = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("Se presionó 3");
            inputNumberCase = 3;
        }

        //Dependiendo de que tecla se presiona, hacemos un switch case
        switch (inputNumberCase) {

            //Casos esperados: Tecla 1, Tecla 2, Tecla 3.
            case (1):
                WeaponInventary[0].gameObject.SetActive(true);
                WeaponInventary[1].gameObject.SetActive(false);
                WeaponInventary[2].gameObject.SetActive(false);

                break;

            case (2):
                WeaponInventary[1].gameObject.SetActive(true);
                WeaponInventary[0].gameObject.SetActive(false);
                WeaponInventary[2].gameObject.SetActive(false);

                break;

            case (3):
                WeaponInventary[2].gameObject.SetActive(true);
                WeaponInventary[0].gameObject.SetActive(false);
                WeaponInventary[1].gameObject.SetActive(false);

                break;
        }

    }

    enum WeaponTypes {
        sword,
        shield
    }


}
