using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Keypad : MonoBehaviour
{
    public string correctCode;
    public UnityEvent OnCorrectCodeEnter;

    private TextMeshProUGUI codeText;
    private string resultString;
    private int codeLength = 0;

    void Start()
    {
        codeText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void InputNumber(string num)
    {
        if(codeLength >= 4)
        {
            return;
        }
        resultString += num;
        codeText.text = resultString;
        codeLength++;
        if(codeLength == 4)
        {
            CheckCode(resultString);
        }
    }

    private void WipeCode()
    {
        codeText.color = Color.green;
        codeText.fontSize = 0.2f;
        resultString = "";
        codeText.text = "";
        codeLength = 0;
    }
    private void CheckCode(string code)
    {
        if(resultString == correctCode)
        {
            codeText.fontSize = 0.1f;
            codeText.text = "КОД ПРАВИЛЬНЫЙ";
            OnCorrectCodeEnter.Invoke();
        }
        else
        {
            codeText.color = Color.red;
            codeText.fontSize = 0.1f;
            codeText.text = "НЕПРАВИЛЬНЫЙ КОД";
            Invoke("WipeCode", 2);
        }
    }

}
