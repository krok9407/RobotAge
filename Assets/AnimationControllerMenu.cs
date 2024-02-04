using UnityEngine;
using UnityEngine.UI;

public class AnimationControllerMenu : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]private Button[] buttons;
    private void Awake() {
        _animator = GetComponent<Animator>();
        print(_animator);
    }
   public void OpenCharectersOrEvils(){
        _animator.SetBool("isOpenCharecter",true);
   }
     public void OpenPlaceOrEvent(){
        _animator.SetBool("isOpenPlaces",true);
   }
   public void CloseAll(){
        _animator.SetBool("isOpenCharecter",false);
        _animator.SetBool("isOpenPlaces",false);
   }
    public void Off(){
        foreach (var button in buttons)
     {
          button.enabled  = true;
     }
      gameObject.SetActive(false);
   }
   public void OffButton(){
     foreach (var button in buttons)
     {
          button.enabled  = false;
     }
   }
}
