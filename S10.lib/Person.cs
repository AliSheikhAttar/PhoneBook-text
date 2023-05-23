public class  Person
{
    private Name _person_name;
    private address? _person_address;
    private string? _person_email;
    private string _person_number;
    public string details => $"name: {this._person_name?.FullName}\nnumber: {this._person_number}\nemail: {this._person_email}\naddress: {this._person_address?.Fulladdress}\n "; 
    public Person(Name a, string number, string? email, address? b)
    {
        if(b==null)
            this._person_address = null;
        this._person_name = a;
        this._person_number = number;
        this._person_email = email;
        this._person_address = b;
    }
    public string person_email
    {
        get
        {
            return _person_email;
        }
        set
        {
            _person_email = value;
        }
    }
    public Name person_name
    {
        get
        {
            return _person_name;
        }
        set
        {
            _person_name = value;
        }
    }    public address person_address
    {
        get
        {
            return _person_address;

        }
        set
        {
            _person_address = value;
        }
    }
    public string person_number
    {
        get
        {
            return _person_number;
        }
        set
        {
            _person_number = value;
        }
    }
    public override string ToString()
    {
        return $"{this._person_name.FirstName} ,{this._person_name.LastName} ,{this._person_number} ,{this._person_email} ,{this._person_address?.Fulladdress}";
    }
    public static Person new_person(string p)
    {
        var toks = p.Split(",");
        Name newname = new Name(toks[0], toks[1]);
        address newaddress = new address(toks[4], toks[5], toks[6]);
        Person newP = new Person(newname,toks[2],toks[3],newaddress);
        return newP;
    }
}