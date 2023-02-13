using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class inimigoVida : MonoBehaviour
{
    public int vidaInimigo;
    public int vidaAtual;


    void Start()
    {
        vidaAtual = vidaInimigo;
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            vidaAtual -= 1;
            if (vidaAtual == 2)
            {
                Debug.Log("Hit!");
            }
            else
            {

                if (vidaAtual == 1)
                {
                    Debug.Log("Hit!");
                }
                else
                {
                    if (vidaAtual >= 0)
                    {
                        GameObject.Destroy(gameObject);


                    }

                }
            }

        }

    }
}

