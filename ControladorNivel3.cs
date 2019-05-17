using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ControladorNivel3 : MonoBehaviour
{
    public float segundosAnimacion1;
    public float segundosAnimacion2;

    public Transform camara;
    public CanvasGroup Fade;

    public static bool rotarYMover = true;

    public float speedMov;

    public PathCreator pathPrincipal;
    public PathCreator pathSecundario;
    public PathCreator pathDec6_A;
    public PathCreator pathDec6_B;
    public EndOfPathInstruction endPrincipal;
    public EndOfPathInstruction endDec6;
    private float distPrincipal;
    private float distSecundario;
    private float dist6_A;
    private float dist6_B;

    public Animator Coronel;
    public float espera;

    private bool finAni1 = false;

    private bool caminoPrincipal = true;
    private bool caminoSecundario = false;

    private bool Dec6 = true;
    private bool Dec6_A = false;
    private bool Dec6_B = false;

    public static int Dec3php = 0;
    public static int Dec4php = 0;

    void Update()
    {
        if (caminoPrincipal && distPrincipal < 57)
        {
            if (Fade.alpha > 0)
            {
                Fade.alpha -= 0.3f * Time.deltaTime;
            }
            //Debug.Log(distPrincipal);
            distPrincipal += speedMov * Time.deltaTime;
            transform.position = pathPrincipal.path.GetPointAtDistance(distPrincipal, endPrincipal);
            transform.rotation = pathPrincipal.path.GetRotationAtDistance(distPrincipal, endPrincipal);
        }
        else if (!finAni1)
        {
            StartCoroutine(Esperar());
            if (cambioEscena.decision == 2)
            {
                Coronel.SetBool("Murio", true);
                Dec3php = 1;
            }

            if (!ObservadorNivel3.animacionCoronel)
            {
                finAni1 = true;
                Debug.Log("Esto");
                StartCoroutine(EsperarMuerte());
            }
        } 
        else if (caminoSecundario && distSecundario < 27)
        {
            //Debug.Log(distSecundario);
            distSecundario += speedMov * Time.deltaTime;
            transform.position = pathSecundario.path.GetPointAtDistance(distSecundario, endPrincipal);
            transform.rotation = pathSecundario.path.GetRotationAtDistance(distSecundario, endPrincipal);
        }
        else
        {
            if (Dec6)
            {
                StartCoroutine(Dec6_Esperar());
                if (cambioEscena.decision == 3)
                {
                    Dec6_B = true;
                    Dec6 = false;
                }
            }
            else
            {
                if (Dec6_A)
                {
                    dist6_A += speedMov * Time.deltaTime;
                    transform.position = pathDec6_A.path.GetPointAtDistance(dist6_A, endDec6);
                    transform.rotation = pathDec6_A.path.GetRotationAtDistance(dist6_A, endDec6);
                    Dec4php = 1;
                    if (FinalNivel3.finalizo3)
                    {
                        Fade.alpha += 0.3f * Time.deltaTime;
                        //Debug.Log("Holi");
                    }
                }
                else if (Dec6_B)
                {
                    dist6_B += speedMov * Time.deltaTime;
                    transform.position = pathDec6_B.path.GetPointAtDistance(dist6_B, endDec6);
                    transform.rotation = pathDec6_B.path.GetRotationAtDistance(dist6_B, endDec6);
                    Dec4php = 2;
                    Debug.Log("Esto");
                    if (FinalNivel3.finalizo3)
                    {
                        Fade.alpha += 0.3f * Time.deltaTime;
                        //Debug.Log("Holi");
                    }
                }
            }
        }
    }

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(espera);
        finAni1 = true;
        caminoPrincipal = false;
        caminoSecundario = true;
        Dec3php = 2;
    }

    public IEnumerator EsperarMuerte()
    {
        yield return new WaitForSeconds(3);
        caminoPrincipal = false;
        caminoSecundario = true;
    }

    public IEnumerator Dec6_Esperar()
    {
        //Debug.Log("Mierdaaaa");
        yield return new WaitForSeconds(espera);
        if (!Dec6_B)
        {
            Dec6_A = true;
            Dec6 = false;
        }
    }

}
