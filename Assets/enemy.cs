using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void Start()
    {
        Spin();
    }

    void Spin()
    {
        InvokeRepeating("KeepSpinning", 0f, 0.01f);
    }

    void KeepSpinning()
    {
        transform.Rotate(Vector3.up, 999f * Time.deltaTime);
    }
}
