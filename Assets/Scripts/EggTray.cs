using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggTray : MonoBehaviour
{

    [SerializeField] private Transform[] TA_Trays;


    [HideInInspector] public int I_MaxTray;
    [HideInInspector] public int I_CurrentTray;


    void Start()
    {
        I_CurrentTray = 0;
        I_MaxTray = 4;
    }


    public void HoldItem(Transform recentItem)
    {
        recentItem.SetParent(TA_Trays[I_CurrentTray]);
        recentItem.localPosition = Vector3.zero;
        recentItem.localRotation = Quaternion.identity;

        I_CurrentTray++;
    }





}
