using UnityEngine;
using UnityEngine.Events;

public class WorldSpaceButton : MonoBehaviour
{
    public UnityEvent WhenClicked;

    public void ButtonClicked()
    {
        WhenClicked.Invoke();
    }
}
