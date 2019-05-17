using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeUsuario : MonoBehaviour
{

    private string puntajeUrl = "http://tadeolabhack.com:8081/test/Desmovilizaditos/PuntajeUsuario.php";
    private int[] decisiones = new int[4];
    public Text caja1;
    public Text caja2;
    public Text caja3;
    public Text caja4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(puntaje());
    }

    public IEnumerator puntaje()
    {
        WWWForm usuario = new WWWForm();
        usuario.AddField("IDuser", 5);

        WWW score = new WWW(puntajeUrl, usuario);
        yield return score;

        Debug.Log(score.text);

        if (!string.IsNullOrEmpty(score.text))
        {
            string[] puntajes = score.text.Split(char.Parse("-"));

            for (int i = 0; i < decisiones.Length; i++)
            {
                Debug.Log(puntajes[i]);
                decisiones[i] = int.Parse(puntajes[i]);

                switch (i)
                {
                    case 0:
                        texto(decisiones[i], caja1);
                        break;
                    case 1:
                        texto(decisiones[i], caja2);
                        break;
                    case 2:
                        texto(decisiones[i], caja3);
                        break;
                    case 3:
                        texto(decisiones[i], caja4);
                        break;
                }
            }
        }
    }

    public void texto(int decision, Text caja)
    {
        if (decision == 1)
        {
            caja.text = "Si";
        }
        else if (decision == 2)
        {
            caja.text = "No";
        }
        else
        {
            caja.text = "No aplica";
        }
    }
}
