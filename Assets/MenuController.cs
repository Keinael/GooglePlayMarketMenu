using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int sensivityX;
    public int sensivityY;
    public Component swipePanel;

    private float _mouseCoordinateDragStartX;
    private float _mouseCoordinateDragEndX;
    private float _mouseCoordinateDragStartY;
    private float _mouseCoordinateDragEndY;
    private bool _isMenuOpened;
    private bool _isSwipedUp;

    void Start()
    {
        _isMenuOpened = false;
        _isSwipedUp = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _mouseCoordinateDragStartX = Input.mousePosition.x;
        _mouseCoordinateDragStartY = Input.mousePosition.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
               
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _mouseCoordinateDragEndX = Input.mousePosition.x;
        _mouseCoordinateDragEndY = Input.mousePosition.y;

        if (Mathf.Abs(_mouseCoordinateDragStartX - _mouseCoordinateDragEndX) > Mathf.Abs(_mouseCoordinateDragStartY - _mouseCoordinateDragEndY))
        {
            SwipeHorizontally();
        }
        else
        {
            SwipeVertically();
        }
    }

    public void SwipeHorizontally()
    {
        if (!_isMenuOpened)
        {
            swipePanel.GetComponent<Animation>().PlayQueued("swipeRight", QueueMode.CompleteOthers);
            _isMenuOpened = true;
        }
        else
        {
            swipePanel.GetComponent<Animation>().PlayQueued("swipeLeft", QueueMode.CompleteOthers);
            _isMenuOpened = false;
        }
    }

    public void SwipeVertically()
    {
        if (_isMenuOpened && !_isSwipedUp && Mathf.Abs(_mouseCoordinateDragStartX - _mouseCoordinateDragEndX) < Mathf.Abs(_mouseCoordinateDragStartY - _mouseCoordinateDragEndY) && _mouseCoordinateDragStartY < _mouseCoordinateDragEndY)
        {
            swipePanel.GetComponent<Animation>().PlayQueued("swipeUp", QueueMode.CompleteOthers);
            _isSwipedUp = true;
        }
        else if (_isMenuOpened && _isSwipedUp && Mathf.Abs(_mouseCoordinateDragStartX - _mouseCoordinateDragEndX) < Mathf.Abs(_mouseCoordinateDragStartY - _mouseCoordinateDragEndY) && _mouseCoordinateDragStartY > _mouseCoordinateDragEndY)
        {
            swipePanel.GetComponent<Animation>().PlayQueued("swipeDown", QueueMode.CompleteOthers);
            _isSwipedUp = false;
        }
    }
}
