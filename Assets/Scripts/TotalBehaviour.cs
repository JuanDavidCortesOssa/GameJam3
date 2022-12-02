using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalBehaviour : MonoBehaviour
{
    public int value;
    public ParticleSystem confetiParticles;
    public TextMeshProUGUI text;

    public void Activate()
    {
        text.color = Color.green;
        confetiParticles.Play();
    }
        
}
