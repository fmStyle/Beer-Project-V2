using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerCebada : MonoBehaviour
{
    //List 
    float timer;
    float timer2;
    bool estaCercaDelPozo;
    public GameObject menuTienda;
    public GameObject menuFabricar;

    InventarioJugador inventarioJugador;
    void Start()
    {
        timer = 0;
        timer2 = 0;
        estaCercaDelPozo = false;
        inventarioJugador = GetComponent<InventarioJugador>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (estaCercaDelPozo && Input.GetKeyDown(KeyCode.O)){
    //         if (inventarioJugador.agua < inventarioJugador.maxAgua){
    //             inventarioJugador.agua += 1;
    //         }
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D collision){
    //     if (collision.gameObject.tag == "Pozo"){
    //         estaCercaDelPozo = true;
    //     }
    // }
    // void OnTriggerExit2D(Collider2D collision){
    //     if (collision.gameObject.tag == "Pozo"){
    //         estaCercaDelPozo = false;
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Tienda"){
            menuTienda.SetActive(true);
        }
        if (collision.gameObject.tag == "Fabricar"){
            menuFabricar.SetActive(true);
        }
    }
     void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Tienda"){
            menuTienda.SetActive(false);
        }
        if (collision.gameObject.tag == "Fabricar"){
            menuFabricar.SetActive(false);
        }
    }

    void Update(){
        inventarioJugador.precioCerveza2 = inventarioJugador.precioCerveza2Inicial - (inventarioJugador.qCerveza2/(inventarioJugador.qCerveza1 + 1));
        inventarioJugador.precioCerveza1 = inventarioJugador.precioCerveza1Inicial - (inventarioJugador.qCerveza1/(inventarioJugador.qCerveza2 + 1));
        timer += Time.deltaTime;
        if (timer >= 15.0f){
            Debug.Log(timer);
            timer2 += Time.deltaTime;
            
            if (timer2 > 2.0f){
                if (inventarioJugador.qCerveza1 > 0){
                    inventarioJugador.qCerveza1 -= 1;
                }
                if (inventarioJugador.qCerveza2 > 0){
                    inventarioJugador.qCerveza2 -= 1;
                }
                timer2 = 0.0f;
            }
            // inventarioJugador.qCerveza1 = 0;
            // inventarioJugador.qCerveza2 = 0;

        }
    }

    void OnTriggerStay2D(Collider2D collision){
        Debug.Log("Ok");
        if (collision.gameObject.tag == "Cebada" && (collision.gameObject.GetComponent<CebadaEstado>().estado == 3 || collision.gameObject.GetComponent<CebadaEstado>().estado == 4) && Input.GetKeyDown(KeyCode.O)){
            if (collision.gameObject.GetComponent<CebadaEstado>().destroyed == false){
                inventarioJugador.cebada += 1;
                inventarioJugador.semillasCebada += 1;
            }
            collision.gameObject.GetComponent<CebadaEstado>().destroyed = true;
        }
        if (collision.gameObject.tag == "Lupulo" && collision.gameObject.GetComponent<LupuloEstado>().estado == 3 && Input.GetKeyDown(KeyCode.O)){
            if (collision.gameObject.GetComponent<LupuloEstado>().destroyed == false){
                inventarioJugador.lupulo += 1;
                inventarioJugador.semillasLupulo += 1;
            }
            collision.gameObject.GetComponent<LupuloEstado>().destroyed = true;
        }
        if (collision.gameObject.tag == "Pozo" && Input.GetKeyDown(KeyCode.O)){
            
            if (inventarioJugador.agua < inventarioJugador.maxAgua){
                inventarioJugador.agua += 1;
                Debug.Log(inventarioJugador.agua);
            }
        }
        if (collision.gameObject.tag == "Fabricar" ){
            // if (Input.GetKeyDown(KeyCode.O)){
            // if (inventarioJugador.pipesCompradas == false){
            //     if (inventarioJugador.agua >= 1 && inventarioJugador.cebada >=1 && inventarioJugador.lupulo >=1){
            //         inventarioJugador.cerveza1 += 1;
            //         inventarioJugador.agua -= 1;
            //         inventarioJugador.cebada -= 1;
            //         inventarioJugador.lupulo -= 1;
            //     }
            // } else{
            //     if (inventarioJugador.cebada >=1 && inventarioJugador.lupulo >=1){
            //         inventarioJugador.cerveza1 += 1;
            //         inventarioJugador.cebada -= 1;
            //         inventarioJugador.lupulo -= 1;
            //     }        
            // }
            // }
            // if (Input.GetKeyDown(KeyCode.P)){
            //     if (inventarioJugador.pipesCompradas == false){
            //     if (inventarioJugador.agua >= 1 && inventarioJugador.cebada >=1 && inventarioJugador.lupuloindio >=1){
            //         inventarioJugador.cerveza2 += 1;
            //         inventarioJugador.agua -= 1;
            //         inventarioJugador.cebada -= 1;
            //         inventarioJugador.lupuloindio -= 1;
            //     }
            // } else{
            //     if (inventarioJugador.cebada >=1 && inventarioJugador.lupuloindio >=1){
            //         inventarioJugador.cerveza2 += 1;
            //         inventarioJugador.cebada -= 1;
            //         inventarioJugador.lupuloindio -= 1;
            //     }        
            // }
            // }

        }
        if (collision.gameObject.tag == "Venta" && Input.GetKeyDown(KeyCode.O)){
            Debug.Log("OK");
            if (inventarioJugador.cerveza1 >= 1){
                timer = 0.0f;
                inventarioJugador.cerveza1 -= 1;
                inventarioJugador.dinero += inventarioJugador.precioCerveza1;
                inventarioJugador.qCerveza1 += 1;
                // xinventarioJugador.qCerveza2 = 0;
            }
        }
        if (collision.gameObject.tag == "Venta1" && Input.GetKeyDown(KeyCode.O)){
            Debug.Log("OK");
            if (inventarioJugador.cerveza2 >= 1){
                inventarioJugador.cerveza2 -= 1;
                inventarioJugador.dinero += inventarioJugador.precioCerveza2;
                
                inventarioJugador.qCerveza2 += 1;
                // inventarioJugador.qCerveza1 = 0;
                timer = 0.0f;
            }
        }
        // if (collision.gameObject.tag == "Tienda"){
        //     //
        //     // Cambiar luego el 20.0f por una variable de precio de las semillas
        //     if (Input.GetKeyDown(KeyCode.O) && inventarioJugador.dinero >= 20.0f){
        //         inventarioJugador.semillasCebada += 1;
        //         inventarioJugador.dinero -= 20.0f;
        //     }
        //     if (Input.GetKeyDown(KeyCode.I) && inventarioJugador.dinero >= 10.0f){
        //         inventarioJugador.lupulo += 1;
        //         inventarioJugador.dinero -= 10.0f;
        //     }

        // }
        if (collision.gameObject.tag == "Cultivator Machine"){
            if (Input.GetKeyDown(KeyCode.O)){
                if (collision.gameObject.GetComponent<CultivatorMachine>().encendido == true){
                    collision.gameObject.GetComponent<CultivatorMachine>().encendido = false;
                }
                else{
                    collision.gameObject.GetComponent<CultivatorMachine>().encendido = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.K)){
                if (inventarioJugador.semillasCebada > 0 && collision.gameObject.GetComponent<CultivatorMachine>().semillasCebada
                <= collision.gameObject.GetComponent<CultivatorMachine>().limiteSemillas){
                    inventarioJugador.semillasCebada -= 1;
                    collision.gameObject.GetComponent<CultivatorMachine>().cargarSemillas(1, 0);
                }
            }
        }

    }
}
