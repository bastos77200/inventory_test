using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour {
    public Inventory inventory;
   public InventoryItemBase itembase = null;
    public HUD Hud;




    // Use this for initialization
    void Start () {
        HighLight highlight = GetComponent<HighLight>();
        if (highlight != null)
        {
            highlight.StartHighlight();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //inventory.AddItem();
      
    }

    private void OnMouseDown()
    {
     
        Debug.Log("collide");

        //inventory.AddItem(gameObject);

		//ajout de l''item
        inventory.AddItem(itembase);

//appel methode pour désactiver l'objet'
itembase.OnPickup();
        Debug.Log(itembase.ToString());
       
       
    }

    private InteractableItemBase mInteractItem = null;
}
