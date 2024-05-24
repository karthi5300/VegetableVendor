using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tray : MonoBehaviour
{

    public bool B_IsOccupied;


    void Start()
    {
        B_IsOccupied = false;
    }


    public void HoldItem(Transform recentItem)
    {
        recentItem.SetParent(transform);
        recentItem.localPosition = Vector3.zero;
        recentItem.localRotation = Quaternion.identity;

        B_IsOccupied = true;
    }





}
