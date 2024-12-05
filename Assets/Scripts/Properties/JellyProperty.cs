using DefaultNamespace;
using UnityEngine;

namespace Properties
{
    //[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public abstract class JellyProperty : ScriptableObject
    {
        public abstract void Apply(JellyBaby baby, JellyBodyPart part = JellyBodyPart.All);
    }
}