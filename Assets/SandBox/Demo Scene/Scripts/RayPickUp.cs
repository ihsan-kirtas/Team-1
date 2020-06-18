using UnityEngine;

namespace SandBox.Demo_Scene.Scripts
{
    public class RayPickUp : MonoBehaviour
    {
        // The distance the player has to be from the item for the pickup to work.
        public int distanceToItem;

        // Start is called before the first frame update
        void Start()
        {
        
        }
    
        void OnGUI()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Update is called once per frame
        void Update()
        {
            Collect();
        
        }

        private void Collect()
        {
            // only activate Ray casting on mouse up - efficiency boost.
            if (Input.GetMouseButton(1)) // 0 = left click, 1 = right click
            {
                RaycastHit hit;
            
                // Ray firing from mouse position.
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // cast ray our at defined distance to item.
                if (Physics.Raycast(ray, out hit, distanceToItem))
                {
                    // If the ray hits item
                    if (hit.collider.gameObject.name == "item")
                    {
                        Debug.Log("item hit");
                    
                        // Destroy item
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}