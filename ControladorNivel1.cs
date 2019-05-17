using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PathCreation;

public class ControladorNivel1 : MonoBehaviour
{
    public float segundosAnimacion1;
    public float segundosAnimacion2;

    public Transform camara;
    public Transform nina;
    public CanvasGroup Fade;

    private float rotacion;
    public static bool rotarYMover;
    private bool finAni1 = false;
    private bool finAni2 = false;

    public float speedRot;
    public float speedMov;

    public PathCreator pathCreator;    
    public EndOfPathInstruction end;
    float dstTravelled;

    private bool finNivel1 = false;

    void Start()
    {
        StartCoroutine(EsperarAni1());
    }

    void Update()
    {
        rotacion = camara.transform.localRotation.eulerAngles.y;
        if (finAni1)
        {
            if (rotacion >= 100)
            {
                camara.transform.Rotate(Vector3.down, speedRot * Time.deltaTime);
            }
            else
            {
                StartCoroutine(EsperarAni2());
            }
        }
        else if (finAni2) {
            //Debug.Log(camara.rotation.eulerAngles.y);
            if (rotacion >= 1 && rotacion <= 200 && !rotarYMover)
            {
                camara.transform.Rotate(Vector3.down, speedRot * Time.deltaTime);
            }
            else
            {
                rotarYMover = true;
                dstTravelled += speedMov * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
                transform.rotation = pathCreator.path.GetRotationAtDistance(dstTravelled, end);
            }
        }

        finNivel1 = FinalNivel1.finalizo1;
        if (finNivel1)
        {
            Fade.alpha += 0.3f* Time.deltaTime;
            if (Fade.alpha == 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    //Cambiar esto cuando tenga el Animator
    public IEnumerator EsperarAni1()
    {
        yield return new WaitForSeconds(segundosAnimacion1);
        finAni1 = true;
    }

    public IEnumerator EsperarAni2()
    {
        yield return new WaitForSeconds(segundosAnimacion2);
        finAni2 = true;
        finAni1 = false;
    }
}
