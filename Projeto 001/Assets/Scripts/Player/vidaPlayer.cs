using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaPlayer : MonoBehaviour
{
    public int vidaplayer = 10;
    public int vidaatual;


    void Start()
    {
        vidaatual = vidaplayer;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            vidaatual -= 1;
            if (vidaatual == 2)
            {
                Debug.Log("Hit!!");
            }
            else
            {
                if (vidaatual == 1)
                {
                    Debug.Log("Hit! Cuidado");
                }
                else
                {
                    if (vidaatual >= 0)
                    {

                        Debug.Log("Você morreu!");
                        
                        //GameObject.Destroy(gameobject); **Colocar depois


                    }

                }

            }

        }



    }


}
