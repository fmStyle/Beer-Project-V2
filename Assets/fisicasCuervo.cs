using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisicasCuervo : MonoBehaviour
{
    //public GameObject parent;
    float angulo;
    Rigidbody2D rigidbody;
    float velocityX;
    float velocityY;
    public float velocidad = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(0.1f, 0.1f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 thisPosition = gameObject.transform.position;
        Vector2 parentPosition = transform.parent.position;
        parentPosition.y += 1.0f;
        angulo = Mathf.Atan2(thisPosition.y - parentPosition.y, thisPosition.x - parentPosition.x);
        Debug.Log(angulo);
        velocityX += Mathf.Cos(angulo + Mathf.PI)*6*Time.deltaTime;
        velocityY += Mathf.Sin(angulo + Mathf.PI)*Time.deltaTime;
        Vector2 newVector = new Vector2(velocityX, velocityY);
        rigidbody.velocity = newVector;
    }
}
