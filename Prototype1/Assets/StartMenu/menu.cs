using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour 
{
	//public string SceneName;
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	void Start ()

	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
	
	}

	public void ExitPress()

	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	
	}

	public void NoPress()
		
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		
	}

	public void StartLevel ()

	{
		SceneManager.LoadScene ("Prototype House");
		//Fading.Instance.StartFade(SceneName);
	}


	public void ExitGame ()
		
	{
		Application.Quit();
		
	}





}
