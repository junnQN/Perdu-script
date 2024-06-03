using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class EntityFX : MonoBehaviour
{
    protected Player player;
    private SpriteRenderer sr;

    [Header("Pop Up Text")] 
    [SerializeField] private GameObject popUpTextPrefab;
    
    [Header("FlashFX")] 
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat; 
    private Material originalMat;

    [Header("Hit FX")] 
    [SerializeField] private GameObject hitFX;

    private GameObject myHealthBar;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;

        myHealthBar = GetComponentInChildren<HealthBarUI>().gameObject;
    }

    public void CreatePopUpText(string _text)
    {
        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(1.5f, 5);
        Vector3 positionOffset = new Vector3(randomX, randomY, 0);
        GameObject newText = Instantiate(popUpTextPrefab, transform.position+positionOffset, Quaternion.identity);
        newText.GetComponent<TextMeshPro>().text = _text;
    }
   
    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(flashDuration);
        sr.material = originalMat;
      
    }

    private void RedColorBlink()
    {
        if(sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }
   
    private void CancelRedBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }

    public void MakeTransparent(bool _transparent)
    {
        if (_transparent)
        {
            myHealthBar.SetActive(false);
            sr.color = Color.clear;
        }
        else
        {
            myHealthBar.SetActive(true);
            sr.color = Color.white;
        }
        
    }
    
    public void CreateHitFX(Transform _target)
    {
        float zRotation = Random.Range(-90,90);
        float xPosition = Random.Range(-.5f, .5f);
        float yPosition = Random.Range(-.5f, .5f);
            
        GameObject newHitFx = Instantiate(hitFX, _target.position + new Vector3(xPosition,yPosition), Quaternion.identity);
        newHitFx.transform.Rotate(new Vector3(0, 0, zRotation));
        
        Destroy(newHitFx, .5f);
    }
}