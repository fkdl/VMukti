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
using System.Linq;
using System.Text;
using PlayFile.Common;
using System.Data;

namespace PlayFile.Business
{
    public class ClsClientDetail : ClsBaseObject
    {
        #region Fields

        
        long _LeadID = ClsConstants.NullLong;
        long _LeadFieldID = ClsConstants.NullLong;
        string _PropertyValue = ClsConstants.NullString;
       

        #endregion

        #region Properties

       
        public long LeadID { get { return _LeadID; } set { _LeadID = value; } }
        public long LeadFieldID { get { return _LeadFieldID; } set { _LeadFieldID = value; } }
        public string PropertyValue {get { return _PropertyValue; } set { _PropertyValue=value; } }
 
        #endregion

        public override bool MapData(DataRow row)
        {
            try
            {
               
                //LeadID = GetLong(row, "LeadID");
                //LeadFieldID = GetLong(row, "LeadFieldID");
                PropertyValue = GetString(row, "PropertyValue");
               
                return base.MapData(row);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
