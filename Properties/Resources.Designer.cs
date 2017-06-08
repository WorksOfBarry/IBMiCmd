﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBMiCmd.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IBMiCmd.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to ctl-opt main(main) datfmt(*iso) 
        ///		datedit(*ymd-) 
        ///		timfmt(*iso) 
        ///		decedit(&apos;0,&apos;) 
        ///        alwnull(*usrctl) 
        ///		bnddir(&apos;QC2LE&apos;)                           
        ///        option(*srcstmt : *nodebugio :*noshowcpy : *nounref : *noexpdds)              
        ///        debug(*yes) 
        ///		langid(*jobrun) 
        ///        ccsid(*ucs2 : 13488)                                   
        ///		DftActGrp(*No) ActGrp(NPP);                               .
        /// </summary>
        internal static string CTLOPTCPY {
            get {
                return ResourceManager.GetString("CTLOPTCPY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PGM          PARM(&amp;FILE) 
        ///DCL          VAR(&amp;FILE) TYPE(*CHAR) LEN(10)
        ///DCL          VAR(&amp;USER) TYPE(*CHAR) LEN(10)
        ///             RTVJOBA    CURUSER(&amp;USER)
        ///             DLTF       FILE(QTEMP/&amp;FILE)
        ///             MONMSG     MSGID(CPF2105)
        ///             CRTPF      FILE(QTEMP/&amp;FILE) RCDLEN(1730) +
        ///                          FILETYPE(*SRC) CCSID(*JOB) 
        ///             DSPFFD     FILE(*LIBL/&amp;FILE) OUTPUT(*OUTFILE) +
        ///                          OUTFILE(QTEMP/TMP)
        ///             CPYF       FROMFILE(QTEMP/TMP) TOFILE( [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DSPFFDCLP {
            get {
                return ResourceManager.GetString("DSPFFDCLP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to             CMD        ALLOW(*ALL)
        ///FILE:       PARM       KWD(FILE) TYPE(*CHAR) LEN(10).
        /// </summary>
        internal static string DSPFFDCMD {
            get {
                return ResourceManager.GetString("DSPFFDCMD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to             CMD        ALLOW(*ALL)
        ///CMD:        PARM       KWD(CMD) TYPE(*CHAR) LEN(20).
        /// </summary>
        internal static string RTVCMDCMD {
            get {
                return ResourceManager.GetString("RTVCMDCMD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to **FREE
        ////include QRPGLESRC.NPPCTLOPT
        ///// Part of the IBMiCmd server features
        /////
        ///// Put command definition in the users IFS Folder in a file named as command.cdml
        /////
        ///// Uses system API https://www.ibm.com/support/knowledgecenter/ssw_ibm_i_73/apis/qcdrcmdd.htm
        /////
        ///
        ///dcl-ds myPSDS psds;
        ///    
        ///end-ds
        ///
        ///dcl-proc main;
        ///    dcl-pi *N;      
        ///        command char(20);
        ///    end-pi;
        ///    
        ///    dcl-ds RetreiveCDML_DestinationFormat qualified;
        ///        BytesReturned  int(10);
        ///        BytesAvailable int(10);
        ///  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RTVCMDRPG {
            get {
                return ResourceManager.GetString("RTVCMDRPG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap star {
            get {
                object obj = ResourceManager.GetObject("star", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap star_bmp {
            get {
                object obj = ResourceManager.GetObject("star_bmp", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
