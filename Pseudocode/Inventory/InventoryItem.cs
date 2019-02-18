public class InventoryItem : MonoBehaviour {

          private void OnTriggerEnter(Collider other) {
         	    if (other.name == "Slot") {
        	        other.gameObject.GetComponent<InventorySlot>().SetItem(this, ItemReleased); //call the slot method
        	        SetSize(.01f); //set size to fit in slot
    	    }
         	}

         	void ItemReleased() { //callback for when item leaves slot
         	    SetSize(1f); //when item is released set size to normal
         	}

          void SetSize(float size) {
         	    transform.localScale = Vector3.one * size; //set a uniform size i.e (1,1,1)
         	}
}
