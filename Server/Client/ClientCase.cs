using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x2;

namespace Server.Client
{
    /// <summary>
    /// ClientCase to build server.
    /// </summary>
    public class ClientCase : Case
    {
        string account;
        string password;

        public bool HasLogin
        {
            get; set;
        }

        public void RequestLogin(string account, string password)
        {
            this.account = account;
            this.password = password;

            new Events.Login.EventLoginReq
            {
                Account = account,
                Password = password
            }.Post();
        }

        public void RequestLogout()
        {
            new Events.Login.EventLogout
            {
                Account = account
            }.Post();
        }


        protected override void Setup()
        {
            base.Setup();

            new Events.Login.EventLoginResp()
                .Bind(OnLoginResp);
        }

        void OnLoginResp(Events.Login.EventLoginResp resp)
        {
            if ( resp.Result == (int)Events.ErrorCodes.Success)
            {
                HasLogin = true;
            }
            else
            {
                HasLogin = false;
            }
        }
    }
}
