using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CultivatorMachine : MonoBehaviour
{

    public GameObject cebada;
    public GameObject lupulo;
    bool runOnce;
    bool gotToSpawn;
    Vector2 spawnCoordinates;
    public int semillasCebada;
    int semillasLupulo;
    public float velocidadDeCultivo;
    public int limiteSemillas;
    public bool encendido;
    Vector2[] vertices;
    SpriteRenderer spriteRenderer;
    Sprite sprite;
    public GameObject Text;
    Coroutine lastRoutine;
    // Start is called before the first frame update
    void Start()
    {
        gotToSpawn = true;
        spawnCoordinates = transform.position;
        runOnce = false;
        encendido = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
        vertices = sprite.vertices;
        for (int i = 0; i<vertices.Length; ++i){
            Debug.Log((vertices)[i].x + " " + vertices[i].y);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (encendido && semillasCebada > 0){
            if (runOnce == false){
                lastRoutine = StartCoroutine(intermitencia());
                runOnce = true;
            }
            
            transform.position = transform.position + new Vector3(2.5f * Time.deltaTime, 0.0f, 0.0f);
        } else{
            if (runOnce == true){
                StopCoroutine(lastRoutine);
                runOnce = false;
            }
            if (!gotToSpawn){
                transform.position = transform.position - new Vector3(2.5f * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        


        if (Vector2.Distance(spawnCoordinates, transform.position) < 0.2){
            gotToSpawn = true;
            //encendido = false;
        } else{
            gotToSpawn = false;
        }

        if (encendido){
            Text.GetComponent<TMP_Text>().text = "Turned on, Press 'O' to turn off. Seeds charged: " + semillasCebada + ", press 'K' to load more (MAX: " + limiteSemillas + ")";
        }
        else{
            Text.GetComponent<TMP_Text>().text = "Turned off, Press 'O' to turn on. Seeds charged: " + semillasCebada + ", press 'K' to load more (MAX: " + limiteSemillas + ")";
        }
        
    }

    IEnumerator intermitencia(){
        while(true){
            
            yield return new WaitForSeconds(velocidadDeCultivo);
            //Debug.Log("intermitencia");
            Plantar();
        }
        
    }

    public void cargarSemillas(int cebada, int lupulo){
        semillasCebada += cebada;
        semillasLupulo += lupulo;
    }
    void Plantar(){ // 0 = Cebada, 1 = Lupulo
        if (semillasCebada > 0){
            Instantiate(cebada, gameObject.transform.position, Quaternion.identity);
            semillasCebada -= 1;
        }
    }


    
}
