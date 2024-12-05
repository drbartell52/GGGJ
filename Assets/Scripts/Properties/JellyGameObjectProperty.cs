using DefaultNamespace;
using UnityEngine;

namespace Properties
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "JellyProp/GameObject Property", order = 0)]
    public class JellyGameObjectProperty : JellyProperty
    {
        public GameObject prefab;
        

        public override void Apply(JellyBaby baby, JellyBodyPart part)
        {
            Instantiate(prefab, baby.transform);
        }
    }
}