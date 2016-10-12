using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroPositionController : MonoBehaviour 
{
	public int _rarity;
	public GameObject _heroListItem;


	IEnumerator DeactiveListItem(float time)
	{
		float i = 1;
		float rate = 1 / time;

		while (i > 0)
		{
			Debug.Log(i);
			_heroListItem.GetComponent<CanvasGroup>().alpha = i;
			i -= Time.deltaTime * rate;
			yield return null;
		}


		//_heroListItem.GetComponent<CanvasGroup>().alpha = 0;
	}
}
