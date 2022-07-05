using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CebadaEstado : MonoBehaviour
{
    public Sprite primerEstadoSprite;
    public Sprite segundoEstadoSprite;
    public Sprite tercerEstadoSprite;
    public GameObject cuervo;
    //public Sprite cuartoEstadoSprite;

    SpriteRenderer spriteRenderer;

    public bool destroyed;

    public int estado;
    private float timer;
    public float primerEstado;
    public float segundoEstado;
    public float tercerEstado;
    public float cuartoEstado;
    public float quintoEstado;
    // Start is called before the first frame update
    void Start()
    {
        //primerEstadoSprite.size = new Vector2(1.0f, 1.0f);

        destroyed = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0.0f;
        estado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        if (timer > primerEstado && timer < segundoEstado && estado == 0){
            estado = 1;
            spriteRenderer.sprite = primerEstadoSprite;
        }
        if (timer > segundoEstado && timer < tercerEstado && estado == 1){
            estado = 2;
            spriteRenderer.sprite = segundoEstadoSprite;
        }
        if (timer > tercerEstado && estado == 2){
            estado = 3;
            spriteRenderer.sprite = tercerEstadoSprite;
        }
        if (timer > cuartoEstado && estado == 3){
            estado = 4;
            cuervo.SetActive(true);
            //spriteRenderer.sprite = cuartoEstadoSprite;
        }
        if (timer > quintoEstado && estado == 4){
            destroyed=true;
        }
        if (destroyed){
            Destroy(gameObject);
        }
    }
}
