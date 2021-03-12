using System;
using System.Collections.Generic;
namespace TrainEngine
{
    public interface ITrackIO
    {
        TrackIO._Track Track { get; set; }
      
        void Parse();
    }
}