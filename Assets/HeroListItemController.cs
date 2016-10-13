using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroListItemController : MonoBehaviour 
{
	public int _rarity;
	public GameObject _rarityText;


	public void SomeFunction(int rarity)
	{


		StartCoroutine(Deactivate(() => {

			if (rarity == 0 || rarity == _rarity)
			{
				StartCoroutine(Activate());
			}
				
		}));

	}








	IEnumerator Deactivate(System.Action callback = null)
	{
		float i = 0;
		float rate = 1 / 2f;

		while (i < 1)
		{
			i += Time.deltaTime * rate;
			gameObject.GetComponent<CanvasGroup>().alpha = 1 - i;
			yield return null;
		}

		gameObject.GetComponent<LayoutElement>().ignoreLayout = true;
			
		if (callback != null) { callback(); }
	}


	IEnumerator Activate(System.Action callback = null)
	{
		gameObject.GetComponent<LayoutElement>().ignoreLayout = false;

		float i = 0;
		float rate = 1 / 2f;

		while (i < 1)
		{
			i += Time.deltaTime * rate;
			gameObject.GetComponent<CanvasGroup>().alpha = i;
			yield return null;
		}
			
		if (callback != null) { callback(); }
	}






}
