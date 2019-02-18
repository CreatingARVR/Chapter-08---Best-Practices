public class InventorySlot : MonoBehaviour {

        	public MeshRenderer renderer; //the renderer to show the slot

         	public delegate void ItemReleasedAction(); //method signature for callback function

         	private InventoryItem currentItem; //stores Current Item
         	private ItemReleasedAction currentReleasedCallback; //callback for item

         	void SetItem(InventoryItem item, ItemReleasedAction releasedCallback ) { //called from inventory item   
         	    item.transform.parent = this.transform; //set the parent
         	    item.transform.position = this.transform.position; //center

         	    currentItem = item;
         	    currentReleasedCallback = releasedCallback;
         	    renderer.enabled = false;
         	}

        	private void OnTriggerExit(Collider other) {
             if (other.GetComponent<InventoryItem> == currentItem) {
        	         currentReleasedCallback(); //hand is grabbing item out of inventory

        	         currentItem = null;
        	         currentReleasedCallback = null;
        	         renderer.enabled = true;
            }
     }
}
