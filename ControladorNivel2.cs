using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PathCreation;

public class ControladorNivel2 : MonoBehaviour
{

    public float segundosAnimacion1;
    public float segundosAnimacion2;

    public Transform camara;
    public CanvasGroup Fade;

    public static bool rotarYMover = true;

    public float speedMov;

    public PathCreator pathPrincipal;
    public PathCreator pathDec2_A;
    public PathCreator pathDec2_B;
    public EndOfPathInstruction endPrincipal;
    public EndOfPathInstruction endDec2;
    private float distPrincipal;
    private float dist2_A;
    private float dist2_B;

    public Animator animal;
    public float espera;

    private bool finAni1 = false;
    private bool finAni2 = false;

    private bool caminoPrincipal;

    private bool Dec2 = true;
    private bool Dec2_A = false;
    private bool Dec2_B = false;

    private ConexionPHP php = new ConexionPHP();
    public static int Dec1php = 0;
    public static int Dec2php = 0;

    void Update()
    {
        if (distPrincipal >= 27 && !finAni1)
        {
            caminoPrincipal = false;
        }
        else
        {
            caminoPrincipal = true;
        }

        if (caminoPrincipal && distPrincipal < 74)
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
                animal.SetBool("Disparo", true);
                Dec1php = 1;
            }

            if (!ObservadorNivel2.animacionAnimal)
            {
                finAni1 = true;
            }
        }
        else
        {
            if (Dec2)
            {
                StartCoroutine(Dec2_Esperar());
                if (cambioEscena.decision == 3)
                {
                    Dec2_B = true;
                    Dec2 = false;
                    Dec2php = 1;
                }
            }
            else
            {
                if (Dec2_A)
                {
                    dist2_A += speedMov * Time.deltaTime;
                    transform.position = pathDec2_A.path.GetPointAtDistance(dist2_A, endDec2);
                    transform.rotation = pathDec2_A.path.GetRotationAtDistance(dist2_A, endDec2);
                    if (FinalNivel2.finalizo2)
                    {
                        Fade.alpha += 0.3f * Time.deltaTime;
                        //Debug.Log("Holi");
                        if (Fade.alpha == 1)
                        {
                            SceneManager.LoadScene(2);
                        }
                    }
                }
                else if (Dec2_B)
                {
                    Debug.Log(dist2_B);
                    dist2_B += speedMov * Time.deltaTime;
                    transform.position = pathDec2_B.path.GetPointAtDistance(dist2_B, endDec2);
                    transform.rotation = pathDec2_B.path.GetRotationAtDistance(dist2_B, endDec2);
                }
            }
        }
    }

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(espera);
        animal.SetBool("NoDisparo", true);
        Dec1php = 2;
    }

    public IEnumerator Dec2_Esperar()
    {
        yield return new WaitForSeconds(espera);
        if (!Dec2_B)
        {
            Dec2_A = true;
            Dec2 = false;
            Dec2php = 2;
        }   
    }

}
