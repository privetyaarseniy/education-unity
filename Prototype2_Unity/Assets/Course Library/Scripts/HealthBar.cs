using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void Feed()
    {
        if(slider.value <= 1)
        {
            slider.value--;
            Destroy(gameObject);
            UI.ScoreUp();
        }

        slider.value--;
    }
}
