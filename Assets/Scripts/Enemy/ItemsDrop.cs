using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDrop : MonoBehaviour
{
    [SerializeField] List<GameObject> items;
    private void Start()
    {
        items.AddRange(Resources.LoadAll<GameObject>("Prefabs/Items"));
    }
    public void Drop()
    {
        int randomNum = Random.Range(0, items.Count);

        GameObject newItem = Instantiate<GameObject>(items[randomNum]);

        newItem.transform.position = gameObject.transform.position;
    }
}
