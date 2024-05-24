using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{

    public enum Spaces
    {
        Shop,
        Garden,
        Farm
    }

    public static LevelManager Instance;


    [SerializeField] private GameObject[] GA_Spaces;
    [SerializeField] private GameObject[] GA_Canvases;

    [SerializeField] private Transform T_Player;

    [SerializeField] private Transform[] TA_Spaces;

    [SerializeField] private Transform T_PlayerPosFromShopToGarden;
    [SerializeField] private Transform T_PlayerPosFromShopToFarm;
    [SerializeField] private Transform T_PlayerPosFromGardenToShop;
    [SerializeField] private Transform T_PlayerPosFromFarmToShop;




    void Start()
    {
        Instance = this;
    }

    public void EnterGarden()
    {
        EnterScreen((int)Spaces.Garden);
        T_Player.position = T_PlayerPosFromShopToGarden.position;
        TA_Spaces[1].SetAsLastSibling();
    }


    public void EnterFarm()
    {
        EnterScreen((int)Spaces.Farm);
        T_Player.position = T_PlayerPosFromShopToFarm.position;
        TA_Spaces[2].SetAsLastSibling();
    }



    public void EnterShopFromGarden()
    {
        EnterScreen((int)Spaces.Shop);
        T_Player.position = T_PlayerPosFromGardenToShop.position;
        TA_Spaces[0].SetAsLastSibling();
    }


    public void EnterShopFromFarm()
    {
        EnterScreen((int)Spaces.Shop);
        T_Player.position = T_PlayerPosFromFarmToShop.position;
        TA_Spaces[0].SetAsLastSibling();
    }


    private void EnterScreen(int index)
    {
        for (int i = 0; i < GA_Spaces.Length; i++)
        {
            if (i == index)
            {
                GA_Spaces[i].SetActive(true);
                GA_Canvases[i].SetActive(true);

                continue;
            }

            GA_Spaces[i].SetActive(false);
            GA_Canvases[i].SetActive(false);
        }

    }





}
