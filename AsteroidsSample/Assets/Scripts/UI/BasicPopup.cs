using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BasicPopup : MonoBehaviour
{


    public void DisplayPopup(bool value)
    {
        gameObject.SetActive(value);
        Debug.Log($"Displaying {gameObject.name}");
    }

    public virtual void setText()
    {

    }
}
