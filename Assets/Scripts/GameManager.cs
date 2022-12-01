using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject card;
    public List<CardSO> cardsSOs;

    void Start()
    {
        InstanceCards();
    }


    private void InstanceCards()
    {
        for (int i = 0; i < cardsSOs.Count; i++)
        {
            Card newCard = (Instantiate(card, Vector3.zero, card.transform.rotation)).GetComponent<Card>();
            newCard.SetCard(cardsSOs[i]);
        }
    }


    void Update()
    {
        
    }
}
