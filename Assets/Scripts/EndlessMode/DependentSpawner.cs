using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependentSpawner : MonoBehaviour
{
    public void spawn(GameObject x, Vector3 shake)
    {
        Vector3 posn = this.transform.position + shake;
        Instantiate(x, posn, Quaternion.identity);
    }


}