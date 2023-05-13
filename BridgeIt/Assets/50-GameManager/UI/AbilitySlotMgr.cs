using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotMgr : MonoBehaviour
{
    [SerializeField] private GameObject abilitySlot;
    [SerializeField] private Transform abilityFrame;
    [SerializeField] private AbilitySlot[] slotSOList;

    private List<AbilitySlotCntrl> slotList = null;

    // Start is called before the first frame update
    void Start()
    {
        slotList = new List<AbilitySlotCntrl>();

        foreach(AbilitySlot slotSO in slotSOList) 
        {
            GameObject go = Instantiate(abilitySlot, abilityFrame);
            AbilitySlotCntrl abilitySlotCntrl = go.GetComponent<AbilitySlotCntrl>();
            abilitySlotCntrl.Init(slotSO);

            slotList.Add(abilitySlotCntrl);
        }
    }

    private void UpdateAbilities(int score)
    {
        if (slotList != null) {
            foreach(AbilitySlotCntrl slot in slotList) 
            {
                slot.CheckPoints(score);
            }
        }
    }

    private void OnEnable()
    {
        UICntrl.OnScoreUpdate += UpdateAbilities;
    }

    private void OnDisable() 
    {
        UICntrl.OnScoreUpdate -= UpdateAbilities;
    }
}
