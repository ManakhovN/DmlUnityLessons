using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public Slider mainSlider;
    public void SetText(Text text)
    {
        text.text = mainSlider.value.ToString();
    }

    public void ChangeObjectScale(Transform t)
    {
        t.localScale /= 2f; 
    }


    public void ChangeScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
