using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x2;
using Events;
using Events.Login;

namespace Server.Master
{
    /// <summary>
    /// Authenticate and manages User location
    /// </summary>
    public class AuthCase : Case
    {
        Dictionary<string, Shared.User> dic;

        int guid_seq; // temporal 


        public AuthCase()
        {
            dic = new Dictionary<string, Shared.User>();
        }

        protected override void Setup()
        {
            base.Setup();

            new EventMasterLoginReq().Bind(OnLoginReq);
            new EventMasterLogout().Bind(OnLogout);
        }

        void OnLoginReq(EventMasterLoginReq req)
        {
            // Skip DB processing for now

            Shared.User user;

            if ( !dic.TryGetValue(req.Account, out user) )
            {
                user = new Shared.User();
            }
            else
            {
                // 
            }

            user.Account = req.Account;

            dic[user.Account] = user;

            new EventMasterLoginResp
            {
                Account = user.Account,
                Result = 0
            }
            .Post();
        }

        void OnLogout(EventMasterLogout req)
        {
            dic.Remove(req.Account);
        }
    }
}
