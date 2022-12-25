namespace Magnimus
{
    [System.Serializable]
    public class registeredUser
    {
        public string id;
        public string email_id;
        public string username;
    }

    [System.Serializable]
    public class JSONRegisterOutput 
    {
        public string success;
        public string statusCode;
        public string statusMessage;
        public string message;
        public registeredUser rUser;
    }
}
