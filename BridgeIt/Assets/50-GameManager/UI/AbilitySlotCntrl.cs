using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilitySlotCntrl : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsTxt;
    [SerializeField] private TMP_Text stackTxt;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image focusImage;
    [SerializeField] private Image frameImage;

    private AbilitySlot data;
    
    // Start is called before the first frame update
    void Start()
    {
        // points.gameObject.SetActive(false);
        // stack.gameObject.SetActive(false);
        // image.gameObject.SetActive(false);
        // focus.gameObject.SetActive(false);
        // frame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(AbilitySlot data) 
    {
        this.data = data;
        iconImage.sprite = data.sprite;
        pointsTxt.text = data.points.ToString();

        SetNonAbility();
    }

    public void CheckPoints(int score)
    {
        if (score > data.points)
        {
            SetReadyToUse();
        }
    }

    private void SetNonAbility()
    {
        pointsTxt.gameObject.SetActive(true);
        stackTxt.gameObject.SetActive(false);
        iconImage.gameObject.SetActive(false);
        focusImage.gameObject.SetActive(false);
        frameImage.gameObject.SetActive(false);
    }

    private void SetReadyToUse()
    {
        pointsTxt.gameObject.SetActive(false);
        stackTxt.gameObject.SetActive(true);
        iconImage.gameObject.SetActive(true);
        focusImage.gameObject.SetActive(false);
        frameImage.gameObject.SetActive(true);
    }
}
