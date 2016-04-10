using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonListener : MonoBehaviour 
{
	public Text textSelected;

	public void MyClick (GameObject obj) 
	{
		Text text = obj.GetComponentInChildren<Text>();

		// The text string on the game object
		string textString = (text != null ? text.text : obj.name);

		// The ID on the web site
		string webId = "";

		// The title
		string title = "";

		// Extract them from the full text string separated by |
		string[] splitArray =  textString.Split('|'); 
		webId = splitArray[0];
		title = splitArray[1];

		// Update the text the user sees above the targets
		textSelected.text = "You voted for " + title;
		Debug.Log (textSelected.text);

		// Submit vote to web site
		string url = "http://accompany.nanek.name/api/vote.php?id=" + webId;
		//WWWForm form = new WWWForm();
		//form.AddField("var1", "value1");
		//form.AddField("var2", "value2");
		//WWW www = new WWW(url, form);
		WWW www = new WWW(url);
		Debug.Log ("Submitting HTTP request to " + url);
		StartCoroutine(WaitForRequest(www));

		// Find input field
		InputField[] ins = GameObject.FindObjectsOfType<InputField>();
		foreach (InputField i in ins)
		{
			Debug.Log ("in: " + i.name);
			if (i.isFocused)
			{//i.Select();   // I also tried to use this EventSystem.current.SetSelectedGameObject(go);
				i.ActivateInputField();
				i.Select();
				i.MoveTextEnd(false);
				i.ProcessEvent(Event.KeyboardEvent("b"));
//				inputField.ProcessEvent(Event.KeyboardEvent("a"));
//				i.text += "a";
//				i.textComponent.text += "a";
			}
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			GameObject go = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
			if (go != null)
			{
				InputField i = go.GetComponent<InputField>();
				if (i != null)
				{
					i.ProcessEvent(Event.KeyboardEvent("l"));
				}
			}
		}
	}
	
	 IEnumerator WaitForRequest(WWW www)
	 {
		yield return www;
	     // check for errors
	     if (www.error == null)
	     {
	         Debug.Log("WWW Ok!: " + www.data);
	     } else {
	         Debug.Log("WWW Error: "+ www.error);
	     }    
 }   


}
