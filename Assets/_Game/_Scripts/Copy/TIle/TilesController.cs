using System;
using System.Collections.Generic;
using UnityEngine;
// using Test;

namespace _Game._Scripts.Copy.TIle
{
    public class TilesController: Singleton<TilesController>
    {
        public Transform parentTiles;
        
        public float rotationAngle; 
        public float timeRotation = 0.2f;
        
        private List<Tile> _tiles = new List<Tile>();

        private List<Vector3> _posTiles = new List<Vector3>(); // for test save
        private List<Quaternion> _rotTiles = new List<Quaternion>(); // for test save
        
        
        private bool _simulated = false;

        public Action<Tile> OnCreateTile;

        public Action<Tile> CreatedTile;
        public Action<Tile> RemovedTile;
        private void OnDestroy()
        {
            OnCreateTile -= AddOneTile;
            GameManager.Instance.OnStartGame -= StartSim;
            GameManager.Instance.OnStopGame -= StopSim;
            GameManager.Instance.OnEndGame -= StopSim;
        }

        public void Start()
        {
            AddAllTiles();
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            OnCreateTile += AddOneTile;
            GameManager.Instance.OnStartGame += StartSim;
            GameManager.Instance.OnStopGame += StopSim;
            GameManager.Instance.OnEndGame += StopSim;
        }

        public void AddAllTiles()
        {
            var count = parentTiles.childCount;
            
            for (int i = 0; i < count; i++)
            {
                var thisChild = parentTiles.GetChild(i);
                _tiles.Add(thisChild.GetComponent<Tile>());
            }
        }

        public void AddOneTile(Tile newTile)
        {
            _tiles.Add(newTile);
            SaveMap();
        }
        public void RemoveOneTile(Tile tile) //to storage
        {
            // Debug.Log(tile.name);
            _tiles.Remove(tile);
            Destroy(tile.gameObject);
            SaveMap();
        }

        public void RemoveAllTiles()
        {
            if(_tiles.Count > 0)
            {
                foreach (var tile in _tiles)
                {
                    Destroy(tile.gameObject);
                }
                _tiles.Clear();
            }
        }

        public void StartSim()
        {
            if (CheckContactsTiles())
            {
                Debug.Log("start-sim");
                if (_simulated) return;
                
                _simulated = true;
                
                SaveMap();
                
                foreach (var tile in _tiles)
                {
                    tile.StartSimulation();
                }
            }
        }

        
        public void StopSim()
        {
            if (_posTiles.Count == 0 || _rotTiles.Count == 0) return;
            
            _simulated = false;
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].transform.position = _posTiles[i];
                _tiles[i].transform.rotation = _rotTiles[i];
                _tiles[i].StopSimulation();
            }
        }
        public bool CheckContactsTiles()
        {
            foreach (var tile in _tiles)
            {
                if (tile.CheckContacts())
                {
                    return false;
                }
            }

            return true;
        }

        public void SaveMap()
        {
            if (_posTiles.Count > 0 || _rotTiles.Count > 0)
            {
                _posTiles.Clear();
                _rotTiles.Clear();
            }
            foreach (var tile in _tiles)
            {
                _posTiles.Add(tile.transform.position);
                _rotTiles.Add(tile.transform.rotation);
            }

            // TestSaveToStorage();
        }

        // void TestSaveToStorage()
        // {
        //     TestDataForLevel.Instance.SaveMap(_tiles);
        //     // var data = new MapData();
        //     // data.Name = "test_map";
        //     // data.Tiles = new List<TileData>();
        //     // foreach (var tile in _tiles)
        //     // {
        //     //     var tileData = new TileData(tile.itemTypeData, new Vector2XY(tile.transform.position),
        //     //         new Vector2XY(tile.transform.rotation.eulerAngles));
        //     //     data.Tiles.Add(tileData);
        //     // }
        //     //
        //     // var localStorageService = new YandexStorageService();
        //     // localStorageService.SaveMap(data);
        //     // //Storage.MapDataToJson(data);
        // }
    }
}