﻿/* VMukti 2.0 -- An Open Source Video Communications Suite
*
* Copyright (C) 2008 - 2009, VMukti Solutions Pvt. Ltd.
*
* Hardik Sanghvi <hardik@vmukti.com>
*
* See http://www.vmukti.com for more information about
* the VMukti project. Please do not directly contact
* any of the maintainers of this project for assistance;
* the project provides a web site, forums and mailing lists      
* for your use.

* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.

* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.

* You should have received a copy of the GNU General Public License
* along with this program. If not, see <http://www.gnu.org/licenses/>
 
*/

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace VMukti.Bussiness.WCFServices.BootStrapServices.NetP2P
{
    public class NetP2PBootStrapPredictiveDelegate:INetP2PBootStrapPreditiveService
    {
        public delegate void DelsvcJoin(string UserNumber, string CampaignID);
        public delegate void DelsvcAddExtraCall(string SenderUserNumber, string CampaignID, string PhoneNumber);
        public delegate void DelsvcRequestExtraCall(string SenderUserNumber, string CampaignID, string CallRequestedUserNumber);
        public delegate void DelsvcSendExtraCall(string SenderUserNumber, string CampaignID, string PhoneNumber, string CallRequesedUserNumber, string LeadID, string ConfNumber);
        public delegate void DelsvcRemoveExtraCall(string SenderUserNumber, string CampaignID, string PhoneNumber);
        public delegate void DelsvcRequestFunctionToExecute(string FunctionType, string To, string From);
        public delegate void DelsvcReplyFunctionExecuted(string FunctionType, string To, string From, string ConfNumber);
        public delegate void DelsvcHangUpCall(string AgentNumber);
        public delegate void DelsvcUnJoin();

        public event DelsvcJoin EntsvcJoin;
        public event DelsvcAddExtraCall EntAddExtraCall;
        public event DelsvcRequestExtraCall EntRequestExtraCall;
        public event DelsvcSendExtraCall EntSendExtraCall;
        public event DelsvcRemoveExtraCall EntRemoveExtraCall;
        public event DelsvcRequestFunctionToExecute EntRequestFunctionToExecute;
        public event DelsvcReplyFunctionExecuted EntReplyFunctionExecuted;
        public event DelsvcHangUpCall EntHangUpCall;
        public event DelsvcUnJoin EntUnJoin;

        public void svcJoin(string UserNumber, string CampaignID)
        {
            if (UserNumber != "Server")
            {
                EntsvcJoin(UserNumber, CampaignID);
            }
        }

        public void svcAddExtraCall(string SenderUserNumber, string CampaignID, string PhoneNumber)
        { EntAddExtraCall(SenderUserNumber, CampaignID, PhoneNumber); }

        public void svcRequestExtraCall(string SenderUserNumber, string CampaignID, string CallRequestedUserNumber)
        { EntRequestExtraCall(SenderUserNumber, CampaignID, CallRequestedUserNumber); }

        public void svcSendExtraCall(string SenderUserNumber, string CampaignID, string PhoneNumber, string CallRequesedUserNumber, string LeadID, string ConfNumber)
        { EntSendExtraCall(SenderUserNumber, CampaignID, PhoneNumber, CallRequesedUserNumber, LeadID, ConfNumber); }

        public void svcRemoveExtraCall(string SenderUserNumber, string CampaignID, string PhoneNumber)
        { EntRemoveExtraCall(SenderUserNumber, CampaignID, PhoneNumber); }

        public void svcRequestFunctionToExecute(string FunctionType, string To, string From)
        {
            if (EntRequestFunctionToExecute != null)
            {
                EntRequestFunctionToExecute(FunctionType, To, From);
            }
        }

        public void svcReplyFunctionExecuted(string FunctionType, string To, string From, string ConfNumber)
        {
            if (EntReplyFunctionExecuted != null)
            {
                EntReplyFunctionExecuted(FunctionType, To, From, ConfNumber);
            }

        }
        public void svcHangUpCall(string AgentNumber)
        {
            if (EntHangUpCall != null)
            {
                EntHangUpCall(AgentNumber);
            }
        }
        public void svcUnJoin()
        { EntUnJoin(); }
    }
}
