using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
	private static UIManager _instanse;
	
	public static UIManager Instance
	{
		get {
			if (!_instanse)
			{
				Debug.LogError("UI Manger is Null");

			}
			return _instanse;
		}

	}

	public Text playerGemCountText;
	public Image _selectionImage;
	public Text _gemCount;
	public Image[] _lifes;
	public void OpenShop(int gemValue) {

		playerGemCountText.text = gemValue.ToString();
	}
	public void UpdateSelection (float yPos)
	{
		_selectionImage.rectTransform.anchoredPosition = new Vector2(0, yPos);
	}


	public void GemCountUpdater(int gems) {
		_gemCount.text = gems.ToString();
	}
	public void UpdateLivesCount(int currentLives) {
		if (currentLives < 0)
		{
			return;
		}
		_lifes[currentLives].gameObject.SetActive(false);

	}

	private void Awake()
	{
		_instanse = this;
	}


}
