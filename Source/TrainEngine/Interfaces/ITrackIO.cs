using System;
using System.Collections.Generic;
using TrainEngine.Models;
namespace TrainEngine.Interfaces
{
    public interface ITrackIO
    {
        Track Track { get; set; }
        void Parse(bool testing = false);
    }
}