using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] KeyCode[] keyCodes;
    [SerializeField] GameObject inventoryGameObject;
    private void Update()
    {
        for(int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
                break;
            }
        }
    }
}
