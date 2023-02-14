using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public int vidaplayer;
    public int vidaatual;

    [SerializeField] UnityEngine.UI.Image vidaOn;
    [SerializeField] UnityEngine.UI.Image vidaOff;
    [SerializeField] UnityEngine.UI.Image vidaOn1;
    [SerializeField] UnityEngine.UI.Image vidaOff1;
    [SerializeField] UnityEngine.UI.Image vidaOn2;
    [SerializeField] UnityEngine.UI.Image vidaOff2;

    void Start()
    {
        vidaatual = vidaplayer;
    }

    // Update is called once per frame
    void Update()
    {
    }

    #region OnTrigger 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Dano();


        }

    }
    #endregion

    #region Dano
    public void Dano()
    {
        vidaatual -= 1;
        if (vidaatual <= 15)
        {
            vidaOn2.enabled = true; //Coração vazio
            vidaOff2.enabled = false; //coração preenchido
        }
        else
        {
            vidaOn2.enabled = false;
            vidaOff2.enabled = true;
        }
        if (vidaatual <= 5)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;

            vidaOn1.enabled = true;
            vidaOff1.enabled = false;
        }
        else
        {
            vidaOn1.enabled = false;
            vidaOff1.enabled = true;
        }
        if (vidaatual <= 0)
        {
            vidaOn.enabled = true;
            vidaOff.enabled = false;
            Debug.Log("Você morreu!");
            GameObject.Destroy(gameObject);

        }


    }
    #endregion
}
