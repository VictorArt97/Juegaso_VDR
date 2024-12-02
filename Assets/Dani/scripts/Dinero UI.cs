using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DineroUI : MonoBehaviour
{
  public Text textoDinero;

    // Update is called once per frame
    void Update()
    {
        textoDinero.text = Player_Stats.Dinero.ToString();
    }
}
