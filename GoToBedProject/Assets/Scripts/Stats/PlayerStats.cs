using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerStats : Stats
{
    private float _staminaValue;
    [SerializeField]
    private float _concealmentValue;
    private float _noiseValue;
    [SerializeField]
    private GameObject _equippedItem;
    [SerializeField]
    private Transform _handPosition;
    [SerializeField]
    private bool _itemPickUpAnimationBool;
    [SerializeField]
    private CharacterController _playerController;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _groundDistance = 0.3f;
    [SerializeField]
    private LayerMask _groundmask;
    [SerializeField]
    private Globals.InteractingObjects _lookingAtInteractable = Globals.InteractingObjects.None;
    [SerializeField]
    private float _interactRange;
    [SerializeField]
    private GameObject _interactingObject;
    [SerializeField]
    private GameObject _playerCamera;
    [SerializeField]
    private bool _insideHidingObject;
    [SerializeField]
    private float _interactionCooldown;
    [SerializeField]
    private float _interactionCooldownValue = 2;
    [SerializeField]
    private GameObject _staminaObject;
    [SerializeField]
    private List<GameObject> _lightsInRange = new List<GameObject>();
    [SerializeField]
    private InteractText _uiInteractionTextObject;
    public float ConcealmentValue { get => _concealmentValue; set => _concealmentValue = value; }
    public float StaminaValue { get => _staminaValue; set => _staminaValue = value; }
    public float NoiseValue { get => _noiseValue; set => _noiseValue = value; }
    public float GroundDistance { get => _groundDistance; set => _groundDistance = value; }
    public LayerMask Groundmask { get => _groundmask; set => _groundmask = value; }
    public Transform GroundCheck { get => _groundCheck; set => _groundCheck = value; }
    public CharacterController PlayerController { get => _playerController; set => _playerController = value; }
    public Globals.InteractingObjects LookingAtInteractable { get => _lookingAtInteractable; set => _lookingAtInteractable = value; }
    public float InteractRange { get => _interactRange; set => _interactRange = value; }
    public GameObject InteractingObject { get => _interactingObject; set => _interactingObject = value; }
    public GameObject PlayerCamera { get => _playerCamera; set => _playerCamera = value; }
    public bool InsideHidingObject { get => _insideHidingObject; set => _insideHidingObject = value; }
    public float InteractionCoolDown { get => _interactionCooldown; set => _interactionCooldown = value; }
    public float InteractionCooldownValue { get => _interactionCooldownValue; set => _interactionCooldownValue = value; }
    public GameObject StaminaObject { get => _staminaObject; set => _staminaObject = value; }
    public List<GameObject> LightsInRange { get => _lightsInRange; set => _lightsInRange = value; }
    public GameObject EquippedItem { get => _equippedItem; set => _equippedItem = value; }
    public bool ItemPickUpAnimationBool { get => _itemPickUpAnimationBool; set => _itemPickUpAnimationBool = value; }
    public Transform HandPosition { get => _handPosition; set => _handPosition = value; }
    public InteractText UIInteractionTextObject { get => _uiInteractionTextObject; set => _uiInteractionTextObject = value; }
}
