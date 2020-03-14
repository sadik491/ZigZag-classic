using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundCheck : MonoBehaviour
{
    public Toggle toggle;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }
}
