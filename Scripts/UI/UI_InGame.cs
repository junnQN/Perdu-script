using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] private GameObject dashGO;
    [SerializeField] private GameObject healGO;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Slider slider;

    [SerializeField] private Image dashImage;
    [SerializeField] private Image flaskImage;
    
    private SkillManager skills;

    [Header("Souls info")]
    [SerializeField] private TextMeshProUGUI currentSouls;
    [SerializeField] private float soulsAmount;
    [SerializeField] private float increaseRate = 100;

    void Start()
    {
        if (playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;

        skills = SkillManager.instance;
    }
    
    void Update()
    {
        UpdateSoulsUI();

        if(skills.dash.dashUnlocked==false)
            dashGO.SetActive(false);
        else
            dashGO.SetActive(true);
        
        if(skills.heal.healUnlock==false)
            healGO.SetActive(false);
        else
        {
            healGO.SetActive(true);
        }
            
        
        if(Input.GetKeyDown(KeyCode.LeftShift))
            SetCoolDownOf(dashImage);
        if(Input.GetKeyDown(KeyCode.F))
            SetCoolDownOf(flaskImage);
        
        CheckCooldownOf(dashImage,skills.dash.cooldown);
        CheckCooldownOf(flaskImage,Inventory.instance.flaskCoolDown);
    }

    private void UpdateSoulsUI()
    {
        if (soulsAmount < PlayerManager.instance.GetCurrency())
        {
            soulsAmount += Time.deltaTime * increaseRate;
        }
        else
            soulsAmount = PlayerManager.instance.GetCurrency();

        currentSouls.text = ((int)soulsAmount).ToString();
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }

    private void SetCoolDownOf(Image _image)
    {
        if (_image.fillAmount <= 0)
            _image.fillAmount = 1;
    }

    private void CheckCooldownOf(Image _image, float _cooldown)
    {
        if (_image.fillAmount > 0)
            _image.fillAmount -= 1 / _cooldown * Time.deltaTime;
    }
}
