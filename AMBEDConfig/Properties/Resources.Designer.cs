﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMBEDConfig.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AMBEDConfig.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (Config Software Version {0}).
        /// </summary>
        internal static string label_version {
            get {
                return ResourceManager.GetString("label_version", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copyright © 2018 by XRF Reflector Club, Japan
        ///
        ///JR1OFP, JA1COU, JA4CXX, JH1TWX, JA3IYX,
        ///JA4DQX, JA4CFO, NW6UP (Random order).
        /// </summary>
        internal static string text_aboutUs {
            get {
                return ResourceManager.GetString("text_aboutUs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Port number for AMBEd (default: 2465).
        /// </summary>
        internal static string tip_ambePort {
            get {
                return ResourceManager.GetString("tip_ambePort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter country code for WiFi\nDouble click the field to set Windows default.
        /// </summary>
        internal static string tip_countryCode {
            get {
                return ResourceManager.GetString("tip_countryCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Static IP address for this box (WiFi).
        /// </summary>
        internal static string tip_ipAddr1_1 {
            get {
                return ResourceManager.GetString("tip_ipAddr1_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Subnet mask (default: 24 bit).
        /// </summary>
        internal static string tip_ipAddr1_5 {
            get {
                return ResourceManager.GetString("tip_ipAddr1_5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Router&apos;s IP address (WiFi).
        /// </summary>
        internal static string tip_ipAddr2_1 {
            get {
                return ResourceManager.GetString("tip_ipAddr2_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Static IP address for this box (USB LAN).
        /// </summary>
        internal static string tip_ipAddr3_1 {
            get {
                return ResourceManager.GetString("tip_ipAddr3_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Subnet mask (default: 24 bit).
        /// </summary>
        internal static string tip_ipAddr3_5 {
            get {
                return ResourceManager.GetString("tip_ipAddr3_5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Router&apos;s IP address (USB LAN).
        /// </summary>
        internal static string tip_ipAddr4_1 {
            get {
                return ResourceManager.GetString("tip_ipAddr4_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password (key phrase) for WiFi.
        /// </summary>
        internal static string tip_keyPhrase {
            get {
                return ResourceManager.GetString("tip_keyPhrase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Port number for SSHd (default: 20022).
        /// </summary>
        internal static string tip_sshPort {
            get {
                return ResourceManager.GetString("tip_sshPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SSID for WiFi.
        /// </summary>
        internal static string tip_ssid {
            get {
                return ResourceManager.GetString("tip_ssid", resourceCulture);
            }
        }
    }
}
