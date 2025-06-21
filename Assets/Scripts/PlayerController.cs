using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;


    [SerializeField] Rigidbody2D rb;
    float xInput;
    float yInput;

    [Header("Send/Rev")]
    [SerializeField] List<Letter> letters = new List<Letter>();
    [SerializeField] LayerMask homeLayer;
    [SerializeField] float rangeEffect;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();

    }
    private void FixedUpdate()
    {
        Move();
    }
    public void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetOrSendLetter();

        }
    }
    public void Move()
    {
            rb.velocity = new Vector2(xInput * speed, yInput * speed);
    }
    public void GetOrSendLetter()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, rangeEffect, homeLayer);
        if(col.TryGetComponent<LetterSender>(out LetterSender sender))
        {

            if (sender.GetLetterCount() > 0)
            {
                Observer.Instance.Broadcast(EventId.OnShowMessage, "You got a letter!");
                letters = sender.GetLetters();
                foreach (Letter letter in letters)
                {
                    Observer.Instance.Broadcast(EventId.OnUpdateLetter, Tuple.Create(letter, 1));
                }
            }
            else
            {
                Observer.Instance.Broadcast(EventId.OnShowMessage, "No letter");
            }
            return;
        }
        else if (col.TryGetComponent<LetterReceiver>(out LetterReceiver receiver))
        {
            if (receiver.HasLetter()) {

                Observer.Instance.Broadcast(EventId.OnShowMessage, "Already has letter");
                return;
            }
            foreach(Letter letter in letters)
            {
                if (letter.destination == receiver.id)
                {
                    receiver.ReceiveLetter(letter);
                    letters.Remove(letter);
                    Observer.Instance.Broadcast(EventId.OnUpdateLetter, Tuple.Create(letter, -1));
                    Observer.Instance.Broadcast(EventId.OnShowMessage, "Gui thanh cong letter");
                    return;
                }

            }
            Observer.Instance.Broadcast(EventId.OnShowMessage, "No letter");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeEffect);
    }

}
