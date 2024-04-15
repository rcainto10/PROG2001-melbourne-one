using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            Destroy(gameObject);
            ScoreImplementer.scoreCount += 1;
        }
    }
}
