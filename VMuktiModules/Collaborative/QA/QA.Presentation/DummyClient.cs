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
using System.Globalization;
using System.Reflection;

namespace QA.Presentation
{
    [Serializable]
    public class DummyClient
    {
        public string UserName;
        public int MyId;
        List<AppDomain> appDummyDomains = new List<AppDomain>();

        public static List<object> objQADummies = new List<object>();

        public void HostDummyClient(string UserName)
        {
            this.UserName = UserName;
            //this.UserName = UserName.Split('~')[0];
            //MyId = int.Parse(UserName.Split('~')[1]);
        }

        public string QAClient(int ID, string netP2pUri, string strQASNodeIp)
        {
            string httpUri = "http://" + strQASNodeIp + ":80/QA" + (objQADummies.Count + 1).ToString();
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            appDummyDomains.Add(AppDomain.CreateDomain("DummyQA" + ID.ToString(), null, setup));
            objQADummies.Add(InstantiateQA(appDummyDomains[appDummyDomains.Count - 1], new DomainBinder(), new CultureInfo("en-US"), UserName, "", ID, netP2pUri, httpUri));
            return httpUri;
        }

        public string QAClientWithoutDummy(int ID, string netP2pUri, string strQASNodeIp)
        {
            string httpUri = "http://" + strQASNodeIp + ":80/QA" + (objQADummies.Count + 1).ToString();
            objQADummies.Add(new QADummy(UserName, "", ID, netP2pUri, httpUri));
            return httpUri;
        }

        static object InstantiateQA(AppDomain appDomain, Binder binder, CultureInfo cultureInfo, string MyName, string UName, int Id, string netP2pUri, string httpUri)
        {
            try
            {

                object instance = appDomain.CreateInstance(
                   "QA.Presentation",
                   "QA.Presentation.QADummy",
                   false,
                   BindingFlags.Default,
                   binder,
                   new object[] { MyName, UName, Id, netP2pUri, httpUri },
                   cultureInfo,
                   null,
                   null
                );
                return instance;
            }
            catch (Exception exp)
            {
                return null;
            }
        }

    }
}
