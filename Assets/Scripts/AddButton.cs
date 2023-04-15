using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    [SerializeField] Transform gameField;

    [SerializeField] GameObject btn;

    private void Awake() 
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(gameField,false);
        }   
    }
}
