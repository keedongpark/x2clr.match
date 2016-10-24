using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x2;

namespace Server.Session
{
    public class UserCase : Case
    {
        string account;
        int guid;

        public UserCase(string account, int guid)
        {
            this.account = account;
            this.guid = guid;
        }

        protected override void Setup()
        {
            base.Setup();

            // Match Request 

            // Match Response 

            // 동시 처리로 가닥을 잡음. Broadcasting 기반. 프로파일링으로 성능 개선. 
        }
    }
}
