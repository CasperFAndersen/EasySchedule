namespace BusinessLogic
{
    /// <summary>
    /// This class is for input checks regarding user inputs from the UI.
    /// </summary>
    public class InputValidator
    {
        public string PhoneCheck
        {
            get { return "^[0-9]{8,20}$"; }
        }

        public string EmailCheck
        {
            get { return "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}$"; }
        }

        public string NameCheck
        {
            get { return "^[a-zA-Z]+( [a-zA-Z]+)+"; }
        }

        public string UsernameCheck
        {
            get { return "^[0-9a-zA-Z]{3,}"; }
        }

        public string PasswordCheck
        {
            get { return "^[0-9a-zA-Z]{6,30}"; }
        }
    }
}
