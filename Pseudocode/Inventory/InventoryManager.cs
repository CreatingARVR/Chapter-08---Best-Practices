public class InventoryManager : MonoBehaviour {

              public Controller controller; //which controller
              public GameObject inventoryParent; //parent of slots for this controller

              void Update() { //check every frame
                  if (controller.PressDown(ApplicationMenu)) { // the first frame the button is pressed
                     ShowInventorySlots(true);
              } else if (controller.PressUp(ApplicationMenu)) {
                      ShowInventorySlots(false);
                  }
              }

              void ShowInventorySlots(bool show) {
                  inventoryParent.SetActive(show); //toggle whether shown or not based on bool parameter
             }
}
