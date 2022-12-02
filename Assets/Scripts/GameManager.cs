using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject card;
    public GameObject board;
    public CardSO[] cardsSOs = new CardSO[12];
    public Transform[] cardsPositions = new Transform[12];
    public List<TotalBehaviour> totals;

    private int totalMatches = 0;
    private List<Card> flipedCards = new List<Card>();

    private SoundManager soundManager;
    [SerializeField] private EasyTween continueCanvasAnim;

    void Start()
    {
        soundManager = SoundManager.Instance;
        ShuffleDeck();
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
        //Debug.Log(flipedCards.Count);
        if (flipedCards.Count <= 1)
        {
            flipedCards.Add(card);
            card.FlipCard();
            soundManager.PlayFlipCardSound();

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
            //Debug.Log(totals[i].value);
                if (cardsTotal == totals[i].value)
                {
                    isMatch = true;
                    totals[i].Activate();
                    MatchDetected();
                break;
                }
            }
            if (!isMatch)
            {
                soundManager.PlayIncorrectMatchSound();
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
        //Debug.Log("Cards cleaned :" + flipedCards.Count);
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < cardsPositions.Length; i++)
        {
            int randomPos = Random.Range(0, cardsPositions.Length);
            Transform tempTransform = cardsPositions[randomPos];
            cardsPositions[randomPos] = cardsPositions[i];
            cardsPositions[i] = tempTransform;
        }
    }

    private void MatchDetected()
    {
        //Debug.Log("Match");
        CleanFlipedCards();
        totalMatches++;
        soundManager.PlayMatchSound();

        if (totalMatches == 6)
        {
            soundManager.PlayWinSound();
            continueCanvasAnim.OpenCloseObjectAnimation();
        }
    }

}
