using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace TowerCreatorNS
{
    public class TowerCreator : MonoBehaviour
    {
        private TowerScriptable _tower;
        public static TowerCreator Instance;
        [SerializeField] TextMeshProUGUI _infoText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void CreateTower()
        {
            _tower = new TowerScriptable(3);
            _infoText.text = "";
            UpdateText();
        }

        private void UpdateText()
        {
            _infoText.text = _tower.ModulesToText();
        }

        public void AddModule(ModuleHolder holder, int slot)
        {
            if (_tower.Modules[slot] != holder.ReturnType())
            {
                _tower.Modules[slot] = holder.ReturnType();
                UpdateText();
            }
        }

        public void ChangeAimType(AimHolder holder)
        {
            if (_tower.AimType != holder.ReturnType())
            {
                _tower.AimType = holder.ReturnType();
                UpdateText();
            }
        }

        public void SaveTower()
        {
            SaveData data = SavingSystem.LoadedData();
            data.AddTower(_tower);
            SavingSystem.Savegame(data);
        }
    }
}