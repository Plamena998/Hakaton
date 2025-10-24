using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDistanceService
    {
        public Dictionary<string, List<Mentor>> ClosestDistance(List<Mentor> mentors);
    }
}
