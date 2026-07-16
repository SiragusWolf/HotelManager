using UnityEngine;

public class Room : MonoBehaviour, IClickable
{
    public int roomLevel;

    public bool isOccupied;
    public bool isAssisted;
    public GameObject currentMonster;
    public GameObject currentAssistant;
    public Assistant currentAssistantRef;
    public GameObject isOccupiedIcon;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] doorLevelSprites;

    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        updateLevelSprite();
    }

    private void Update()
    {
        isOccupiedIcon.SetActive(isOccupied);
    }

    public void OnClick(GameObject selectedObject)
    {
        if (selectedObject.GetComponent<Monster>() != null && !isOccupied)
        {
            currentMonster = InputManager.Instance._ColaNueva.DequeueTest();
            if (currentMonster == null)
            {
                InputManager.Instance.clearSelected();
                return;
            }

            GetComponent<DoorState>().isOpen = true;
            Debug.Log("room recibio:" + currentMonster);
            currentMonster.GetComponent<Monster>().EnterRoom(this);
            isOccupied = true;
            InputManager.Instance.clearSelected();
        }
        else if (selectedObject.GetComponent<RoomUpgrade>() != null)
        {
            levelUp();
            InputManager.Instance.clearSelected();
        }
        else if (selectedObject.GetComponent<Assistant>() != null && isOccupied && !isAssisted && InputManager.Instance.roomOk == true)
        {
            currentAssistant = InputManager.Instance.SelectedServiceAssistant != null ? InputManager.Instance.SelectedServiceAssistant : selectedObject;
            if (!InputManager.Instance._pilaNueva.StartService(currentAssistant))
            {
                currentAssistant = null;
                InputManager.Instance.ClearServiceSelection();
                return;
            }

            GetComponent<DoorState>().isOpen = true;
            Debug.Log("current assistant" + currentAssistant.name);
            isAssisted = true;
            currentAssistantRef = currentAssistant.GetComponent<Assistant>();
            InputManager.Instance.ClearServiceSelection();
            currentAssistantRef.EnterRoom(this);
        }
    }

    private void levelUp()
    {
        if (roomLevel < 2 && GameManager.Instance.Currency >= 100)
        {
            GameManager.Instance.Currency -= 100;
            roomLevel++;
        } else if (GameManager.Instance.Currency < 100)
        {
            Debug.Log("No tenes suficiente oro!");
        }
        updateLevelSprite();
    }

    private void updateLevelSprite()
    {
        if (roomLevel > 2)
        {
            roomLevel = 2;
        }
        _spriteRenderer.sprite = doorLevelSprites[roomLevel];
    }

    public void roomCleared()
    {
        currentMonster = null;
        isOccupied = false;
    }

    public void assistantCleared()
    {
        currentAssistant = null;
        currentAssistantRef = null;
        isAssisted = false;
    }
}
