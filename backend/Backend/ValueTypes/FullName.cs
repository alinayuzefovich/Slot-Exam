using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueTypes;

public class FullName
{
    public string Name { get; }
    public string Surname { get; }

    public FullName(string name, string surname)
    {
        if (string.IsNullOrEmpty(name)) 
            throw new ArgumentNullException("Имя не может быть пустым");

        if (name.Length > 50)
            throw new ArgumentException("Имя не может быть больше 50 символов");

        if (string.IsNullOrEmpty(surname))
            throw new ArgumentNullException("Фамилия не может быть пустой");

        if (surname.Length > 50)
            throw new ArgumentException("Фамилия не может быть больше 50 символов");

        Name = name;
        Surname = surname;
    }

    public override string ToString()
    {
        return $"{Surname} {Name}";
    }
}
