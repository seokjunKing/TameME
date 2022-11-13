using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
public class Blue : MonoBehaviour
{
    public Tilemap GroundTilemap;
    public Tilemap BlueTilemap;
    public Tilemap GreenTilemap;
 
    public TileBase NormalTile;
    public TileBase BlueTile;
    public TileBase GreenTile;

    public GameController controller;
    public PlayerController player;

    public LayerMask whatisPlatform;

    Vector2 MousePosition;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            TileChange();
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                UnityEngine.Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Moved)
                {
                    MousePosition = Camera.main.ScreenToWorldPoint(touch.position);

                    transform.position = MousePosition;

                    Vector3Int bl_cellposition = BlueTilemap.WorldToCell(MousePosition);
                    Vector3Int gr_cellposition = GreenTilemap.WorldToCell(MousePosition);

                    Collider2D overCollider2d = Physics2D.OverlapCircle(MousePosition, 0.000001f, whatisPlatform);

                    if (overCollider2d != null)
                    {
                        if (controller._isBlue)
                        {
                            GreenTilemap.SetTile(gr_cellposition, null);
                            BlueTilemap.SetTile(bl_cellposition, BlueTile);
                            Debug.Log("Bl");
                        }
                        else if (controller._isGreen)
                        {
                            BlueTilemap.SetTile(bl_cellposition, null);
                            GreenTilemap.SetTile(gr_cellposition, GreenTile);
                            Debug.Log("Gr");
                        }
                        else if (controller._isBlack)
                        {
                            BlueTilemap.SetTile(bl_cellposition, null);
                            GreenTilemap.SetTile(gr_cellposition, null);
                            Debug.Log("Er");
                        }

                    }
                }
            }
        }
#elif UNITY_STANDALONE_WIN
        if (Input.GetMouseButton(0))
        {
            TileChange();
        }
#endif

        if (player.isDead)
        {
            BlueTilemap.ClearAllTiles();
            GreenTilemap.ClearAllTiles();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(MousePosition, 0.2f);
    }

    void TileChange()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = MousePosition;

        Vector3Int bl_cellposition = BlueTilemap.WorldToCell(MousePosition);
        Vector3Int gr_cellposition = GreenTilemap.WorldToCell(MousePosition);

        Collider2D overCollider2d = Physics2D.OverlapCircle(MousePosition, 0.000001f, whatisPlatform);

        if (overCollider2d != null)
        {
            if (controller._isBlue)
            {
                GreenTilemap.SetTile(gr_cellposition, null);
                BlueTilemap.SetTile(bl_cellposition, BlueTile);
                Debug.Log("Bl");
            }
            else if (controller._isGreen)
            {
                BlueTilemap.SetTile(bl_cellposition, null);
                GreenTilemap.SetTile(gr_cellposition, GreenTile);
                Debug.Log("Gr");
            }
            else if (controller._isBlack)
            {
                BlueTilemap.SetTile(bl_cellposition, null);
                GreenTilemap.SetTile(gr_cellposition, null);
                Debug.Log("Er");
            }
        }
    }
}