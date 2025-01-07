using System;
using UnityEngine;

public class AttributeBTN : MonoBehaviour
{
    public static event Action<AttributeType> OnAtributeSelectedEvent;

    [Header("Config")]
    [SerializeField] AttributeType _attribute;

    public void SelectAttribute() {
        OnAtributeSelectedEvent?.Invoke(_attribute);
    }
}
