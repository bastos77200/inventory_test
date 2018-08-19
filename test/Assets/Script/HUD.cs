using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Inventory inventory;
    


    // Use this for initialization
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
        inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;

            // Border... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);

            
            Image image = imageTransform.GetComponent<Image>();

            //Debug.Log(image);
        

           ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

           if (index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                Debug.Log(e.Item.Slot.Id.ToString());


                // Store a reference to the item
             itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;

            Transform imageTransform = slot.GetChild(0).GetChild(0);
           

            Image image = imageTransform.GetComponent<Image>();


            ////ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            // We found the item in the UI
            ////  if (itemDragHandler.Item == null)
            continue;

            // Found the slot to remove from
            ////if (e.Item.Slot.Id == index)
            ////{
            ////    int itemCount = e.Item.Slot.Count;
            ////    itemDragHandler.Item = e.Item.Slot.FirstItem;

                ////if (itemCount < 2)
                ////{
                ////    txtCount.text = "";
                ////}
                ////else
                ////{
                ////    txtCount.text = itemCount.ToString();
                ////}

                ////if (itemCount == 0)
                ////{
                ////    image.enabled = false;
                ////    image.sprite = null;
                ////}
                ////break;
            ////}

        }
    }

   
}
