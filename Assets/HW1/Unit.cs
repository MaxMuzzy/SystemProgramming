using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    int health = 50;
    private Coroutine cor;

    private void Start()
    {
        ReceiveHealing();
    }
    public void ReceiveHealing()
    {
        if (cor == null)
        {
            cor = StartCoroutine(StartHealing());
        }
    }
    IEnumerator StartHealing()
    {
        int i = 6;
        while(true)
        {
            if (health < 100)
            {
                health += 5;
                if (health > 100)
                {
                    health = 100;
                    break;
                }
                Debug.Log(health);
            }
            i--;
            if (i == 0)
            {
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}