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

    private int stack = 0;

    private SlotState state = SlotState.NOT_SELECTED;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

        SetNotSelected();
    }

    public void CheckPoints(int score)
    {
        if (score > data.points)
        {
            SetReadyToSelect();
        }
    }

    public void SelectAbility()
    {
        if (state == SlotState.READY_TO_SELECT)
        {
            GameManager.Instance.ClearAbilitySlotFocus();

            state = SlotState.SELECTED;

            pointsTxt.gameObject.SetActive(false);
            stackTxt.gameObject.SetActive(true);
            iconImage.gameObject.SetActive(true);
            focusImage.gameObject.SetActive(true);
            frameImage.gameObject.SetActive(true);

            Debug.Log("Select Ability ...");
        }
    }

    public void ClearFocus()
    {
        focusImage.gameObject.SetActive(false);

        if (state == SlotState.SELECTED) 
        {
            state = SlotState.READY_TO_SELECT;
        }
    }

    private void SetNotSelected()
    {
        state = SlotState.NOT_SELECTED;

        pointsTxt.gameObject.SetActive(true);
        stackTxt.gameObject.SetActive(false);
        iconImage.gameObject.SetActive(false);
        focusImage.gameObject.SetActive(false);
        frameImage.gameObject.SetActive(false);
    }

    private void SetReadyToSelect()
    {
        if (state == SlotState.NOT_SELECTED) 
        {
            state = SlotState.READY_TO_SELECT;

            pointsTxt.gameObject.SetActive(false);
            stackTxt.gameObject.SetActive(true);
            iconImage.gameObject.SetActive(true);
            focusImage.gameObject.SetActive(false);
            frameImage.gameObject.SetActive(true);

            stack += data.stack;
            stackTxt.text = stack.ToString();
        }
    }

    private enum SlotState 
    {
        NOT_SELECTED,
        READY_TO_SELECT,
        SELECTED
    }
}
