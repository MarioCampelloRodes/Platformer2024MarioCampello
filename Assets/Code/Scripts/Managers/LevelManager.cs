using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float timeForRespawn = 2f;

    public int gemCount;

    private PlayerController _pCRef;
    private CheckpointController _cpRef;
    private UIController _uIRef;
    private PlayerHealthController _pHCRef;

    private void Start()
    {
        _pCRef = GameObject.Find("Player").GetComponent<PlayerController>();
        _cpRef = GameObject.Find("CheckpointController").GetComponent<CheckpointController>();
        _uIRef = GameObject.Find("Canvas").GetComponent<UIController>();
        _pHCRef = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCO());
    }

    private IEnumerator RespawnPlayerCO()
    {
        _pCRef.gameObject.SetActive(false);

        yield return new WaitForSeconds(timeForRespawn);
        _pCRef.gameObject.SetActive(true);
        _pCRef.gameObject.transform.position = _cpRef.spawnPoint;
        _pCRef.canDash = true;
        _pHCRef.currentHealth = _pHCRef.maxHealth;
        _uIRef.UpdateHealth();

        AudioManager.aMRef.PlaySFX(11);
    }

    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCO());
    }

    private IEnumerator ExitLevelCO()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("LevelSelector");
    }
}
