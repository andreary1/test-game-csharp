using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image WaterUIBar;
    [SerializeField] private Image WoodUIBar;
    [SerializeField] private Image CarrotUIBar;
    [SerializeField] private Image FishUIBar;

    [Header("Tools")]
    //[SerializeField] private Image AxeUI;
    //[SerializeField] private Image ShovelUI;
    //[SerializeField] private Image BucketUI;
    public List<Image> toolsUI = new List<Image>();

    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;
    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        WaterUIBar.fillAmount = 0f;
        WoodUIBar.fillAmount = 0f;
        CarrotUIBar.fillAmount = 0f;
        FishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        WaterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        WoodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        CarrotUIBar.fillAmount = playerItems.carrots / playerItems.carrotsLimit;
        FishUIBar.fillAmount = playerItems.fishes / playerItems.fishesLimit;

        //  toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
