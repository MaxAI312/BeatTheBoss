using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WeaponChooser : MonoBehaviour
{
    [Header("Params")] 
    [SerializeField] private int _cardsCount;

    [Header("Links")] 
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private FinisherWeaponDataBundle _dataBundle;
    [SerializeField] private WeaponCardContainer _containerTemplate;
    [SerializeField] private Transform[] _cardPlaces;
    
    private List<WeaponCardContainer> _cards;
    private List<WeaponCardContainer> _initedCards;
    private List<FinisherWeaponData> _nonPicked;
    private List<FinisherWeaponData> _weapons;

    private void Awake()
    {
        _weapons = new List<FinisherWeaponData>();
        _nonPicked = new List<FinisherWeaponData>();
        _cards = new List<WeaponCardContainer>();
        _initedCards = new List<WeaponCardContainer>();

        for (var i = 0; i < _cardsCount; i++) InitCard();

        for (var i = 0; i < _dataBundle.WeaponCount; i++) _weapons.Add(_dataBundle[i]);
    }

    private void OnEnable()
    {
        foreach (var card in _cards)
        {
            card.PickedStart += OnPickedStart;
            card.PickedEnd += OnCardPicked;
        }
    }

    private void OnDisable()
    {
        foreach (var card in _cards)
        {
            card.PickedStart -= OnPickedStart;
            card.PickedEnd -= OnCardPicked;
        }
    }

    public event UnityAction PickStarted;
    public event UnityAction<FinisherWeaponData> PickEnded;

    private void OnPickedStart(WeaponCardContainer weaponCardContainer)
    {
        _canvasGroup.blocksRaycasts = false;
        foreach (var card in _cards.Where(card => card.IsClicked == false))
            card.ShowHide();
    }

    private void OnCardPicked(FinisherWeaponData data)
    {
        StartCoroutine(ShowCards(false));
        PickEnded?.Invoke(data);
    }

    private void InitCard()
    {
        var card = Instantiate(_containerTemplate, transform);
        card.gameObject.SetActive(false);
        _cards.Add(card);
    }

    private IEnumerator ShowCards(bool setActive)
    {
        if (setActive)
        {
            yield return new WaitForSeconds(0.75f);//MAGIK INT
            _cards[0].transform.localPosition = _cardPlaces[0].localPosition;//MAGIK INT
            _cards[0].gameObject.SetActive(true);
            //duplicate
            yield return new WaitForSeconds(0.2f);//MAGIK INT
            _cards[1].transform.localPosition = _cardPlaces[1].localPosition;//MAGIK INT
            _cards[1].gameObject.SetActive(true);//MAGIK INT
        }
        else
        {
            foreach (var card in _cards) card.gameObject.SetActive(setActive);
        }
    }

    public void OnSelectCard()
    {
        _nonPicked.Clear();
        _nonPicked = GetWeaponsToPick();

        if (_nonPicked.Count <= 0)
            return;

        PickStarted?.Invoke();
        _initedCards.Clear();

        foreach (var card in _cards)
            if (_nonPicked.Count > 0)
            {
                var index = Random.Range(0, _nonPicked.Count);

                card.InitCard(_nonPicked[index]);
                _nonPicked.RemoveAt(index);
                _initedCards.Add(card);
            }

        StartCoroutine(ShowCards(true));
    }

    private List<FinisherWeaponData> GetWeaponsToPick()
    {
        var currentWeapons = new List<FinisherWeaponData>();

        foreach (var weapon in _weapons) currentWeapons.Add(weapon);

        return currentWeapons;
    }
}