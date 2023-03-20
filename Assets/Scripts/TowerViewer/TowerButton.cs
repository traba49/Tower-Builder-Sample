using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TowerViewer
{
    public class TowerButton : MonoBehaviour
    {
        private TowerViewer _towerViewer;
        private int _saveInt;
        private Button _button;
        private TextMeshProUGUI _text;
        // Start is called before the first frame update
        void SetListener()
        {
            _button = GetComponentInChildren<Button>();
            _button.onClick.AddListener(delegate
            {
                _towerViewer.SetTowerNumber(_saveInt);
            }
            );
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _text.text = "Tower " + _saveInt.ToString();
        }

        // Update is called once per frame
        public void SetTowerViewer(TowerViewer towerViewer, int saveint)
        {
            _towerViewer = towerViewer;
            _saveInt = saveint;
            SetListener();
        }
    }
}