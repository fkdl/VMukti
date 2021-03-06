/* VMukti 1.0 -- An Open Source Unified Communications Engine
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
using System.Text;
using RTCCORELib;
using VMuktiAPI;
using ToneDetect.Business.Detect;
using ToneDetect.Business.SIP;

namespace AutoProgressivePhone.Business
{
    public class RTCClient
    {
        private string _SIPNUMBER = "", _SIPPASSWORD = "", _SIPSERVER = "";
		  private List<RTCAudioWithToneDetect> _Channels = new List<RTCAudioWithToneDetect>();

        public delegate void delStatus(int ChannelId, string status);
        public event delStatus entstatus = null;

		  #region Properties
        public string SIPNumber
        {
            get
            { return _SIPNUMBER; }
            set
            { _SIPNUMBER = value; }
        }

        public string SIPPassword
        {
            get
            { return _SIPPASSWORD; }
            set
            { _SIPPASSWORD = value; }
        }

        public string SIPServer
        {
            get
            { return _SIPSERVER; }
            set
            { _SIPSERVER = value; }
        }
		  #endregion

		  #region Events/Delegates
		  public delegate void NonHumanDetectedDelegate( object sender, int channel, string tone );
		  public event NonHumanDetectedDelegate NonHumanDetected;
		  #endregion

        public RTCClient(string SIPNumber, string SIPPassword, string SIPServer)
        {
			  string ipAddress;
            try
            {
					ipAddress = VMuktiAPI.VMuktiInfo.CurrentPeer.CurrentMachineIP;
					//ipAddress = "192.168.1.103";
					SniffSIP.Instance.IPAddress = ipAddress;
					SniffSIP.Instance.Initialize();

                _SIPNUMBER = SIPNumber;
                _SIPPASSWORD = SIPPassword;
                _SIPSERVER = SIPServer;
                _Channels.Add(new RTCAudioWithToneDetect(_SIPNUMBER, _SIPPASSWORD, _SIPSERVER, true));
                _Channels[_Channels.Count - 1].ChannelId = _Channels.Count;
                _Channels[_Channels.Count - 1].entstatus += new RTCAudio.delStatus(RTCClient_entstatus);
					 _Channels[_Channels.Count - 1].NonHumanDetected += OnNonHumanDetected;
					 try
					 {
						 //note for the time being, we are not explicitly stopping the sniffing process.
						 SniffSIP.Instance.StartSniffing();
					 }
					 catch( Exception ex )
					 {
						 ex.Data.Add( "My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--RTCClient_entstatus()--" );
						 ClsException.WriteToErrorLogFile( ex );
					 }

                for (int i = 0; i < 5; i++)
                {
                    _Channels.Add(new RTCAudioWithToneDetect( _SIPNUMBER, _SIPPASSWORD, _SIPSERVER, true ));
                    _Channels[_Channels.Count - 1].ChannelId = _Channels.Count;
                    _Channels[_Channels.Count - 1].entstatus += new RTCAudio.delStatus(RTCClient_entstatus);
						  _Channels[_Channels.Count - 1].NonHumanDetected += OnNonHumanDetected;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--RTCClient_entstatus()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
        }

		  #region Event Handlers
		  private void OnNonHumanDetected( object sender, ToneDetected tone )
		  {
			  RTCAudioWithToneDetect rtcAudioWithSip;
			  if( sender is RTCAudioWithToneDetect )
			  {
				  rtcAudioWithSip = (RTCAudioWithToneDetect)sender;

				  // if the delegate is hooked, raise the event.
				  if( this.NonHumanDetected != null )
				  {
					  NonHumanDetected( this, rtcAudioWithSip.ChannelId ,tone.ToString());
				  }
			  }
			  else
			  {
				  throw new ArgumentException( "Object is not a RTCAudioWithSIP." );
            }
        }

        void RTCClient_entstatus(RTCAudio sender, string status)
        {
            try
            {
                switch (status)
                {
                    case "InPorgress":
                        entstatus(sender.ChannelId, status);
                        break;

                    case "Connected":
                        entstatus(sender.ChannelId, status);
                        break;

                    case "Disconnected":
                        entstatus(sender.ChannelId, status);
                        break;

                    case "Incoming":
                        entstatus(sender.ChannelId, status);
                        break;

                    case "Answering":
                        entstatus(sender.ChannelId, status);
                        break;

                    case "Hold":
                        entstatus(sender.ChannelId, status);
                        break;

                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--RTCClient_entstatus()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
		  }
		  #endregion

		  public void StopSniffing()
		  {
			  SniffSIP.Instance.StopSniffing();
        }

        public void Dial(string PhoneNumber, int Channel)
        {
            try { _Channels[Channel - 1].Connect(PhoneNumber); }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "Dial()", "AutoDialer.RTCClient.cs");
            }
        }

        public void HangUp(int Channel)
        {
            try { _Channels[Channel - 1].DisConnect(); }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--HangUp()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
        }

        public void Hold(int Channel,string status)
        {
            try { _Channels[Channel - 1].fncHold(status); }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--Hold()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
        }

        public void Transfer(string number, int Channel)
        {
            try { _Channels[Channel - 1].fncTransfer(number); }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--Transfer()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
        }

        public void Anser()
        {
            try { _Channels[0].fncAnser(); }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Call Center--:--AutoProgressiveSoftPhone--:--AutoProgressivePhone.Business--:--RTCClient.cs--:--Anser()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
        }

        public void SendDTMF(string number, int Channel)
        {
            try
            {
                _Channels[Channel - 1].fncSendDTMF(number);
            }
            catch (Exception ex)
            {
                ex.Data.Add("My Key", "VMukti--:--VmuktiModules--:--Common--:--Audio--:--Audio.Business--:--RTCClient.cs--:--SendDTMF()--");
                ClsException.LogError(ex);
                ClsException.WriteToErrorLogFile(ex);
            }
        }
    }
}
