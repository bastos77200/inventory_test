using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 10;

   
    //public GameObject[] inventory = new GameObject[10];

    private IList<InventorySlot> xSlots = new List<InventorySlot>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public event EventHandler<InventoryEventArgs> ItemUsed;

    public Inventory()
    {
        {
            for (int i = 0; i < SLOTS; i++)
            {
                xSlots.Add(new InventorySlot(i));
            }
        }
    }

    //Recherche Slot libre
    private InventorySlot FindStacktableSlot(InventoryItemBase item)
    {
        foreach (InventorySlot slot in xSlots)
        {
            if (slot.IsStackable(item))
                return slot;
        }
        return null;
    }

    //Recherche du prochain slot libre

        private InventorySlot FindNextEmptySlot()
    {
        foreach (InventorySlot slot in xSlots)
        {
            if (slot.IsEmpty)
                return slot;
        }
        return null;
    }



    //public void AddItem(GameObject item)
    public void AddItem(InventoryItemBase item)
    {


        //ajout dans les slot libre
        InventorySlot freeSlot = FindStacktableSlot(item);
        if (freeSlot==null)
        {
            freeSlot = FindNextEmptySlot();

        }
        if (freeSlot !=null)
        {
            freeSlot.AddItem(item);

            if (ItemAdded != null)
            {
                ItemAdded(this, new InventoryEventArgs(item));
            }
		
        }


    }
}
