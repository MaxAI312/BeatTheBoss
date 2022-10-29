using UnityEngine;

public class FinisherMenu : Menu
{
    [SerializeField] private WeaponChooser _weaponChooser;
    [SerializeField] private MultiplierView _multiplierView;
    [SerializeField] private TappingBarLoss _tappingBarLoss;
    [SerializeField] private TappingBarIncome _tappingBarIncome;
    [SerializeField] private UIWidgetTapBar _tapBar;
    [SerializeField] private TappingHandPoint _tappingHandPoint;

    public WeaponChooser WeaponChooser => _weaponChooser;
    public MultiplierView MultiplierView => _multiplierView;
    public TappingBarLoss TappingBarLoss => _tappingBarLoss;
    public TappingBarIncome TappingBarIncome => _tappingBarIncome;
    public UIWidgetTapBar UIWidgetTapBar => _tapBar;
    public TappingHandPoint TappingHandPoint => _tappingHandPoint;

    public void EnableUICards()
    {
        _weaponChooser.OnSelectCard();
    }
}