using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsData : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    public string ItemName { get => itemName; private set => itemName = value; }
}
