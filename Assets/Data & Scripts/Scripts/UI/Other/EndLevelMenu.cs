using UnityEngine;

public class EndLevelMenu : Menu
{
    [SerializeField] private FinalDamageText _finalDamageText;

    public FinalDamageText FinalDamageText => _finalDamageText;
}