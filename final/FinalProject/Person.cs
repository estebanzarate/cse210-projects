public class Person
{
    private string _name;
    private string _lastName;
    private string _email;
    private DateTime _birthdayDate;
    public Person(string name, string lastName, string email, DateTime birthdayDate)
    {
        _name = name;
        _lastName = lastName;
        _email = email;
        _birthdayDate = birthdayDate;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetLastName()
    {
        return _lastName;
    }
    public void SetLastName(string lastname)
    {
        _lastName = lastname;
    }
    public string GetEmail()
    {
        return _email;
    }
    public void SetEmail(string email)
    {
        _email = email;
    }
    public string GetBirthDayDate()
    {
        string day = _birthdayDate.Day.ToString();
        string month = _birthdayDate.Month.ToString();
        return $"{day}/{month}";
    }
    public DateTime GetBirth()
    {
        return _birthdayDate;
    }
    public void SetBirthdayDate(int day, int month)
    {
        _birthdayDate = new DateTime(1, month, day);
    }
    public string GetPersonData()
    {
        return $"| {GetName()} {GetLastName()} | {GetEmail()} | {GetBirthDayDate()} |";
    }
    public string FormatToSave()
    {
        return $"{GetName()},{GetLastName()},{GetEmail()},{GetBirthDayDate()}";
    }
}