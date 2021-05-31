using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesFolder
{
    public class Feedback
    {
        private string _feedbackText;
        public string FeedbackText => _feedbackText;

        public Feedback(string feedbackText)
        {
            _feedbackText = feedbackText;
        }
    }
}
