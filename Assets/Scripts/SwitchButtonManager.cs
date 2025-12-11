using UnityEngine;
using System.Collections.Generic;

public class SwitchButtonManager : MonoBehaviour
{
    public static SwitchButtonManager instance;

    public List<SwitchButton> buttons = new List<SwitchButton>();

    private void Awake()
    {
        instance = this;
    }

    public bool AnyButtonActive()
    {
        foreach (var btn in buttons)
            if (SwitchButtonGlobal.isSwitchActive)
                return true;

        return false;
    }
}
