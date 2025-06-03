using UnityEngine;

namespace Game
{
    public class IdComponent : MonoBehaviour
    {
        public string Id => _id;

        [SerializeField]
        private string _id;
    }
}