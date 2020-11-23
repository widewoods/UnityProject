using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    Dropdown dropDown;
    public Text text;

    public static int sortInt;
    // Start is called before the first frame update
    void Start()
    {
        dropDown = gameObject.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        dropDown.onValueChanged.AddListener(delegate{
            DropdownValueChanged(dropDown);

        });

        sortInt = dropDown.value;
    }

    void DropdownValueChanged(Dropdown change)
    {

    }
}
