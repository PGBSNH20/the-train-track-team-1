using System;
using System.Collections.Generic;
using TrainEngine.Models;
namespace TrainEngine
{
    public interface ITrackIO
    {
        Track Track { get; set; }
        void Parse();
    }
}