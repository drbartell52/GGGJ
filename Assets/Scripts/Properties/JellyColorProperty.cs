using System;
using DefaultNamespace;
using UnityEngine;

namespace Properties
{
    [CreateAssetMenu(fileName = "prop", menuName = "JellyProp/Color Property", order = 0)]
    public class JellyColorProperty : JellyProperty
    {
        public Color color;
        public override void Apply(JellyBaby baby, JellyBodyPart part = JellyBodyPart.All)
        {
            if (part == JellyBodyPart.All)
            {
                foreach (var m in baby.Meshes)
                {
                   m.material.color = color;
                }

                return;
            }
            if (part == JellyBodyPart.Arms)
            {
                foreach (var m in baby.ArmsMeshes)
                {
                    m.material.color = color;
                }
            }
            if (part == JellyBodyPart.Legs)
            {
                foreach (var m in baby.LegMeshes)
                {
                    m.material.color = color;
                }
            }

            if (part == JellyBodyPart.Head)
            {
                throw new NotImplementedException("Cant apply color to head right now sowwwy");
            }
        }
    }
}