using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesLibrary
{
    [Serializable]
    public class EpisodeNameException : System.Exception
    {
        public string Title {  get; private set; }
        public EpisodeNameException() { }
        public EpisodeNameException(string message, string title) : base(message) { this.Title = title; }
        public EpisodeNameException(string message, string title, Exception InnerException) : base(message, InnerException) { this.Title = title; }
        protected EpisodeNameException(SerializationInfo Info, StreamingContext StreamingContext) : base(Info, StreamingContext) { }
    }
}
