//EventActivator вызывает методы из ивента OnTrigger при входе в триггер или при активации объекта на котором этот скрипт висит
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EventActivator : MonoBehaviour
{
    public bool destroyOnUse;
    public UnityEvent OnTrigger;

    private void EventActivate()
    {
        OnTrigger.Invoke();
        if (destroyOnUse)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        EventActivate();
    }

    void OnEnable()
    {
        if(gameObject.GetComponent<Collider>().isTrigger == false || gameObject.GetComponent<Collider>() == null)
        {
            EventActivate();
        }
    }   
}
