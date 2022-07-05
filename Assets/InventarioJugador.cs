using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventarioJugador : MonoBehaviour
{
    public int semillasCebada;
    public int cebada;
    public int semillasLupulo;
    public int lupulo;
    public int lupuloindio;
    public int agua;
    public int maxAgua;
    public int cerveza1;
    public int cerveza2;
    public float dinero;
    public float precioCerveza1Inicial;
    public float precioCerveza2Inicial;
    public float precioCerveza1;
    public float precioCerveza2;
    public int qCerveza1;
    public int qCerveza2;

    public bool pipesCompradas;

    public List<TMP_Text> items;

    // Start is called before the first frame update
    void Start()
    {
        pipesCompradas = false;
        //items = new List<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        items[0].text = agua.ToString();
        items[1].text = semillasCebada.ToString();
        items[2].text = cebada.ToString();
        items[3].text = lupulo.ToString();
        items[4].text = cerveza1.ToString();
        items[5].text = dinero.ToString();
        items[6].text = lupuloindio.ToString();
        items[7].text = cerveza2.ToString();
        items[8].text = "$" + precioCerveza1.ToString();
        items[9].text = "$" + precioCerveza2.ToString();
    }
}
