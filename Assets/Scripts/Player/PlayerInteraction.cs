using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private int I_BagCapacity;

    [SerializeField] private Transform T_Bag;
    [SerializeField] private List<Transform> TA_BagSlots;
    // [SerializeField] List<Transform> TA_itemPicked;

    private int I_BagItemsCount;






    private bool B_CanCheckVeg = true;
    private bool B_CanCheckEgg = true;


    void Start()
    {
        I_BagItemsCount = 0;
    }


    public void Pick(Transform item)
    {
        item.GetComponent<Collider2D>().enabled = false;

        //initiating spawn of next item
        ItemSpawner itemSpawner = item.parent.GetComponent<ItemSpawner>();
        itemSpawner.B_IsReady = true;
        StartCoroutine(itemSpawner.IENUM_Spawn());
        // TA_itemPicked.Add(item);

        //item pick by player
        // item.SetParent(T_Bag);
        // item.localPosition = new Vector2(0f, I_BagItemsCount);
        // item.localRotation = Quaternion.identity;

        // I_BagItemsCount++;

        // if (item.TryGetComponent<VegTray>(out VegTray vegtray))
        // {
        //     item.tag = "Veggie";
        // }
        // else if (item.TryGetComponent<EggTray>(out EggTray eggtray))
        // {
        //     item.tag = "Egg";
        // }

        // item.tag = "Untagged";

        item.SetParent(TA_BagSlots[I_BagItemsCount++]);
        item.localPosition = Vector2.zero;
        item.localRotation = Quaternion.identity;

        //setting item tag
        if (item.name == "Veggie")
        {
            item.tag = "Veggie";
        }
        else if (item.name == "Egg")
        {
            item.tag = "Egg";
        }

        // Debug.Log("bag items count : " + I_BagItemsCount);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            if (I_BagItemsCount < I_BagCapacity)
            {
                Pick(other.transform);
            }
        }

        if (other.gameObject.CompareTag("VegTray"))
        {
            if (B_CanCheckVeg)
                StartCoroutine(IENUM_DropVeg(other.gameObject));
        }

        if (other.gameObject.CompareTag("EggTray"))
        {
            if (B_CanCheckEgg)
                StartCoroutine(IENUM_DropEgg(other.gameObject));
        }
    }


    IEnumerator IENUM_DropVeg(GameObject gameObject)
    {
        Debug.Log("dropping veggies...");

        B_CanCheckVeg = false;

        VegTray vegTray = gameObject.GetComponent<VegTray>();

        if (vegTray.I_CurrentTray < vegTray.I_MaxTray)
        {
            //check player bag slots and drop the items into tray
            for (int i = I_BagItemsCount - 1; i >= 0; i--)
            {
                if (TA_BagSlots[i].GetChild(0).tag == "Veggie")
                {
                    vegTray.HoldItem(TA_BagSlots[i].GetChild(0));
                    I_BagItemsCount--;

                    yield return new WaitForSeconds(0.1f);
                }

                if (i == 0)
                {
                    B_CanCheckVeg = true;
                }
            }

            AlignBagItems();
        }
    }


    IEnumerator IENUM_DropEgg(GameObject gameObject)
    {
        Debug.Log("dropping eggs...");

        B_CanCheckEgg = false;

        EggTray eggTray = gameObject.GetComponent<EggTray>();

        if (eggTray.I_CurrentTray < eggTray.I_MaxTray)
        {
            //check player bag slots and drop the items into tray
            for (int i = I_BagItemsCount - 1; i >= 0; i--)
            {
                if (TA_BagSlots[i].GetChild(0).tag == "Egg")
                {
                    eggTray.HoldItem(TA_BagSlots[i].GetChild(0));
                    I_BagItemsCount--;

                    yield return new WaitForSeconds(0.1f);
                }

                if (i == 0)
                {
                    B_CanCheckEgg = true;
                }
            }

            AlignBagItems();
        }
    }




    private void AlignBagItems()
    {
        Debug.Log("Aligning items. Bag items count: " + I_BagItemsCount);

        // Create a list to hold the items temporarily
        List<Transform> items = new List<Transform>();

        // Collect all items in the bag slots
        for (int i = 0; i < TA_BagSlots.Count; i++)
        {
            if (TA_BagSlots[i].childCount > 0)
            {
                items.Add(TA_BagSlots[i].GetChild(0));
            }
        }

        // Clear all bag slots
        foreach (Transform slot in TA_BagSlots)
        {
            if (slot.childCount > 0)
            {
                slot.GetChild(0).SetParent(null);
            }
        }

        // Reassign items to the bag slots in the correct order
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetParent(TA_BagSlots[i]);
            items[i].localPosition = Vector2.zero;
            items[i].localRotation = Quaternion.identity;
        }

        // Update the bag items count
        I_BagItemsCount = items.Count;
    }





}
