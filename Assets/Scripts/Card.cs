using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //public variables
    public MeshRenderer upFaceMesh;
    public MeshRenderer downFaceMesh;

    private int cardValue = 0;
    private bool isFaceUp = false;

    void Start()
    {
    }

    public void SetCard(CardSO cardSO) 
    {
        upFaceMesh.material = cardSO.upFaceMat;
        downFaceMesh.material = cardSO.downFaceMat;
        cardValue = cardSO.cardValue;
    }

    public int GetCardValue()
    {
        return cardValue;
    }

    [ContextMenu("FlipCard")]
    public void FlipCard()
    {
        isFaceUp = !isFaceUp;
        Debug.Log("isFaceUp: " + isFaceUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
