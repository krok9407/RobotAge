using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenuKeyboard : MonoBehaviour
{
    [SerializeField] private controller.ListButtons _buttons;
    [SerializeField] private GameObject _inputButtonLabel;
    void Start()
    {
        foreach (var item in _buttons.Movements)
        {
            GameObject newButtonLabel = Instantiate(_inputButtonLabel, transform);
            Text nameButton = newButtonLabel.transform.GetChild(0).GetComponent<Text>();
            nameButton.text = item.name;
            Text valueButton = newButtonLabel.transform.GetChild(1).GetComponent<Text>();
            valueButton.text = item.value;
            Text alternativeValueButton = newButtonLabel.transform.GetChild(2).GetComponent<Text>();
            alternativeValueButton.text = item.alternativeValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
