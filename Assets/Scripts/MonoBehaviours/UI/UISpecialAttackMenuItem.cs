using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISpecialAttackMenuItem : UIItem
{
    public AttackDefinition AttackDefinition => _attackDefinition;
    public bool IsSelectable { get; private set; }

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _mpCost;
    
    AttackDefinition _attackDefinition;

    public void Init(AttackDefinition attackDefinition, bool isSelectable)
    {
        _attackDefinition = attackDefinition;

        _text.SetText(attackDefinition.Name);
        _mpCost.SetText(attackDefinition.MPCost.ToString());
        IsSelectable = isSelectable;

        if (!IsSelectable)
            _mpCost.color = Color.black;
    }

    public void SetActiveState(bool isActive)
    {
        this.isActive = isActive;
        SetState();
    }
}
