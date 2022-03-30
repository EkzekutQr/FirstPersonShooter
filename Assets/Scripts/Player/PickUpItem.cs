using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Text red;
    [SerializeField] Text green;
    [SerializeField] Text blue;

    [SerializeField] WeaponExample weaponExample;
    void PickUp(GameObject item)
    {
        if (item.GetComponent<ItemsData>().ItemName == "Red")
        {
            red.text = (int.Parse(red.text) + 1).ToString();
        }
        if (item.GetComponent<ItemsData>().ItemName == "Green")
        {
            green.text = (int.Parse(green.text) + 1).ToString();
        }
        if (item.GetComponent<ItemsData>().ItemName == "Blue")
        {
            blue.text = (int.Parse(blue.text) + 1).ToString();
        }

        weaponExample.projectile.GetComponent<MeshRenderer>().material = item.GetComponent<MeshRenderer>().material;

        Destroy(item);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(LayerMask.LayerToName(hit.gameObject.layer) == "Items")
        {
            PickUp(hit.gameObject);
        }
    }
}
