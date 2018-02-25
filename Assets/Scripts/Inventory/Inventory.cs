using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject {
    List<Item> inventory = new List<Item>();

    public List<Item> getInventory() {
        return this.inventory;
    }
}