using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    //public variables
    public AudioSource audioSource;
    public MeshRenderer upFaceMesh;
    public MeshRenderer downFaceMesh;
    public bool isFaceUp = false;
    public bool isFlipping = false;

    private int cardValue = 0;
    private GameManager gameManager;
    [HideInInspector] public Tween tweener;
    [HideInInspector] public delegate void CheckCards();

    void Start()
    {
        gameManager = GameManager.Instance;
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
        isFlipping = true;
        isFaceUp = !isFaceUp;
        //audio
        audioSource.Play();
        tweener = transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, 180 * -1, 0), 1f)
            .OnComplete(()=> isFlipping = false);
    }

    private void OnMouseDown()
    {
        gameManager.TryToFlip(this);
    }
}
