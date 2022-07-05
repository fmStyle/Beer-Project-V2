using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuncionesBoton : MonoBehaviour
{
    InventarioJugador inventarioJugador;
    public GameObject maquina, pipePozo, pipeFabrica;
    //public TMP_Text texto1, texto2, texto3, texto4;
    bool machineBought;
    
    void Start(){
        inventarioJugador = GetComponent<InventarioJugador>();
        machineBought = false;
    }

    public void ComprarSemillasCebada(){
        if (inventarioJugador.dinero >= 20.0f){
        inventarioJugador.semillasCebada += 1;
        inventarioJugador.dinero -= 20.0f;
        }

    }
    public void ComprarLupulo(){
        if (inventarioJugador.dinero >= 10.0f){
        inventarioJugador.lupulo += 1;
        inventarioJugador.dinero -= 10.0f;
        }

    }
    public void ComprarMaquina(){
        if (machineBought == false && inventarioJugador.dinero >- 300.0f){
            maquina.SetActive(true);
            inventarioJugador.dinero -= 300.0f;
            machineBought = true;
        }
    }
    public void ComprarPipes(){
        if (inventarioJugador.pipesCompradas == false && inventarioJugador.dinero >= 750.0f){
            pipePozo.SetActive(true);
            pipeFabrica.SetActive(true);
            inventarioJugador.pipesCompradas = true;
            inventarioJugador.dinero -= 750.0f;
        }
    }
    public void ComprarLupuloIndio(){
        if (inventarioJugador.dinero >= 20.0f){
            inventarioJugador.lupuloindio += 1;
            inventarioJugador.dinero -= 20.0f;
        }
    }
    public void FabricarCervezaRubia(){
        if (inventarioJugador.pipesCompradas == false){
                if (inventarioJugador.agua >= 1 && inventarioJugador.cebada >=1 && inventarioJugador.lupulo >=1){
                    inventarioJugador.cerveza1 += 1;
                    inventarioJugador.agua -= 1;
                    inventarioJugador.cebada -= 1;
                    inventarioJugador.lupulo -= 1;
                }
            } else{
                if (inventarioJugador.cebada >=1 && inventarioJugador.lupulo >=1){
                    inventarioJugador.cerveza1 += 1;
                    inventarioJugador.cebada -= 1;
                    inventarioJugador.lupulo -= 1;
                }        
        }
            
    }
    public void FabricarCervezaRoja(){
        if (inventarioJugador.pipesCompradas == false){
                if (inventarioJugador.agua >= 1 && inventarioJugador.cebada >=1 && inventarioJugador.lupuloindio >=1){
                    inventarioJugador.cerveza2 += 1;
                    inventarioJugador.agua -= 1;
                    inventarioJugador.cebada -= 1;
                    inventarioJugador.lupuloindio -= 1;
                }
            } else{
                if (inventarioJugador.cebada >=1 && inventarioJugador.lupuloindio >=1){
                    inventarioJugador.cerveza2 += 1;
                    inventarioJugador.cebada -= 1;
                    inventarioJugador.lupuloindio -= 1;
                }        
        }
    }
}
