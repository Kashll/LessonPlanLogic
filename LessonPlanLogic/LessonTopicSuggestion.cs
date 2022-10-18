using System;
using System.Collections.Generic;

namespace LessonPlanLogic
{
    public class LessonTopicSuggestion
    {
        private readonly List<Topic> m_suggestedTopics;

        public LessonTopicSuggestion()
        {
            m_suggestedTopics = new List<Topic>();
        }

        public IReadOnlyCollection<Topic> SuggestedTopics => m_suggestedTopics;

        public void AddSuggestionToFront(Topic topic)
        {
            m_suggestedTopics.Insert(0, topic);
        }

        public void PrintSuggestions()
        {
            foreach (Topic suggestedTopic in m_suggestedTopics)
            {
                Console.WriteLine($"Suggested Topic: {suggestedTopic.Name}");
            }
        }
    }
}