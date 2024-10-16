using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igura : MonoBehaviour
{
    Vector3 distancia;
    private void Start()
    {
        distancia = transform.position - Camera.main.transform.position;
    }
    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos + distancia;
    }

}
