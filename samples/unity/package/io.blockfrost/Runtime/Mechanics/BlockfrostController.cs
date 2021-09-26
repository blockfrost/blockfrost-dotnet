using UnityEngine;
using UnityEngine.Networking;

namespace Blockfrost.Mechanics
{
    public class BlockfrostController : MonoBehaviour 
    {
        [Tooltip("Interval in seconds to look for new blocks.")]
        public int interval = 5;
        public int nextQueryTick = 0;
        
        [Tooltip("Latest block.")]
        public Block latest;

        Block GetLatest()
        {
            // UnityEngine.Networking.HttpWebRequest
            var tip = new Block();
            return tip;
        }

        void Awake()
        {
            latest = GetLatest();
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.seconds % interval == 0)
            { 
                // UnityEngine.Networking.HttpWebRequest
                var tip = GetLatest();

                if (tip.slot != latest.slot)
                {
                    latest = tip;
                    var player = UnityEngine.Object.FindObjectsOfType<PlayerInstance>();
                    var token = new TokenInstance();
                }
            }
        }
    }
}