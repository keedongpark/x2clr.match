using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x2;
using Events.Instance;

namespace Server.Master
{
    /// <summary>
    /// Manages instance and matching. Join and leave from instance.
    /// 
    /// Matching Rule: 
    ///  
    /// </summary>
    public class MatchCase : Case
    {

        class MatchingEntry
        {
            public class Member
            {
                public string Account;
                public bool Waiting;
            }

            public List<Member> Members = new List<Member>();
            public Events.InstanceStatus Status;
        }

        Queue<MatchingEntry> matchQueue;

        public MatchCase()
        {
            matchQueue = new Queue<MatchingEntry>();
        }

        public int Zone { get; private set; }

        public MatchCase(int zone)
        {
            Zone = zone; 
        }

        protected override void Setup()
        {
            base.Setup();

            new EventMatchReq { Zone = this.Zone }.Bind(OnMatchReq); 
        }

        void OnMatchReq(EventMatchReq req)
        {
            if ( matchQueue.Count > 0)
            {
                // Push a human player to the instance replacing the bot when a game restarts.

            }
            else
            {
                // Create a new instance with a bot player

                // Push the instance into the matchQueue
            }
        }
    }
}
