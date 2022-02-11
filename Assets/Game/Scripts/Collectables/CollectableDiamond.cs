using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableDiamond : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.theDiamond += 1;
    }
}
