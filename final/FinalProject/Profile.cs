public class Profile
{
    private string _email;
    private string _smtpClient;
    private string _password;
    public Profile(string email, string smtpClient, string password)
    {
        _email = email;
        _smtpClient = smtpClient;
        _password = password;
    }
    public string GetEmail()
    {
        return _email;
    }
    public void SetEmail(string email)
    {
        _email = email;
    }
    public string GetSmtpClient()
    {
        return _smtpClient;
    }
    public void SetSmtpClient(string smtpClient)
    {
        _smtpClient = smtpClient;
    }
    public string GetPassword()
    {
        return _password;
    }
    public void SetPassword(string password)
    {
        _password = password;
    }
    public string FormatToSave()
    {
        return $"{GetEmail()},{GetSmtpClient()},{GetPassword()}";
    }
    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter("profile.txt"))
        {
            writer.WriteLine(FormatToSave());
        }
    }
}