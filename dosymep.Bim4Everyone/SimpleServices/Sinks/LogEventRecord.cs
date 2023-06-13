using System;

namespace dosymep.Bim4Everyone.SimpleServices.Sinks {
    /// <summary>
    /// Log event record class.
    /// </summary>
    internal class LogEventRecord {
        /// <summary>
        /// The time at which the event occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// The message template describing the event.
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// The render message describing the event.
        /// </summary>
        public string RenderedMessage { get; set; }

        /// <summary>
        /// An exception associated with the event, or null.
        /// </summary>
        public object Exception { get; set; }

        /// <summary>
        /// Revit Session Id (unique revit start instance)
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Revit plugin name.
        /// </summary>
        public string PluginName { get; set; }

        /// <summary>
        /// Revit Plugin Session Id  (unique revit plugin start instance)
        /// </summary>
        public Guid PluginSessionId { get; set; }

        /// <summary>
        /// Environment UserName
        /// </summary>
        public string EnvironmentUserName { get; set; }

        /// <summary>
        /// Environment MachineName
        /// </summary>
        public string EnvironmentMachineName { get; set; }

        /// <summary>
        /// Revit <a href="https://www.revitapidocs.com/2017.1/04ef312a-e25a-cbcd-40c4-43fe6311e677.htm">VersionBuild</a> property.
        /// </summary>
        public string RevitBuild { get; set; }

        /// <summary>
        /// Revit <a href="https://www.revitapidocs.com/2017.1/320391bf-2c21-98ca-192c-da1d9becff11.htm">VersionNumber</a> property.
        /// </summary>
        public int RevitVersion { get; set; }

        /// <summary>
        /// Revit <a href="https://www.revitapidocs.com/2017.1/2b1d8b80-a11c-2a57-63bd-6c0d67691879.htm">Language</a> property.
        /// </summary>
        public string RevitLanguage { get; set; }

        /// <summary>
        /// Revit <a href="https://www.revitapidocs.com/2017.1/2a7c8664-de0d-7a43-e670-2e733e579609.htm">Username</a> property.
        /// </summary>
        public string RevitUserName { get; set; }

        /// <summary>
        /// Revit <a href="https://www.revitapidocs.com/2017.1/4cee7916-d799-fc83-daf3-97cb03900b72.htm">Document.Title</a> property.
        /// </summary>
        public string RevitDocumentTitle { get; set; }

        /// <summary>
        /// Revit <a href="https://www.revitapidocs.com/2022/8a92a6fd-ce25-cd86-2068-f9dcb24d72d6.htm">Document.PathName</a> property.
        /// </summary>
        public string RevitDocumentPathName { get; set; }

        /// <summary>
        /// Revit ModelPath property.
        /// <br/>If <a href="https://www.revitapidocs.com/2020/e12f7980-ba6c-2e72-6687-f0bf807ff014.htm">Document.IsModelInCloud</a> is true <a href="https://www.revitapidocs.com/2020/087a7c14-1a6e-7022-c47b-923e90f4c5be.htm">Document.GetCloudModelPath()</a>.
        /// <br/>If <a href="https://www.revitapidocs.com/2017.1/7f368167-6543-9be9-67a3-c6e1696ae060.htm">Document.IsWorkshared</a> is true <a href="https://www.revitapidocs.com/2017.1/6d42ee05-5738-8685-2165-57f9809f3161.htm">Document.GetWorksharingCentralModelPath()</a>.
        /// </summary>
        public string RevitDocumentModelPath { get; set; }

        /// <summary>
        /// Dynamic properties data.
        /// </summary>
        public object LogEvent { get; set; }
    }
}