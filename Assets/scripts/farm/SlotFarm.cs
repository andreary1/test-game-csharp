using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount; //quantidade de "escava��o"
    [SerializeField] private int waterAmount; //total de �gua para nascer uma cenoura

    [SerializeField] private bool detecting;
    private bool isPlayer; //verdade quando player encosta

    private int initialDigAmount;
    private float currentWater;

    private bool dugHole;
    private bool plantedCarrot;

    PlayerItems playerItems;

    private void Start()
    {
        playerItems = FindAnyObjectByType<PlayerItems>();
        initialDigAmount = digAmount;
    }
    private void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            //encheu o total de �gua necess�ria
            if (currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRenderer.sprite = carrot;

                plantedCarrot = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && plantedCarrot && isPlayer)
            {
                audioSource.PlayOneShot(carrotSFX);
                spriteRenderer.sprite = hole;
                playerItems.carrots++;
                currentWater = 0f;
            }
        }

    }
    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

        //if (digAmount <= 0)
        //{
        //    //plantar cenoura
        //   spriteRenderer.sprite = carrot;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }

        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }

        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}