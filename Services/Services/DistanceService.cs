using Infrastructure.Enums;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DistanceService
    {
        public Dictionary<string, List<Mentor>> ClosestDistance(List<Mentor> mentors)
        {
            Dictionary<string, List<Mentor>> closestMentors = new Dictionary<string, List<Mentor>>();

            foreach (var mentor in mentors)
            {
                if (mentor.Level == Level.Professor)
                {
                    if (!closestMentors.ContainsKey(Level.Professor.ToString()))
                    {
                        closestMentors.Add(Level.Professor.ToString(), new List<Mentor>());
                        closestMentors[Level.Professor.ToString()] = mentors
                             .Where(x => x.Level == Level.Professor).OrderBy(x => x.Distance).ToList();
                    }
                }

                else if ((!closestMentors.ContainsKey(Level.AssociateProfessor.ToString())))
                {
                    if (!closestMentors.ContainsKey(Level.AssociateProfessor.ToString()))
                    {
                        closestMentors.Add(Level.AssociateProfessor.ToString(), new List<Mentor>());
                        closestMentors[Level.AssociateProfessor.ToString()] = mentors
                            .Where(x => x.Level == Level.AssociateProfessor).OrderBy(x => x.Distance).ToList();
                    }
                }
                else if ((!closestMentors.ContainsKey(Level.Doctor.ToString())))
                {
                    if (!closestMentors.ContainsKey(Level.Doctor.ToString()))
                    {
                        closestMentors.Add(Level.Doctor.ToString(), new List<Mentor>());
                        closestMentors[Level.Doctor.ToString()] = mentors
                            .Where(x => x.Level == Level.Doctor).OrderBy(x => x.Distance).ToList();
                    }
                }
                else if ((!closestMentors.ContainsKey(Level.ScienceDoctor.ToString())))
                {
                    if (!closestMentors.ContainsKey(Level.ScienceDoctor.ToString()))
                    {
                        closestMentors.Add(Level.ScienceDoctor.ToString(), new List<Mentor>());
                        closestMentors[Level.ScienceDoctor.ToString()] = mentors
                            .Where(x => x.Level == Level.ScienceDoctor).OrderBy(x => x.Distance).ToList();
                    }
                }
            }
           return closestMentors;
        }
    }
}
