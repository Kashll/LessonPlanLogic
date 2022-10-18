using System;
using System.Collections.Generic;

namespace LessonPlanLogic
{
    public class Topic
    {
        public Topic(string topic)
        {
            Name = topic;
            LifeSkills = new List<LifeSkills>();
        }

        public Topic(string topic, List<LifeSkills> lifeSkills)
        {
            Name = topic;
            LifeSkills = lifeSkills;
        }

        public string Name { get; }

        public List<LifeSkills> LifeSkills { get; }
    }
}