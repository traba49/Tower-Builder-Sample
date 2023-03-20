using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace TowerCreatorNS
{
    public class TowerCreator : MonoBehaviour
    {
        public TowerScriptable Tower;
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
            Tower = new TowerScriptable(3);
            _infoText.text = "";
            UpdateText();
        }

        private void UpdateText()
        {
            _infoText.text = Tower.ModulesToText();

        }

        public void AddModule(ModuleHolder holder, int slot)
        {
            Tower.Modules[slot] = holder.ReturnType();
            UpdateText();
        }

        public void ChangeAimType(AimHolder holder)
        {
            Tower.AimType = holder.ReturnType();
            UpdateText();
        }

        public void SaveTower()
        {
            SaveData data = SavingSystem.LoadedData();
            data.AddTower(Tower);
            SavingSystem.Savegame(data);
        }
    }
}