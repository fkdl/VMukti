﻿/* VMukti 1.0 -- An Open Source Unified Communications Engine
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

namespace Video.Business.Service.NetP2P
{
    public class ClsNetP2PMainVideo : INetP2PMainVideo
    {

        public delegate void delsvcJoin(string UName);
        public delegate void delsvcGetUserList(string UName, string videoURI);
        public delegate void delsvcSetUserList(string UName, string videoURI);
        public delegate void delsvcClose(string UName);
        public delegate void delsvcUnJoin(string UName);

        public event delsvcJoin EntsvcJoin;
        public event delsvcGetUserList EntsvcGetUserList;
        public event delsvcSetUserList EntsvcSetUserList;
        public event delsvcClose EntsvcClose;
        public event delsvcUnJoin EntsvcUnJoin;

        #region INetP2PMainVideo Members

        public void svcJoin(string UName)
        {
            if (EntsvcJoin != null)
            {
                EntsvcJoin(UName);
            }
        }

        public void svcGetUserList(string UName, string videoURI)
        {
            if (EntsvcGetUserList != null)
            {
                EntsvcGetUserList(UName, videoURI);
            }
        }

        public void svcSetUserList(string UName, string videoURI)
        {
            if (EntsvcSetUserList != null)
            {
                EntsvcSetUserList(UName, videoURI);
            }
        }

        public void svcClose(string UName)
        {
            if (EntsvcClose != null)
            {
                EntsvcClose(UName);
            }
        }

        public void svcUnJoin(string UName)
        {
            if (EntsvcUnJoin != null)
            {
                EntsvcUnJoin(UName);
            }
        }

        #endregion

        #region INetP2PMainVideo Members


      

        #endregion
    }
}
