using Sirenix.OdinInspector;
using UnityEngine;

namespace GRIS.Tools
{
    public class FPSSetter : MonoBehaviour
    {
        [PropertyRange(0, 60)]
        [SerializeField] private int _targetFPS;

        private void Start() => SetFps();

        private void OnValidate() => SetFps();

        private void SetFps() => Application.targetFrameRate = _targetFPS;
    }
}