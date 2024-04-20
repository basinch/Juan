using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("General")]

    public List<itemType> inventoryList;
    public int selectedItem;
    public float playerReach;
    public bool hasWhip = false, hasBrush = false, hasCarrot = false, hasApple = false;

    [Space(20)]
    [Header("Keys")]
    [SerializeField] KeyCode useItemKey;
    [SerializeField] KeyCode pickItemKey;

    [Space(20)]
    [Header("Item gameobjects")]
    [SerializeField] GameObject apple_item;
    [SerializeField] GameObject brush_item;
    [SerializeField] GameObject carrot_item;
    [SerializeField] GameObject whip_item;
    [SerializeField] GameObject empty_item;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };

    private void Start()
    {
        itemSetActive.Add(itemType.Apple, apple_item);
        itemSetActive.Add(itemType.Brush, brush_item);
        itemSetActive.Add(itemType.Carrot, carrot_item);
        itemSetActive.Add(itemType.Whip, whip_item);
        itemSetActive.Add(itemType.Empty, empty_item);

        NewItemSelected();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0)
        {
            selectedItem = 0;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1 && hasApple) 
        {
            selectedItem = 1;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2 && hasCarrot)
        {
            selectedItem = 2;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 3 && hasBrush)
        {
            selectedItem = 3;
            NewItemSelected();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryList.Count > 4 && hasWhip)
        {
            selectedItem = 4;
            NewItemSelected();
        }
    }

    private void NewItemSelected()
    {
        apple_item.SetActive(false);
        brush_item.SetActive(false);
        carrot_item.SetActive(false);
        whip_item.SetActive(false);
        empty_item.SetActive(false);

        GameObject selectedItemGameObject = itemSetActive[inventoryList[selectedItem]];
        selectedItemGameObject.SetActive(true);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(pickItemKey) && collision.gameObject.CompareTag("Pickable"))
        {
            Destroy(gameObject);
            Debug.Log("Picked");
        }
    }
}

public interface IPickable
{
    void PickItem();
}