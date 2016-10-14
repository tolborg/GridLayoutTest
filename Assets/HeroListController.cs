using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroListController : MonoBehaviour 
{
	public GameObject _content;
	public GameObject _heroListItemPrefab;

	private int[] rarities = { 1,1,2,3,2,1,2,3,2,3,2,2,3,3,1,1,2,2,3,3,3,2,1,1,2,3 };


	void Start() 
	{
		foreach (int rarity in rarities)
		{
			GameObject heroListItem = Instantiate(_heroListItemPrefab, _content.transform) as GameObject;
			heroListItem.GetComponent<HeroListItemController>().InitHero(rarity);
		}
	}



	public void FilterHeroes(int rarity)
	{
		foreach (Transform heroListItem in _content.transform)
		{
			heroListItem.GetComponent<HeroListItemController>().FilterHero(rarity);
		}

	}
		

}
