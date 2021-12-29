using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour

    
{
    public float targetclicks;
    public Image Fill; 

    float TotalClicks;

    private void Start()
    {
        TotalClicks = 0;
        Fill.fillAmount = 0;
    }
    public void AddClicks()
    {
        TotalClicks++;
        Fill.fillAmount = TotalClicks / targetclicks;
    }

}
