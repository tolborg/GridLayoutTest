using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroListItemController : MonoBehaviour 
{
	private int _rarity;

	[SerializeField]
	private GameObject _rarityText;

	[SerializeField]
	private float _transitionOutSpeed;

	[SerializeField]
	private float _transitionInSpeed;



	public void InitHero(int rarity)
	{
		_rarity = rarity;
		_rarityText.GetComponent<Text>().text = rarity.ToString();
	}


	public void FilterHero(int rarity)
	{
		StartCoroutine(TransitionOut(() => {
			gameObject.GetComponent<LayoutElement>().ignoreLayout = true;

			if (rarity == 0 || rarity == _rarity)
			{
				gameObject.GetComponent<LayoutElement>().ignoreLayout = false;
				StartCoroutine(TransitionIn());
			}
		}));
	}



	IEnumerator TransitionOut(System.Action callback = null)
	{
		float i = 0;
		float rate = 1 / _transitionOutSpeed;

		while (i < 1)
		{
			i += Time.deltaTime * rate;
			if (gameObject.GetComponent<CanvasGroup>().alpha > 0)
			{
				gameObject.GetComponent<CanvasGroup>().alpha = 1-i;
			}
			yield return null;
		}
		gameObject.GetComponent<CanvasGroup>().alpha = 0;
		if (callback != null) { callback(); }
	}



	IEnumerator TransitionIn(System.Action callback = null)
	{
		float i = 0;
		float rate = 1 / _transitionInSpeed;

		while (i < 1)
		{
			i += Time.deltaTime * rate;
			if (gameObject.GetComponent<CanvasGroup>().alpha < 1)
			{
				gameObject.GetComponent<CanvasGroup>().alpha = i;
			}
			yield return null;
		}
		gameObject.GetComponent<CanvasGroup>().alpha = 1;
		if (callback != null) { callback(); }
	}
		
}
