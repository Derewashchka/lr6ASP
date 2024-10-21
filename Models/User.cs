public class User
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public bool IsOldEnough()
    {
        return (DateTime.Now.Year - BirthDate.Year) >= 16;
    }
}
