using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int sensivityX;
    public int sensivityY;
    public Animation animation;
    public GameObject swipePanel;
    public GameObject scrollView;

    private float _mouseCoordinateDragStartX;
    private float _mouseCoordinateDragEndX;
    private float _mouseCoordinateDragStartY;
    private float _mouseCoordinateDragEndY;

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
    }

    public void SwipeHorizontally()
    {
        if (swipePanel.GetComponent<RectTransform>().position.x <= 1)
        {
            animation.PlayQueued("swipeRight", QueueMode.CompleteOthers);
        }
        else if (swipePanel.GetComponent<RectTransform>().position.x >= 261)
        {
            animation.PlayQueued("swipeLeft", QueueMode.CompleteOthers);
        }
    }
}
