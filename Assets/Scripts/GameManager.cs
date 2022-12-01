using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject card;
    public GameObject board;
    public CardSO[] cardsSOs = new CardSO[16];
    public Transform[] cardsPositions = new Transform[16];
    public List<int> totals;

    //private int flipedCards = 0;
    private List<Card> flipedCards = new List<Card>();

    void Start()
    {
        InstanceCards();
    }


    private void InstanceCards()
    {
        for (int i = 0; i < cardsSOs.Length; i++)
        {
            Card newCard = (Instantiate(card, cardsPositions[i].position, card.transform.rotation)).GetComponent<Card>();
            newCard.transform.parent = board.transform;
            newCard.SetCard(cardsSOs[i]);
        }
    }

    public void TryToFlip(Card card)
    {
        if (card.isFaceUp || card.isFlipping) return;

        if (flipedCards.Count <= 1)
        {
            flipedCards.Add(card);
            card.FlipCard();
            Debug.Log(flipedCards.Count);

            if (flipedCards.Count == 2)
            {
                card.tweener.onComplete = CheckCardsHand;
            }
        }
    }

    public void CheckCardsHand()
    {
            int cardsTotal = flipedCards[0].GetCardValue() + flipedCards[1].GetCardValue();
            bool isMatch = false;
            for (int i = 0; i < totals.Count; i++)
            {
                if (cardsTotal == totals[i])
                {
                    isMatch = true;
                    Debug.Log("Match");
                    break;
                }
            }
            if (!isMatch)
            {
                flipedCards[0].FlipCard();
                flipedCards[1].FlipCard();
            }
            CleanFlipedCards();
    }

    private void CleanFlipedCards()
    {
        for (int i = flipedCards.Count - 1; i >= 0; i--)
        {
            flipedCards.RemoveAt(i);
        }
    }

    public void SortCardPositions()
    {
        //TODO
    }


    void Update()
    {
        
    }
}
