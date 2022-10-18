using System.Collections.Generic;

namespace LessonPlanLogic
{
    public class TopicsAtLevel
    {
        public TopicsAtLevel(List<Topic> topics, AchievementLevels level)
        {
            Topics = topics;
            Level = level;
        }

        private List<Topic> Topics { get; }

        public AchievementLevels Level { get; }
    }
}