using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private GameObject selectedZombie;
    public GameObject[] zombies;
    public Vector3 normalSize, scaled;
    private int selectedIndex;

    private void Start()
    {
        GameObject toSelect = zombies[0];
        SelectZombie(toSelect);
    }
    private void SelectZombie(GameObject toSelect)
    {
        if (selectedZombie != null)
            selectedZombie.transform.localScale = normalSize;
        selectedZombie = toSelect;
        selectedZombie.transform.transform.localScale = scaled;
        selectedIndex = Array.IndexOf(zombies, toSelect);
    }
    private void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }
    private void Right()
    {
        selectedIndex--;
        if (selectedIndex < 0)
            selectedIndex = zombies.Length - 1;
        SelectZombie(zombies[selectedIndex]);
    }

    private void Left()
    {
        selectedIndex++;
        if (selectedIndex >= zombies.Length)
            selectedIndex = 0;
        SelectZombie(zombies[selectedIndex]);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            PushUp();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
    }

    

}
