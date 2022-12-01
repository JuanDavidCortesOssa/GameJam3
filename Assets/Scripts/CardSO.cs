using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardGame/Card", fileName = "card_")]
public class CardSO : ScriptableObject
{
    public Material upFaceMat;
    public Material downFaceMat;

    public int cardValue;
}
