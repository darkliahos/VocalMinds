﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VMTests.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VMTests.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to {&quot;Creation&quot;:&quot;2014-12-27T00:00:00&quot;,&quot;LastModified&quot;:&quot;2014-12-27T00:00:00&quot;,&quot;FaceRecognitionScenarios&quot;:[{&quot;QuestionTitle&quot;:&quot;Angry Face&quot;,&quot;Id&quot;:&quot;4bfad142-c027-495d-8f37-582471b03c70&quot;,&quot;ImageName&quot;:&quot;angryface.png&quot;,&quot;Answers&quot;:[&quot;Angry&quot;,&quot;Disgusted&quot;],&quot;CopyrightDisclaimer&quot;:&quot;2014 Voldermort Creations&quot;,&quot;Author&quot;:&quot;Lord Voldermort&quot;}]}.
        /// </summary>
        internal static string FaceRecoJsonTest {
            get {
                return ResourceManager.GetString("FaceRecoJsonTest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;Creation&quot;:&quot;2014-04-20T00:00:00&quot;,&quot;LastModified&quot;:&quot;2014-05-20T00:00:00&quot;,&quot;LastWrittenProcessId&quot;:0,&quot;IsCurrentlyLocked&quot;:false,&quot;SocialScenario&quot;:[{&quot;Id&quot;:&quot;d8f18d79-0c48-43cf-8b78-c456f5e8b010&quot;,&quot;FriendlyName&quot;:&quot;Day in Bedrock&quot;,&quot;VideoSegment&quot;:[{&quot;Description&quot;:null,&quot;PlayOrder&quot;:1,&quot;VideoPath&quot;:null,&quot;Responses&quot;:[{&quot;Answer&quot;:&quot;Morning&quot;,&quot;ResponseType&quot;:0,&quot;SocialSimulatorAction&quot;:0},{&quot;Answer&quot;:&quot;Go Away&quot;,&quot;ResponseType&quot;:1,&quot;SocialSimulatorAction&quot;:0}]}],&quot;Imported&quot;:&quot;2011-04-03T00:00:00&quot;,&quot;Author&quot;:&quot;Fred Flintstone&quot;}]}.
        /// </summary>
        internal static string SocialScenarioRecoJsonTest {
            get {
                return ResourceManager.GetString("SocialScenarioRecoJsonTest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;Creation&quot;:&quot;2015-01-09T00:00:00&quot;,&quot;LastModified&quot;:&quot;2015-01-09T00:00:00&quot;,&quot;LastWrittenProcessId&quot;:0,&quot;IsCurrentlyLocked&quot;:false,&quot;VoiceRecognitionScenarios&quot;:[{&quot;Id&quot;:&quot;20cc7f02-970e-4684-a143-112d75c39238&quot;,&quot;QuestionTitle&quot;:&quot;Hey Hey&quot;,&quot;AudioPath&quot;:&quot;C:\\Audio\\VRS\\&quot;,&quot;Answers&quot;:[&quot;Happy&quot;,&quot;Eccstatic&quot;],&quot;Author&quot;:&quot;Dave The Clown&quot;,&quot;CopyrightDisclaimer&quot;:&quot;2009 Micheal Jackson&quot;,&quot;LastModified&quot;:&quot;0001-01-01T00:00:00&quot;}]}.
        /// </summary>
        internal static string VoiceRecoTest {
            get {
                return ResourceManager.GetString("VoiceRecoTest", resourceCulture);
            }
        }
    }
}
