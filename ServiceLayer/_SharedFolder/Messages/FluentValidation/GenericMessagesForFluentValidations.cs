namespace ServiceLayer._SharedFolder.Messages.FluentValidation
{
    public static class GenericMessagesForFluentValidations
    {
        public static string EmptyNullMessage(string propName)
        {
            return $"{propName} can not be empty.";
        }

        public static string MaximumLength(string length)
        {
            return $"You are allowed to use maximum {length} character.";
        }

        public static string MaximumNumber(int number)
        {
            return $"You are allowed to use maximum {number}.";
        }

        public static string UseEmail()
        {
            return $"Please use an email.";
        }

        public static string PasswordCompare()
        {
            return $"Password and pasword confirm must be same";
        }
        public static string AcceptTerms()
        {
            return $"You have to accept Terms and Conditions";
        }
        public static string ImHumanCheck()
        {
            return $"You have to confirm you are not a Bot";
        }


    }
}
