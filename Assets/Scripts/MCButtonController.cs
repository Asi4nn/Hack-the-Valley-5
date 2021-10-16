using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCButtonController : MonoBehaviour
{
    [SerializeField] Button button;
    public bool selected = false;

    void Start()
    {
        button.onClick.AddListener(ChangeSelected);
    }

    void ChangeSelected()
    {
        selected = !selected;
        if (selected)
        {
            button.GetComponent<Image>().color = new Color32(6, 255, 14, 146);
        }
        else
        {
            button.GetComponent<Image>().color = new Color32(255, 201, 32, 146);
        }
    }
}
