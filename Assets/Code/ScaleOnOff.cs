using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnOff : MonoBehaviour
{
    public void ScaleOn (Transform transform)
    {
        transform.localScale = Vector3.one;
    }

    public void ScaleOff(Transform transform)
    {
        transform.localScale = Vector3.zero;
    }
}
