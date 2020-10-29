using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirmed = delegate { };
    public event Action PressedCanceled = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };

    public event Action Pressed1 = delegate { };
    public event Action Pressed2 = delegate { };
    public event Action Pressed3 = delegate { };
    public event Action Pressed4 = delegate { };

    public void Detect1()
    {
        Pressed1.Invoke();
    }

    public void Detect2()
    {
        Pressed2.Invoke();
    }

    public void Detect3()
    {
        Pressed3.Invoke();
    }

    public void Detect4()
    {
        Pressed4.Invoke();
    }

    public void DetectRight()
    {
        PressedRight?.Invoke();
    }

    public void DetectLeft()
    {
        PressedLeft?.Invoke();
    }

    public void DetectCancel()
    {
        PressedCanceled?.Invoke();
    }

    public void DetectConfirm()
    {
        PressedConfirmed?.Invoke();
    }
}
