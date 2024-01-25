using Assets.Scripts.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [Serializable]
    public class HealthBarFloor
    {
        [SerializeField] private TMP_Text _floorHealthPoints;
        [SerializeField] private Image _floorHeathImage;
        [SerializeField] private Floor _floor;

        public TMP_Text FloorHpPoints => _floorHealthPoints;
        public Image FloorHpImage => _floorHeathImage;
        public Floor Floor => _floor;
    }
}