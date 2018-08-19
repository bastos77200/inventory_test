using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    Default,
    Consumable,
    Weapon
}

public class InteractableItemBase : MonoBehaviour
{
    public string Name;

    public Sprite Image;

    public EItemType ItemType;

    public virtual void OnInteract()
    {
    }


}

public class InventoryItemBase : InteractableItemBase
{
    public InventorySlot Slot
    {
        get; set;
    }

    public virtual void OnUse()
    {
        transform.localPosition = PickPosition;
      
    }

    public virtual void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
           
        }
    }

    public virtual void OnPickup()
    {
       
        gameObject.SetActive(false);

    }

    public Vector2 PickPosition;






}
