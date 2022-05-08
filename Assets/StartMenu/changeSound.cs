using UnityEngine;
using UnityEngine.UI;

public class changeSound : MonoBehaviour
{
    [SerializeField] Slider _scrollbar;
    [SerializeField] Text textValue;
    [SerializeField] AudioSource _audioSource;
    float value;
private void Start() {
    _scrollbar.value=_audioSource.volume;
}
   public void changeValue()
        {
            value = Mathf.Round(_scrollbar.value*100);
            _audioSource.volume=_scrollbar.value;
            textValue.text=value.ToString();
        }
        public void downSoundLvl()
        {   value=Mathf.Round(_scrollbar.value*100);
            if(value>0){
            value--;
            _audioSource.volume-=0.01f;
            textValue.text=value.ToString();
            _scrollbar.value-=0.01f;
            }
        }
         public void upSoundLvl()
        {
            value=Mathf.Round(_scrollbar.value*100);
            if(value<100){
             value++;
            _audioSource.volume+=0.01f;
            textValue.text=value.ToString();
            _scrollbar.value+=0.01f;
            }
        }
}
