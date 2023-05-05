using UnityEngine;
using UnityEngine.UI;

public class ShowAndHideText : MonoBehaviour
{
    public Text displayText;

    public void ShowWaterShedText()
    {
        displayText.text = "A dividing ridge between drainage areas";
    }

    public void ShowMainStreamText()
    {
        displayText.text = "The larger, or parent, river is called the mainstem";
    }

    public void ShowTributaryText()
    {
        displayText.text = "A river or stream flowing into a larger river or lake.";
    }

    public void ShowConfluenceText()
    {
        displayText.text = "The junction of two rivers";
    }

    public void ShowSourceText()
    {
        displayText.text = "A place where a river begins";
    }
}
