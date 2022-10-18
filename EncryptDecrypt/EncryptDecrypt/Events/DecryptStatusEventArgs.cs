namespace EncryptDecrypt.Events
{
    public class DecryptStatusEventArgs
    {
        public string Message;

        public DecryptStatusEventArgs(string message)
        {
            Message = message;
        }
    }
}
