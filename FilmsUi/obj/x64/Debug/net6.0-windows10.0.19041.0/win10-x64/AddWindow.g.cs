﻿#pragma checksum "D:\school\FilmsApi\FilmsUi\AddWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDC6C339A56F7F0EF60BCD41A762F86D23E23351351E6F6F3679AF94378DA718"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilmsUi
{
    partial class AddWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // AddWindow.xaml line 63
                {
                    this.AddButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.AddButton).Click += this.AddButton_Click;
                }
                break;
            case 3: // AddWindow.xaml line 60
                {
                    this.dpReleaseDate = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DatePicker>(target);
                }
                break;
            case 4: // AddWindow.xaml line 47
                {
                    this.lbGenres = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListBox>(target);
                }
                break;
            case 7: // AddWindow.xaml line 36
                {
                    this.cmbRating = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            case 8: // AddWindow.xaml line 31
                {
                    this.txtPlatform = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 9: // AddWindow.xaml line 26
                {
                    this.txtTitle = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 10: // AddWindow.xaml line 18
                {
                    this.cmbType = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

