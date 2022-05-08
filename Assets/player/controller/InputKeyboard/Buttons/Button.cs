using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace controller{
    [CreateAssetMenuAttribute(fileName ="newButton", menuName="Input/Button")]
    public class Button : ScriptableObject {
        public string name;
        public string value;
        public string alternativeValue;
        public void SetNewValue(string value){
            this.value = value;
        }
        public void SetNewalternativeValue(string alternativeValue){
            this.alternativeValue = alternativeValue;
        }
    }
}