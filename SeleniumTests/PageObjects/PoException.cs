using System;

namespace SeleniumTests.PageObjects
{
    public class NotTheRightPageException : Exception
    {
        public NotTheRightPageException()
        {
        }

        public NotTheRightPageException(string message)
            : base(message)
        {
        }

        public NotTheRightPageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
