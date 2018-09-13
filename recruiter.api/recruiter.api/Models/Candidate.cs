using System;
using System.ComponentModel.DataAnnotations;

public class Candidate
{
    [Key]
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Salary { get; set; }
    public string Notes { get; set; }
    public bool Available { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public string FullName()
    {
        if(MiddleName != null)
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
        else
        {
            return FirstName + " " + LastName;
        }
    }
}
