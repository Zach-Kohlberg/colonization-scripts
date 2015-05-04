using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoverTextScript : MonoBehaviour {

    public Text myText;
    private bool flagged = false;
    private string flagged_Text;

	// Use this for initialization
	void Start () {
        myText.text = " ";
	}

    /// <summary>
    /// Clear the text
    /// </summary>
    /// <param name="flag">Has the set action been canceled?</param>
    public void Text_Clear(bool flag = false)
    {
        flagged = !flag;
        if (flagged)
        {
            myText.text = flagged_Text;
        }
        else
        {
            flagged_Text = " ";
            myText.text = " ";
        }
    }


    /// <summary>
    /// Set the hoverbox's text.
    /// </summary>
    /// <param name="s">The text to be displayed</param>
    /// <param name="f">Does this text need to remain?</param>
    public void Text_Set(string s, bool f = false)
    {
        flagged = f;

        if (flagged)
        {
            flagged_Text = s;
        }

        myText.text = s;
    }

    void OnEnable()
    {
        myText.text = " ";
    }
	
	
}
