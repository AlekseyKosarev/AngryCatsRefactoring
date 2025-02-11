// using System.Collections.Generic;
// using UnityEngine;
//
// public class TileMoveController: Singleton<TileMoveController>
// {
//     private GameObject _selectedTile = null;
//     
//     public void SetSelectedTile(GameObject tile)
//     {
//         _selectedTile = tile;
//     }
//     public void ClearSelectedTile()
//     {
//         _selectedTile = null;
//     }
//     public void MoveSelectedTile()
//     {
//         if (_selectedTile != null)
//         {
//             _selectedTile.transform.position = Input.mousePosition;
//         }
//     }
//     
//     public void Move(Vector2 posDrag)
//     {
//         var worldPos = Camera.main.ScreenToWorldPoint(posDrag);
//         var dragPos = new Vector2(worldPos.x, worldPos.y);
//
//         var x = (float)Math.Round(dragPos.x, 1);
//         var y = (float)Math.Round(dragPos.y, 1);
//             
//         var convertPos = new Vector2(x, y);
//             
//         var toMovePos = convertPos;
//             
//         transform.position = toMovePos;
//     }
//     
//     public void Rotate()
//     {
//         if(_rotateTween != null) return;
//             
//         var angle = TilesController.Instance.rotationAngle;
//         var angleT = 15f;
//         var timeRotation = TilesController.Instance.timeRotation;
//         var localRot = (float)Math.Round(transform.localRotation.eulerAngles.z);
//         localRot -= (localRot % angle);
//         var testA = localRot % angleT;
//         var endRot = new Vector3(0, 0, angle) + new Vector3(0,0,localRot);
//         _rotateTween = transform.DOLocalRotate(endRot, timeRotation).OnComplete((() =>
//         {
//             _rotateTween.Kill();
//             _rotateTween = null;
//         }));
//     }
//     
// }