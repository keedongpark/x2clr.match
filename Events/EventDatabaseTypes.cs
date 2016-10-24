using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Database
{
    /// <summary>
    /// 5001 ~ 6000
    /// </summary>
    public enum EventDatabaseTypes
    {
        Base = 5001, 
        CreateOrLoadUserReq, 
        LoadUserReq, 
        LoadUserResp, 
        UpdateUserReq, 
        UpdateUserResp, 
        End
    }

    /// <summary>
    /// Context to bind each database request
    /// </summary>
    public enum EventDatabaseContext
    {
        Auth = 1, 
        Instance, 
    }
}
