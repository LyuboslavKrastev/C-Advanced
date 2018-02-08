using System.Collections.Generic;
public class Room
{
    public int Number { get; set; }
    public HashSet<string> Patients { get; set; } = new HashSet<string>();
    public int EmtpyBeds { get; set; } = 3;
}