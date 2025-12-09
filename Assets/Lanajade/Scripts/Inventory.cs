using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Dalman, Lanajade
 * 11/24/25
 * Handle inventory
 */

public class Inventory : MonoBehaviour
{
    // Array to hold the items in the inventory - Set the size of this in the inspector!
    public Item[] inventoryArray;
    public int maxInventory;
    public int ingredients = 100;
    public int ingredientsAdd = 0;

    public GameObject HealthPotion;
    public GameObject DamagePotion;
    public GameObject SpeedPotion;


    public void Start()
    {
        inventoryArray = new Item[maxInventory];
        print("Player has " + ingredients + " ingredients.");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Activated inventory slot 1.");

            Item firstItem = RecallOne();

            if (firstItem != null)
            {
                print("First potion obtained: " + firstItem.potionName);
                                
                print("using potion");
                StartCoroutine(DamageEffect());     
            }
            else
            {
                print("There were no items in the array to check");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Activated inventory slot 2.");

            Item SecondItem = RecallTwo();

            if (SecondItem != null)
            {
                if (SecondItem == DamagePotion)
                {
                    print("using potion");
                    StartCoroutine(DamageEffect());
                }
            }
            else
            {
                print("There were no items in the array to check");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Activated inventory slot 3.");

            Item ThirdItem = RecallThree();

            if (ThirdItem != null)
            {
                print("Third potion obtained: " + ThirdItem.potionName);
                
                if (ThirdItem == DamagePotion)
                {
                    print("using potion");
                    StartCoroutine(DamageEffect());
                }
            }
            else
            {
                print("There were no items in the array to check");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Potion")
        {
            Item newItem = other.gameObject.GetComponent<Item>();

            // Attempt to add the item to the inventory.
            if (AddItem(newItem))
            {
                // If successfully added, deactivate the triggered object and print the new item's name.
                other.gameObject.SetActive(false);
                print("New item: " + newItem.potionName);
            }
            else
            {
                if (inventoryArray[inventoryArray.Length - 1] != null)
                {
                    // If the item couldn't be added due to lack of space in the inventory, print a message.
                    print("Could not add " + newItem.potionName + ", not enough room in inventory.");
                }

                if (ingredients < newItem.ingredients)
                {
                    // player not enough gold
                    print("Did not add " + newItem.potionName + ", not enough ingredients.");
                    print("Player has " + ingredients + " ingredients. Item needs " + newItem.ingredients + " ingredients.");
                }
            }
        }

        if (other.gameObject.tag == "Ingredient")
        {
            print(ingredientsAdd + " added to " + ingredients + " ingredients in your pouch.");
            ingredients += ingredientsAdd;
            print(ingredients + " ingredients in your pouch.");

            other.gameObject.SetActive(false);
        }
    }

    IEnumerator DamageEffect()
    {
        GetComponent<DamagePotionEffect>().damageEffectHappening = true;
        print("Now using damage potion. Insta kill enemies for 5 seconds.");

        yield return new WaitForSeconds(5);

        GetComponent<DamagePotionEffect>().damageEffectHappening = false;
    }

    private bool AddItem(Item itemToAdd)
    {
        // Initialize success and set it to false.
        bool success = false;

        // Iterate through the inventoryArray using a loop until an empty slot is found or the end of the array is reached.
        for (int index = 0; index < inventoryArray.Length; index++)
        {
            if (inventoryArray[index] == null && ingredients >= itemToAdd.ingredients)
            {
                // If the current slot is empty, add the item to that slot and set success to true.
                inventoryArray[index] = itemToAdd;
                success = true;

                // subtract gold of that item
                ingredients -= itemToAdd.ingredients;

                print("Player ingredient pouch: " + ingredients);

                // Print a message indicating the successful addition of the item to the inventory.
                print("added to slot " + index + ": " + inventoryArray[index].potionName +
                    " with an ingredient value of " + inventoryArray[index].ingredients);

                // No need to check more elements in the array, break out of the loop
                break;
            }
        }
        // Return success, indicating whether the item was successfully added to the inventory.
        return success;
    }

    /// <summary>
    /// recalls first object in inventory
    /// </summary>
    /// <returns></returns>
    public Item RecallOne()
    {
        Item itemCalled = null;

        for (int slot = 0; slot < inventoryArray.Length; slot++)
        {
            if (inventoryArray[slot] != null)
            {
                if (slot == 0)
                {
                    itemCalled = inventoryArray[slot];
                }
            }
        }

        return itemCalled;
    }

    /// <summary>
    /// recalls second object in inventory
    /// </summary>
    /// <returns></returns>
    public Item RecallTwo() 
    {
        Item itemCalled = null;

        for (int slot = 0; slot < inventoryArray.Length; slot++)
        {
            if (inventoryArray[slot] != null)
            {
                if (slot == 1)
                {
                    itemCalled = inventoryArray[slot];
                }
            }
        }

        return itemCalled;
    }

    /// <summary>
    /// recalls third object in inventory
    /// </summary>
    /// <returns></returns>
    public Item RecallThree() 
    {
        Item itemCalled = null;

        for (int slot = 0; slot < inventoryArray.Length; slot++)
        {
            if (inventoryArray[slot] != null)
            {
                if (slot == 2)
                {
                    itemCalled = inventoryArray[slot];
                }
            }
        }

        return itemCalled;
    }
}
