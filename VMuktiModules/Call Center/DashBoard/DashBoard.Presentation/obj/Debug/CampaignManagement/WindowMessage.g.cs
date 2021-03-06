﻿#pragma checksum "..\..\..\CampaignManagement\WindowMessage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "65490A5027387457B8A4C0ACE0AE7606"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DashBoard.Presentation.CampaignManagement {
    
    
    /// <summary>
    /// WindowMessage
    /// </summary>
    public partial class WindowMessage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.Grid grdPopUp;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.RowDefinition grdCampaign;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.RowDefinition grdUsers;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.RowDefinition grdTreatment;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.RowDefinition grdGroup;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TextBlock txtCampaign;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.Button btnPin;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TreeView trUsers;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TreeViewItem triUsers;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TreeView trTreatment;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TreeViewItem triTreatment;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TreeView trGroup;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\CampaignManagement\WindowMessage.xaml"
        internal System.Windows.Controls.TreeViewItem triGroup;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DashBoard.Presentation;component/campaignmanagement/windowmessage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CampaignManagement\WindowMessage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdPopUp = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.grdCampaign = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.grdUsers = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.grdTreatment = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 5:
            this.grdGroup = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 6:
            this.txtCampaign = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnPin = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\CampaignManagement\WindowMessage.xaml"
            this.btnPin.Click += new System.Windows.RoutedEventHandler(this.btnPin_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.trUsers = ((System.Windows.Controls.TreeView)(target));
            return;
            case 9:
            this.triUsers = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 10:
            this.trTreatment = ((System.Windows.Controls.TreeView)(target));
            return;
            case 11:
            this.triTreatment = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 12:
            this.trGroup = ((System.Windows.Controls.TreeView)(target));
            return;
            case 13:
            this.triGroup = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
