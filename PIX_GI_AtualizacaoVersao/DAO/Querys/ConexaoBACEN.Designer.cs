﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIX_GI_AtualizacaoVersao.DAO.Querys {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ConexaoBACEN {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ConexaoBACEN() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PIX_GI_AtualizacaoVersao.DAO.Querys.ConexaoBACEN", typeof(ConexaoBACEN).Assembly);
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
        ///   Looks up a localized string similar to Select
        ///    b.DATA_HORA_REGISTRO,
        ///    Cast(  SUBSTRING(
        ///            substring(CONVERT(VARCHAR(MAX), DECOMPRESS(MENSAGEM)),2295,255), 
        ///            CHARINDEX(&apos;&lt;CreDtTm&gt;&apos;, substring(CONVERT(VARCHAR(MAX), DECOMPRESS(MENSAGEM)),2295,255))+9, 
        ///            24) as DateTime) as DATA_HORA_BACEN
        ///    From AB_PAGAMENTO_INSTANTANEO..MENSAGEM_BACEN_PSP_MENSAGEM  a
        ///    Inner Join AB_PAGAMENTO_INSTANTANEO..ANOTACAO_CREDITO b
        ///        On a.ID = b.ID_BACEN_PSP
        ///    WHERE  b.DATA_HORA_REGISTRO BetWeen @datInicio and  @da [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SelectSaudeConexaoBACEN {
            get {
                return ResourceManager.GetString("SelectSaudeConexaoBACEN", resourceCulture);
            }
        }
    }
}
