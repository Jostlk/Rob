//Этот скрипт существует чтобы удобно назначать новые цели/этапы игроку
//Каждая цель настраивается через инспектор и имеет свой индекс
//Чтобы дать игроку новую цель используй метод SwitchObjectiveTo() и в аргументы поставь индекс цели/этапа который тебе нужен
//Настоятельно советую использовать скрипт EventActivator чтобы вызывать метод, а не буквально вызывать его откуда-то из своего кода. Так будет легче разбираться в этом всем позже
//Теперь текст в левом верхнем углу экрана и в менюшке Tab изменится на тот который ты указал
using UnityEngine.Events;
using UnityEngine;
using System;
using TMPro;



[Serializable]
public struct Objective
{
    public string task;
    public string description;
    public UnityEvent OnCompletion;
    //После выполнения каждого этапа ивент OnCompletion сможет вызвать различные методы, например это можно использовать для спавна новых охранников, открывать проходы и т.д.
}

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI dockedObjectiveText;
    public TextMeshProUGUI descText;
    public Objective[] objectives;

    private int _currentObjIndex;

    public void SwitchObjectiveTo(int index)
    {
        objectives[_currentObjIndex].OnCompletion.Invoke();
        _currentObjIndex = index;

        objectiveText.text = objectives[index].task;
        dockedObjectiveText.text = objectives[index].task;
        descText.text = objectives[index].description;
    }

    void Start()
    {
        //Первой задачей игрока всегда будет то, что задано под нулевым индексом в списке objectives
        objectiveText.text = objectives[0].task;
        dockedObjectiveText.text = objectives[0].task;
        descText.text = objectives[0].description;

        _currentObjIndex = 0;
    }
}
