using UnityEngine;
using TMPro;

public class UpdatedDisplay : MonoBehaviour
{
    private int currNum;
    public TMP_Text displayText;
    public SafeManager smRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currNum = 0;
    }

    public void UpdateDisplay(int i, int idx)
    {
        currNum = ((currNum + i) % 10 + 10) % 10;
        displayText.text = currNum.ToString();
        smRef.UpdateVal(currNum, idx);
    }
}
