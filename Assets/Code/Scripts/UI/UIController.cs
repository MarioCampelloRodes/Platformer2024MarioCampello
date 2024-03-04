using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    public Sprite fullHeart, emptyHeart;

    public TextMeshProUGUI gemText;

    private PlayerHealthController _pHRef;

    private LevelManager _lMRef;
    // Start is called before the first frame update
    void Start()
    {
        _pHRef = GameObject.Find("Player").GetComponent<PlayerHealthController>();

        _lMRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        UpdateGemCount();
    }

    public void UpdateHealth()
    {
        switch (_pHRef.currentHealth)
        {
            case 3:
            {
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;
            }

            case 2:
            {
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;
            }

            case 1:
            {
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            }

            case 0:
            {
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            }
            default:
            {
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            }
        }
    }

    public void UpdateGemCount()
    {
        gemText.text = _lMRef.gemCount.ToString();
    }
}
