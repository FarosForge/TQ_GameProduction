using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
