namespace S10.lib;
public class PhoneBook
{
    public List<Person> _Contacts{get; private set;}
    public void Add_to_phonebook(Person o)
    {
        _Contacts.Add(o);

    }
    public PhoneBook()
    {
        _Contacts =  new List<Person>();
    }
    public void Save(string Address)
    {

        string fr = File.ReadAllText(Address);
        string ey = string.Empty;
        foreach(var p in this._Contacts)
            if(!fr.Contains($"{p}"))
            {
                ey = $"{p}\n";
                File.AppendAllText(Address,ey);
                fr = File.ReadAllText(Address);
            }
        
    }
    public static PhoneBook Load(string Address)
    {
        string[] lines = File.ReadAllLines(Address);
        PhoneBook forload = new PhoneBook();
        for(int i=0;i<lines.Length;i++)
        {
            Person p = Person.new_person(lines[i]);
            forload.Add_to_phonebook(p);
        }
        return forload;
    }
        public bool Search(string firstName, string lastName,int? number, out Person s)
    {
        s = null;
        foreach(var c in this._Contacts)
        {
            if ( (string.IsNullOrWhiteSpace(firstName) || c.person_name.FirstName.StartsWith(firstName)) &&
                (string.IsNullOrWhiteSpace(lastName) || c.person_name.LastName.StartsWith(lastName)) &&
                (! number.HasValue || number.Value == int.Parse(c.person_number) ) )
                {
                    s = c;
                    return true;
                }
        }
        return false;
    }

    public bool Delete_contact(string number)
    {
        int i;
        string number_to_delete = $" {number} "; //formating
        for (i =0;i<_Contacts.Count;i+=1)
        {
            if(_Contacts[i].person_number == number_to_delete)
            {
                remove_the_nth_contact_from_phonebook(i+1);
                return true;
            }
        }
        return false;
    }
    public void remove_the_nth_contact_from_phonebook(int i)
    {
            if(_Contacts.LongCount() != 0)
                _Contacts.RemoveAt(i-1);
            else
                Console.WriteLine("phonebook is empty");

    }
    public Person get_nth_contact(int i)
    {
        return _Contacts[i-1];
    }
    public List<Person> Contacts()
    {
        return _Contacts;
    }

}