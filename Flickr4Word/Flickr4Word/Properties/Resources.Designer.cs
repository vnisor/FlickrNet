﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.312
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flickr4Word.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Flickr4Word.Properties.Resources", typeof(Resources).Assembly);
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
        
        internal static System.Drawing.Bitmap blueArrowLeft16 {
            get {
                object obj = ResourceManager.GetObject("blueArrowLeft16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap blueArrowRight16 {
            get {
                object obj = ResourceManager.GetObject("blueArrowRight16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap flickr_gamma {
            get {
                object obj = ResourceManager.GetObject("flickr_gamma", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;customUI xmlns=&quot;http://schemas.microsoft.com/office/2006/01/customui&quot; onLoad=&quot;OnLoad&quot;&gt;
        ///  &lt;ribbon&gt;
        ///    &lt;tabs&gt;
        ///      &lt;tab idMso=&quot;TabInsert&quot;&gt;
        ///        &lt;group id=&quot;GroupInsertFlickr&quot; label=&quot;Web&quot; insertBeforeMso=&quot;GroupInsertIllustrations&quot;&gt;
        ///          &lt;button id=&quot;flickrButton&quot;
        ///                  size=&quot;large&quot;
        ///                  label=&quot;Flickr Image&quot; 
        ///                  screentip=&quot;Insert an image from the Flickr(tm) service.&quot; 
        ///                  onAction=&quot;OnFlickrInsert&quot; 
        ///                  getImage=&quot;GetImage&quot; in [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Flickr4WordRibbonUI {
            get {
                return ResourceManager.GetString("Flickr4WordRibbonUI", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 508d9937f15bde97e91b45730dc38366.
        /// </summary>
        internal static string FlickrApiKey {
            get {
                return ResourceManager.GetString("FlickrApiKey", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap FlickrIcon {
            get {
                object obj = ResourceManager.GetObject("FlickrIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Info {
            get {
                object obj = ResourceManager.GetObject("Info", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap search16 {
            get {
                object obj = ResourceManager.GetObject("search16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
