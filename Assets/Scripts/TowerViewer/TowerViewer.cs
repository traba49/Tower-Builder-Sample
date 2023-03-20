using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace TowerViewer
{
    public class TowerViewer : MonoBehaviour
    {
        [SerializeField] Transform _scrollableList;
        [SerializeField] GameObject _towerPref;
        [SerializeField] TextMeshProUGUI _infoText;
        private SaveData _data;
        private int _towerNumber;

        public void GenerateList()
        {
            _data = SavingSystem.LoadedData();
            int i = 0;
            foreach (Transform child in _scrollableList.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (TowerScriptable tower in _data.TowerList)
            {
                if (_data.TowerList[i] != null)
                {
                    GameObject go = Instantiate(_towerPref, _scrollableList);
                    go.GetComponent<TowerButton>().SetTowerViewer(this, tower.SaveInt);
                }
                i++;
            }
        }

        private void ShowInfo()
        {
            _infoText.text = _data.TowerList[_towerNumber].ModulesToText();
        }

        public void SetTowerNumber(int i)
        {
            _towerNumber = i;
            ShowInfo();
        }

        public void DeleteTower()
        {
            _data.DeleteTower(_towerNumber);
            SavingSystem.Savegame(_data);
        }
    }
}