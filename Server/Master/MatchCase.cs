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
    ///  - 큐에서 둘을 뽑아서 매칭해서 돌려준다. 
    ///  - 일정 시간 이상 대기하면 봇과 매칭한다. 
    ///  - 게임이 끝나면 다시 매칭한다. 
    /// </summary>
    public class MatchCase : Case
    {

        class Entry 
        {
            public Member member;
            public DateTime time;
        }

        class Coord
        {
            public int serverId;
            public int count;
        }

        Queue<Entry> matchQueue;
        List<Coord> coords;

        public MatchCase()
        {
            matchQueue = new Queue<Entry>();
            coords = new List<Coord>();
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
            // TODO: 사용자별 고유한 요청이 보장되어야 함

            matchQueue.Enqueue(
                new Entry
                {
                    member = req.Requester,
                    time = DateTime.Now
                }
            );

            Match();
        }

        void Match()
        {

        }
    }
}
