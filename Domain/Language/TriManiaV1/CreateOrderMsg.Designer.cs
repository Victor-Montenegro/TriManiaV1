﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Language.TriManiaV1 {
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
    public class CreateOrderMsg {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CreateOrderMsg() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Language.TriManiaV1.CreateOrderMsg", typeof(CreateOrderMsg).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esse productId {0} não existe.
        /// </summary>
        public static string CreateOrder_NotSuccess_0001 {
            get {
                return ResourceManager.GetString("CreateOrder_NotSuccess_0001", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Estoque insuficiente para esse productId {0}.
        /// </summary>
        public static string CreateOrder_NotSuccess_0002 {
            get {
                return ResourceManager.GetString("CreateOrder_NotSuccess_0002", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0 pedido {0} ainda está em andamento, por favor finalizar antes de criar um novo pedido.
        /// </summary>
        public static string CreateOrder_NotSuccess_0003 {
            get {
                return ResourceManager.GetString("CreateOrder_NotSuccess_0003", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O item com o productId {0} está sendo repetido.
        /// </summary>
        public static string CreateOrder_NotSuccess_0004 {
            get {
                return ResourceManager.GetString("CreateOrder_NotSuccess_0004", resourceCulture);
            }
        }
    }
}
