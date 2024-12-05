
    using DefaultNamespace;
    using UnityEngine;

    public static class Utility
    {
        public static JellyBodyPart GetRandomBodyPart()
        {
            var r = Random.Range(0, 4);
            return (JellyBodyPart)r;
        }
        public static JellyBodyPart GetRandomBodyPartNotIncludingAll()
        {
            var r = Random.Range(1, 4);
            return (JellyBodyPart)r;
        }
        public static JellyBodyPart GetRandomArmsOrLegs()
        {
            if (Random.value > 0.5f)
            {
                return JellyBodyPart.Arms;
            }
            else
            {
                return JellyBodyPart.Legs;
            }
        }
    }
