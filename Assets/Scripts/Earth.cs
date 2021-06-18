using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        int x = 0;

        gameObject.transform.localRotation = Quaternion.Euler(-90, x, 307);

        while (x < 360)
        {
            gameObject.transform.localRotation = Quaternion.Euler(-90, x, 307);
            if (x > 359) { x = 0; }
            x++;
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(Spin());

    }
}

