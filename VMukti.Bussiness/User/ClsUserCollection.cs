/* VMukti 2.0 -- An Open Source Video Communications Suite
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
using VMukti.DataAccess;
using VMuktiAPI;
using System.Text;


namespace VMukti.Business
{
    public class UserCollection : ClsBaseCollection<ClsUser>
    {        
    
        public static UserCollection GetAll()
        {
            try
            {
                UserCollection obj = new UserCollection();

                if (bool.Parse(VMuktiAPI.VMuktiInfo.Port80) && VMuktiAPI.VMuktiInfo.CurrentPeer.CurrPeerType != PeerType.BootStrap)
                {
                    try
                    {
                        obj.MapObjects(VMukti.Business.clsDataBaseChannel.chHttpDataBaseService.svcExecuteDataSet("Select UserInfo.*,Payroll.* from UserInfo left outer join Payroll on UserInfo.Id=Payroll.UserId where UserInfo.IsDeleted=0;").dsInfo);
                    }
                    catch (System.ServiceModel.EndpointNotFoundException e)
                    {
                        VMuktiHelper.ExceptionHandler(e, "GetAll()", "ClsUserCollection.cs");
                        VMuktiAPI.VMuktiHelper.CallEvent("GetSuperNodeIP", null, null);
                        obj.MapObjects(VMukti.Business.clsDataBaseChannel.chHttpDataBaseService.svcExecuteDataSet("Select UserInfo.*,Payroll.* from UserInfo left outer join Payroll on UserInfo.Id=Payroll.UserId where UserInfo.IsDeleted=0;").dsInfo);
                    }
                    catch (System.ServiceModel.CommunicationException e)
                    {
                        VMuktiHelper.ExceptionHandler(e, "GetAll()", "ClsUserCollection.cs");
                        VMuktiAPI.VMuktiHelper.CallEvent("GetSuperNodeIP", null, null);
                        obj.MapObjects(VMukti.Business.clsDataBaseChannel.chHttpDataBaseService.svcExecuteDataSet("Select UserInfo.*,Payroll.* from UserInfo left outer join Payroll on UserInfo.Id=Payroll.UserId where UserInfo.IsDeleted=0;").dsInfo);
                    }
                }
                else
                {
                if (VMuktiAPI.VMuktiInfo.CurrentPeer.CurrPeerType == VMuktiAPI.PeerType.NodeWithHttp)
                {
                    try
                    {
                        obj.MapObjects(VMukti.Business.clsDataBaseChannel.chHttpDataBaseService.svcExecuteDataSet("Select UserInfo.*,Payroll.* from UserInfo left outer join Payroll on UserInfo.Id=Payroll.UserId where UserInfo.IsDeleted=0;").dsInfo);
                    }
                    catch (System.ServiceModel.EndpointNotFoundException e)
                    {
                        VMuktiHelper.ExceptionHandler(e, "GetAll()", "ClsUserCollection.cs");
                        VMuktiAPI.VMuktiHelper.CallEvent("GetSuperNodeIP", null, null);
                        obj.MapObjects(VMukti.Business.clsDataBaseChannel.chHttpDataBaseService.svcExecuteDataSet("Select UserInfo.*,Payroll.* from UserInfo left outer join Payroll on UserInfo.Id=Payroll.UserId where UserInfo.IsDeleted=0;").dsInfo);
                    }
                    catch (System.ServiceModel.CommunicationException e)
                    {
                        VMuktiHelper.ExceptionHandler(e, "GetAll()", "ClsUserCollection.cs");
                        VMuktiAPI.VMuktiHelper.CallEvent("GetSuperNodeIP", null, null);
                        obj.MapObjects(VMukti.Business.clsDataBaseChannel.chHttpDataBaseService.svcExecuteDataSet("Select UserInfo.*,Payroll.* from UserInfo left outer join Payroll on UserInfo.Id=Payroll.UserId where UserInfo.IsDeleted=0;").dsInfo);
                    }  
                    
                }
                else
                {                    
                    obj.MapObjects(new ClsUserDataService().User_GetAll());                    
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "GetAll()", "ClsUserCollection.cs");              
                return null;
            }
        }

    }
}
